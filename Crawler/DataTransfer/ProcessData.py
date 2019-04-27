

keywords = {
    'pc' : 'computer',
    'ps4' : 'play station 4',
    'sunglasses' : 'shades',
    'desktop' : 'computer',
    'headphone' : 'headset',
    'ac' : 'charger',
    'adapter' : 'charger',
    'usb-c' : 'charger',
    'pad' : 'mouse pad',
}
class ProcessData:
    #We need to create keywords based off the words in a given title of a product.
    #CreateKeyWords will split a Products Name and attempt to create relevant keywords.
    def CreateKeyWords(name):
        WordsList = name.lower().split()
        keys = []
        try:
            for word in WordsList:
                if word not in keywords:
                    pass
                else:
                    if( keywords.get(word) in keys):
                        pass
                    else:
                        keys.append(keywords.get(word))
        except KeyError:
            pass
        return keys