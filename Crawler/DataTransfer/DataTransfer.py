import pymongo
from ProcessData import ProcessData
class DataTransfer:
    #Define the connection to Mongo Atlas
    AtlasConnection = ""
    AtlasClient = pymongo.MongoClient(AtlasConnection)
    AtlasDB = AtlasClient['CheckIt']
    def AtlasTransfer(URI,DataBaseName,CollectionName):
        #Establish connection to local MongoDB
        client = pymongo.MongoClient(URI)
        db = client[DataBaseName]
        collection = db[CollectionName]
        #Grab all the data for the given collection
        data = collection.find()
        # Create Atlas Collection
        AtlasCollection = DataTransfer.AtlasDB[CollectionName]
        #Once data has been processed, upload to Mongo Atlas.
        for document in data:
            #Get related keywords based of a given Title.
            #A list is returned.
            name = document['name']
            KeyWords = ProcessData.CreateKeyWords(name)
            #Write the new Document to Atlas.
            document['keywords'] = KeyWords
            AtlasCollection.insert(dict(document))


