from DataTransfer import DataTransfer

if __name__ == '__main__':
    #Set variables to access local MongoDB
    MongoURI = 'mongodb://localhost:27017'
    DataBaseName = 'items'
    #Set variables to access different collections
    AmazonCollection = 'AmazonItems'
    BestBuyCollection = 'BestBuyItems'
    TargetCollection = 'TargetItems'
    #Send the necessary information to connect to local MongoDB instance
    DataTransfer.AtlasTransfer(MongoURI, DataBaseName,AmazonCollection)
    DataTransfer.AtlasTransfer(MongoURI, DataBaseName,BestBuyCollection)
    DataTransfer.AtlasTransfer(MongoURI, DataBaseName,TargetCollection)
