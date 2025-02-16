from UserAuthentication import AuthenticateUser, UserLogout, GetCurrentUser
from CRUD import Module4CRUD, DatabaseError  # My CRUD file and the classes that contain the code.

import base64
import re
import dash_bootsrap_components as dbc
from bson import ObjectID
import dash
from passlib.hash import pbkdf2_sha256
from waitress import serve
from dash import Dash, dcc, html, Input, Output, State, callback, MATCH, no_update, ALL, dash_table as dt
from dash.exceptions import PreventUpdate
import dash_leaflet as dl
import pandas as pd
from pymongo import MongoClient


###########################
# Data Manipulation / Model
###########################

#This is the login feature. It sets the information and the window for entering the username and password for verification
#of the users. This is to appear before the user gets the database information shown to them. This way there is no hardcoding
#of the username and password. This also helps when a database has more than one user.
loginFeature = dbc.Modal(
    [
        dbc.ModalHeader("Login"),
        dbc.ModalBody(
            [
                dcc.Input(id='usernameInput', type='text', placeholder='Enter username'),
                dcc.Input(id='passwordInput', type='password', placeholder='Enter password'),
                html.Div(id='loginMessage', style={'color': 'red'})
            ]
        ),
        dbc.ModalFooter(
            dbc.Button('Login', id='loginButton', n_clicks=0, color='primary'),
        ),
    ],
    id='loginFeature',
    is_open=False,
)

app = dash.Dash(__name__, external_stylesheets=[dbc.themes.BOOSTRAP])

#Sets to allow for connecting to the correct database and the correct collection.
client = MongoClient('mongodb://localhost:27017/AAC?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+2.3.8')
db = ['AAC']
collection = db['Animals']
collectionUsers = db['users']

df = pd.DataFrame(list(collection.find({}, projection={'_id': 0})))


# Sets the different types of rescue that can be searched for.
rescueTypes = ['Water Rescue', 'Mountain or Wilderness Rescue', 'Disaster or Individual Tracking', 'Reset']


#########################
# Dashboard Layout / View
#########################
app = JupyterDash(__name__)


image_filename = 'GraziosoSalvareLogo.png'  # The image requested by the company.
encoded_image = base64.b64encode(open(image_filename, 'rb').read())

app.layout = html.Div([
    html.Center(html.Img(src='data:image/png;base64, {}'.format(encoded_image.decode()), style={'width': '150px'}, ), ),
    html.Center(html.B(html.H1('Samantha Durr, CS-340 Dashboard'))),
    html.Hr(),
    html.Div(
        dcc.RadioItems(id='rescue-type', options=[{'label': i, 'value': i} for i in rescueTypes],
                       value='Reset',
                       labelStyle={'display': 'inline-block'}),  # Sets the radio items in a line.

    ),
    html.Hr(),
    #The display set up here allows for ensuring that the data does not show up in one page. Shortening the amount of
    #documents displayed on a single page allows for faster loading and searching.
    dash_table.DataTable(id='datatable-id',
                         columns=[{"name": i, "id": i, "deletable": False, "selectable": True} for i in df.columns],
                         data=df.to_dict('records'),
                         row_selectable="single",
                         selected_rows=[0],
                         page_action='native',
                         page_current=0,
                         page_size=20,
                         style_table={'height': '300px', 'overflowY': 'auto'}
                         ),
    html.Br(),
    html.Hr(),
    html.Div(className='row',
             style={'display': 'flex'},
             children=[
                 html.Div(
                     id='graph-id',
                     className='col s12 m6',

                 ),
                 html.Div(
                     id='map-id',
                     className='col s12 m6',
                 )
             ])
])


#############################################
# Interaction Between Components / Controller
#############################################

#This is for the login component of the dashboard. Without this, the system would not be able to take the login
#that was created and turn it into an actual feature. This allows for ensuring that this works.
@app.callback(
[
    Output('auth-status', 'children'),
    Output('loginFeature', 'is_open'),
    Output('loginMessage', 'children'),
    Output('url', 'pathname'),
],
[
    Input('loginButton', 'n_clicks'),
    Input('openLoginButton', 'n_clicks'),
],
[
    State('usernameInput', 'value'),
    State('passwordInput', 'value'),
    State('url', 'pathname'),
    State('loginFeature', 'is_open'),
],
    prevent_initial_call = True
)

