import pymongo

class WordCounter:
    def CountWordOccurance():
        MongoURI = 'mongodb://localhost:27017'
        DataBaseName = 'items'
        AmazonCollection = 'AmazonItems'
        BestBuyCollection = 'BestBuyItems'
        TargetCollection = 'TargetItems'
        client = pymongo.MongoClient(MongoURI)
        db = client[DataBaseName]
        for i in range (0,3):
            if i == 0:
                collection = db[AmazonCollection]
            elif i == 1:
                collection = db[BestBuyCollection]
            else:
                collection = db[TargetCollection]
            data = collection.find()
            Count = dict()
            for document in data:
                name = document['name']
                Words = name.lower().split()
                try:
                    for word in Words:
                        if word not in Count:
                            key = dict({word : 0})
                            Count.update(key)
                        else:
                            Count[word] = Count.get(word) + 1
                except KeyError:
                    pass
                print(Count)

    if __name__ == '__main__':
        CountWordOccurance()

