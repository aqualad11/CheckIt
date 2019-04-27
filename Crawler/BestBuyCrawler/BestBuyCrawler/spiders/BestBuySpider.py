import scrapy

from BestBuyCrawler.items import BestBuyItem

class BestBuySpider(scrapy.Spider):
    name = "BestBuy"
    allowed_domains = ["bestbuy.com"]
    start_urls = [
        #'https://www.bestbuy.com/site/searchpage.jsp?cp=1&searchType=search&_dyncharset=UTF-8&ks=960&sc=Global&list=y&usc=All%20Categories&type=page&id=pcat17071&iht=n&seeAll=&browsedCategory=abcat0515000&st=categoryid%24abcat0515000&qp=brand_facet%3DBrand~CORSAIR%5Ecategory_facet%3DComputer%20Keyboards~abcat0513004&sp=-bestsellingsort%20skuidsaas'
        'https://www.bestbuy.com/site/all-desktops/gaming-desktops/pcmcat287600050002.c?id=pcmcat287600050002',
        'https://www.bestbuy.com/site/searchpage.jsp?id=pcat17071&nrp=15&cp=1&sp=-bestsellingsort%20skuidsaas&seeAll=&ks=960&sc=Global&list=y&usc=All%20Categories&type=page&iht=n&browsedCategory=abcat0515000&st=categoryid%24abcat0515000&qp=collection_facet%3DCollection~Gaming%20Series',
        'https://www.bestbuy.com/site/computers-pcs/computer-cards-components/abcat0507000.c?id=abcat0507000',
        'https://www.bestbuy.com/site/pc-games/pc-games-games/pcmcat174700050005.c?id=pcmcat174700050005',
        'https://www.bestbuy.com/site/aerial-drones-accessories/all-drones/pcmcat748300869789.c?id=pcmcat748300869789',
        'https://www.bestbuy.com/site/promo/tv-deals',
    ]

    def parse(self, response):
        count = 0
        for href in response.css("h4.sku-header a::attr(href)").getall():
            if href == "":
                pass
            else:
                nextLink = "https://www.bestbuy.com" + href
                count = count + 1
                yield scrapy.Request(nextLink, callback=self.parse_item,meta={'count' : count})

        for href in response.css("li.page-item a::attr(href)").getall():
            if href == "":
                pass
            else:
                nextLink = href
                yield scrapy.Request(nextLink, callback=self.parse_item)

    def parse_item(self,response):
        item = BestBuyItem()
        item['name'] = response.css("div.sku-title h1::text").get()
        item['price'] = response.xpath("string(//*[@id='priceblock-wrapper-wrapper']/div[1]/div[1]/div[2]/div[1]/div/div/div/div/div[2]/div/div[1]/div/span[1])").get()
        item['url'] = response.request.url
        item['description'] = response.xpath("string(//*[@id='long-description'])").get()
        item['keywords'] = ""
        yield item
        for href in response.css("div.cyp-item-group a::attr(href)").getall():
            if href == "":
                pass
            else:
                nextLink = "https://www.bestbuy.com" + href
                yield scrapy.Request(nextLink, callback=self.parse_item)


#//*[@id="grpDescrip_23-201-108"]
#//*[@id="grpDescrip_23-201-108"]/text()

