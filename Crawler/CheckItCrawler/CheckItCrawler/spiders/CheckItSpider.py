import scrapy
import base64

from CheckItCrawler.items import AmazonItem


class CheckItSpider(scrapy.Spider):
    name = "check"
    start_urls = [
        'https://www.amazon.com/gp/product/B07G6YBFWQ?pf_rd_p=c2945051-950f-485c-b4df-15aac5223b10&pf_rd_r=DQWEB5PM192WR2CS15Y2&th=1'
    ]

    def parse(self, response):
        for href in response.css('ul li::attr(data-dp-url)').getall():
            if href == "":
                pass
            else:
                nextLink = "https://www.amazon.com" + href
                yield scrapy.Request(nextLink, callback=self.parse_once)
        item = AmazonItem()
        item['price'] = response.xpath("string(//*[@id='price_inside_buybox'])").get().strip()
        item['name'] = response.xpath("string(//*[@id='productTitle'])").get().strip()
        item['url'] = response.request.url
        item['image_urls'] = [response.css('div.imgTagWrapper img::attr(src)').get()]
        yield item




    def parse_once(self,response):
        item = AmazonItem()
        item['price'] = response.xpath("string(//*[@id='price_inside_buybox'])").get().strip()
        item['name'] = response.xpath("string(//*[@id='productTitle'])").get().strip()
        item['url'] = response.request.url
        item['image_urls'] = [response.css('div.imgTagWrapper img::attr(src)').get()]
        yield item

