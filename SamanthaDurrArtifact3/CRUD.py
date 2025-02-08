from pymongo import MongoClient

class DatabaseError(Exception):
    pass

class Module4CRUD(object):

    #Base code for username and password if needed, but should not be.
    def __init__(self, username=None, password=None):
        try:
            if username and password:
                self.client = MongoClient(f'mongodb://{username}:{password}@127.0.0.1:27017/Artifact3?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+2.3.8/AAC')
            else:
                self.client = MongoClient('mongodb://127.0.0.1:27017/Artifact3?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+2.3.8/AAC')   
            self.database = self.client['AAC']
        except Exception as e:
            raise DatabaseError(f"Error initializing database connection: {e}")

    #Creates new entries when the appropriate data is set. If it does not have the correct information, it will let the
    #user know.
    def create(self, data):
        try:
            if data is not None:
                result = self.database.Animals.insert_one(data)
                return result.inserted_id is not None
            else:
                raise ValueError("Nothing to save because the data parameter is empty")
        except Exception as e:
            raise DatabaseError(f"Error creating document: {e}")

    #This reads data that is queried in the database.
    def read(self, criteria=None):
        try:
            if criteria:
                data = self.database.Animals.find(criteria, {"_id": False})
            else:
                data = self.database.Animals.find({}, {"_id": False})
            return data
        except Exception as e:
            raise DatabaseError(f"Error reading data: {e}")

    #Updates a document that is queried and provided with the updated information. If it cannot do that, then it
    #lets the user know.
    def update(self, criteria, update_data):
        try:
            result = self.database.Animals.update_many(criteria, {"$set": update_data})
            return result.modified_count > 0
        except Exception as e:
            raise DatabaseError(f"There was an error updating the documents:  {e}")

    #Allows for deleting a document in the database. If there is an error, it lets the user know.
    def delete(self, criteria):
        try:
            result = self.database.Animals.delete_many(criteria)
            return result.deleted_count > 0
        except Exception as e:
            raise DatabaseError(f"There was an error in deleting the documents: {e}")

    #This closes the client.
    def close(self):
        if self.client:
            self.client.close()