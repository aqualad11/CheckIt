import scrapy
import AmazonItem.py


class TestCrawl(scrapy.Spider):
    name = "amazon"
    start_urls = [
        'https://www.amazon.com/gp/product/B07G6YBFWQ?pf_rd_p=c2945051-950f-485c-b4df-15aac5223b10&pf_rd_r=DQWEB5PM192WR2CS15Y2&th=1'
        #'https://www.amazon.com/MSI-GeForce-GTX-1050-TI/dp/B01MA62JSZ/ref=sr_1_8?s=pc&ie=UTF8&qid=1549168346&sr=1-8&keywords=graphics+card'
    ]
    #response.xpath("//*[@id='color_name_2']@data-dp-url").get().strip()
    def parse_once(self, link):
        response = scrapy.Request(link)
        item = AmazonItem()
        item['price'] = response.xpath("string(//*[@id='price_inside_buybox'])").get().strip()
        item['name'] = response.xpath("string(//*[@id='productTitle'])").get().strip()
        item['url'] = response.request.url

        yield item

    def parse(self,response):
        item = AmazonItem()
        item['price'] = response.xpath("string(//*[@id='price_inside_buybox'])").get().strip()
        item['name'] = response.xpath("string(//*[@id='productTitle'])").get().strip()
        item['url'] = response.request.url

        yield item


        for href in response.css('ul li::attr(data-dp-url)').getall():
            if href is not None:
                nextLink = "https://www.amazon.com/" + href
                TestCrawl.parse_once(nextLink)