#This method allows a user to enter a password and username in order to register if the information is entered
#correctly. This allows for registering clicks and if the user is authenticated and allowing them into the system.
#Otherwise, it will let the user know that something is invalid and not allow them in. This helps provide verification
# to the database on users.
def UserLogin(loginButtonClicks, openLoginClicks, username, password, urlPathname, isLoginOpen):
    try:
        if loginButtonClicks:
            authenticated = AuthenticateUser(username, password)

            if authenticated:
                return(
                    f"Welcome {username}",
                    False,
                    None,
                    urlPathname,
                )
            else:
                return(
                    "Invalid Username or Password.",
                    True,
                    "Invalid username or Password.",
                    urlPathname
                )
        elif openLoginClicks:
            return no_update, True, no_update, no_update
        else:
            return no_update, no_update, no_update, no_update
    except Exception as e:
        print(f"Error in the login callback: {str(e)}")
        return(
            f"Authentication error: {str(e)}",
            False,
            None,
            urlPathname
        )

@app.callback(Output('datatable-id', 'data'),
              [Input('rescue-type', 'value')])
def update_dashboard(filter_type):
    # Checks the different radio buttons and the database for specific values being searched for in terms of
    # the different types of rescues. Displays only the those that match the criteria of the appropriate
    # if statement.
    if filter_type == 'Reset':
        dff = df
    elif filter_type == 'Water Rescue':
        dff = df[df.breed.isin(['Labrador Retriever Mix', 'Chesapeake Bay Retriever', 'Newfoundland'])
                 & (df.sex_upon_outcome == 'Intact Female')
                 & ((df.age_upon_outcome_in_weeks >= 26) & (df.age_upon_outcome_in_weeks <= 156))]
    elif filter_type == 'Mountain or Wilderness Rescue':
        dff = df[df.breed.isin(['German Shepherd', 'Alaskan Malamute', 'Old English Sheepdog',
                                'Siberian Husky', 'Rottweiler'])
                 & (df.sex_upon_outcome == 'Intact Male')
                 & ((df.age_upon_outcome_in_weeks >= 26) & (df.age_upon_outcome_in_weeks <= 156))]
    elif filter_type == 'Disaster or Individual Tracking':
        dff = df[df.breed.isin(['Doberman Pinscher', 'German Shepherd', 'Golden Retriever',
                                'Bloodhound', 'Rottweiler'])
                 & (df.sex_upon_outcome == 'Intact Male')
                 & ((df.age_upon_outcome_in_weeks >= 20) & (df.age_upon_outcome_in_weeks <= 300))]

    return dff.to_dict('records')


@app.callback(
    Output('graph-id', "children"),
    [Input('datatable-id', "derived_virtual_data")])
def update_graphs(viewData, px=None):
    # Creates a pie chart that displays all of the different breeds. When a specific search is called for,
    # it updates the graph to show the appropriate breeds and what portion they make up of that group.
    if not viewData:
        return dcc.Graph(figure=px.pie())
    else:
        dff = pd.DataFrame.from_dict(viewData)
        fig = px.pie(dff, names='breed', title='Breed Distribution')
        return dcc.Graph(figure=fig)


@app.callback(
    Output('datatable-id', 'style_data_conditional'),
    [Input('datatable-id', 'selected_columns')]
)
def update_styles(selected_columns):
    return [{
        'if': {'column_id': i},
        'background_color': '#D2F3FF'
    } for i in selected_columns]


#This is for geolocation data.
@app.callback(
    Output('map-id', "children"),
    [Input('datatable-id', "derived_virtual_data"),
     Input('datatable-id', "derived_virtual_selected_rows")])
def update_map(viewData, index):
    if viewData is None:
        return
    elif index is None:
        return

    dff = pd.DataFrame.from_dict(viewData)
    # Because we only allow single row selection, the list can be converted to a row index here
    if index is None:
        row = 0
    else:
        row = index[0]

    # Austin TX is at [30.75,-97.48]
    return [
        dl.Map(style={'width': '1000px', 'height': '500px'}, center=[30.75, -97.48], zoom=10, children=[
            dl.TileLayer(id="base-layer-id"),
            dl.Marker(position=[dff.iloc[row, 13], dff.iloc[row, 14]], children=[
                dl.Tooltip(dff.iloc[row, 8]),  # changed this to ensure that the appropriate name would appear.
                dl.Popup([
                    html.H1("Animal Name"),
                    html.P(dff.iloc[row, 9])
                ])
            ])
        ])
    ]


app.run_server(debug=True, port=8050)

