from passlib.hash import pbkdf2_sha256
from pymongo import MongoClient

#Basic set up to ensure that the client accesses the correct connection and the correct database within that. Note: If this
#code is being used by someone else, the MongoClient and db need to be changed to the appropriate path or it will not
#work.
client = MongoClient('mongodb://127.0.0.1:27017/Artifact3?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+2.3.8/AAC')
db = client['AAC']

#This is to ensure that the database knows what user is being looked at.
collection_users = db['users']

#This is used for authenticating a user that is found within the users db. It ensures that the password can be verified
#and matched together as the database says. If this is the case, then it returns True and means that it is authenticated.
#When that is the case, it will allow one into the system.
def AuthenticateUser(username, password):
    user = collection_users.find_one({'username': username})

    if user and pbkdf2_sha256.verify(password, user['password']):
        return True
    else:
        return False

#This logs the userout when they are done.
def UserLogout():
    global currentUser
    currentUser = None

#This sets the currentUser to none so that nobody is set as logged in.
currentUser = None

#This is another AuthenticateUser method that works for verifying that the global user can be authenticated
#as well. If the user is authenticated, then it will set that user to the authenticated username. This allows for making
#sure that the correct user is shown and is also the correct one is logged out. If the user is not verified, then it
#keeps currentUser as none.
def AuthenticateUser(username, password):
    global currentUser

    user = collection_users.find_one({'username': username})

    if user and pbkdf2_sha256.verify(password, user['password']):
        currentUser =username
        return True
    else:
        currentUser = None
        return False

#This gets the current user and returns that information when requested.
def GetCurrentUser():
    return currentUser