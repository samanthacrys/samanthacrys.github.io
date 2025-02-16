from pymongo import MongoClient

class DatabaseError(Exception):
    pass

class Module4CRUD(object):
    """ CRUD operations for Animal collection in MongoDB """

    def __init__(self, username=None, password=None):
        try:
            if username and password:
                self.client = MongoClient(f'mongodb://{username}:{password}@nv-desktop-services.apporto.com:32165/?directConnection=true&appName=mongosh+1.8.0/AAC')
            else:
                self.client = MongoClient('mongodb://@nv-desktop-services.apporto.com:32165/?directConnection=true&appName=mongosh+1.8.0/AAC')
            self.database = self.client['AAC']
        except Exception as e:
            raise DatabaseError(f"Error initializing database connection: {e}")

    def create(self, data):
        try:
            if data is not None:
                result = self.database.animals.insert_one(data)
                return result.inserted_id is not None
            else:
                raise ValueError("Nothing to save because the data parameter is empty")
        except Exception as e:
            raise DatabaseError(f"Error creating document: {e}")

    def read(self, criteria=None):
        try:
            if criteria:
                data = self.database.animals.find(criteria, {"_id": False})
            else:
                data = self.database.animals.find({}, {"_id": False})
            return data
        except Exception as e:
            raise DatabaseError(f"Error reading data: {e}")
            
    def update(self, criteria, update_data):
        try:
            result = self.database.animals.update_many(criteria, {"$set": update_data})
            return result.modified_count > 0
        except Exception as e:
            raise DatabaseError(f"There was an error updating the documents:  {e}")
            
    def delete(self, criteria):
        try:
            result = self.database.animals.delete_many(criteria)
            return result.deleted_count > 0
        except Exception as e:
            raise DatabaseError(f"There was an error in deleting the documents: {e}")
            
    def close(self):
        if self.client:
            self.client.close()