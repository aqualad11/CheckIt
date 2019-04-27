import scrapy

from CheckItCrawler.items import AmazonItem


class CheckItSpider(scrapy.Spider):
    name = "Amazon"
    start_urls = [
       'https://www.amazon.com/b/?node=281052&ref_=Oct_CateC_502394_0&pf_rd_p=fecc1194-e7d2-5385-ac05-2ce5e9c4dd23&pf_rd_s=merchandised-search-4&pf_rd_t=101&pf_rd_i=502394&pf_rd_m=ATVPDKIKX0DER&pf_rd_r=SEDKSRX9ZQYZAZ543WXQ&pf_rd_r=SEDKSRX9ZQYZAZ543WXQ&pf_rd_p=fecc1194-e7d2-5385-ac05-2ce5e9c4dd23',
        'https://www.amazon.com/b/?node=2407774011&ref_=Oct_CateC_2407755011_1&pf_rd_p=9a527948-ee17-5da2-9df4-8a2d21c3c09a&pf_rd_s=merchandised-search-4&pf_rd_t=101&pf_rd_i=2407755011&pf_rd_m=ATVPDKIKX0DER&pf_rd_r=BX2ZG80R5775W32THND6&pf_rd_r=BX2ZG80R5775W32THND6&pf_rd_p=9a527948-ee17-5da2-9df4-8a2d21c3c09a'
        'https://www.amazon.com/b/ref=s9_acss_bw_cg_KOTHLPCG_1b1_w?node=565098&pf_rd_m=ATVPDKIKX0DER&pf_rd_s=merchandised-search-6&pf_rd_r=SZ3M9ZQPMWBJWSXY2JJ5&pf_rd_t=101&pf_rd_p=1e1598d2-28c3-4a64-91af-254d7a033ada&pf_rd_i=541966'
    ]

    def parse(self, response):
        for href in response.css("a.a-link-normal::attr(href)").getall():
            if href == "":
                pass
            elif href[0:3] == "/gp":
                nextLink = "https://www.amazon.com" + href
                yield scrapy.Request(nextLink,callback= self.parse_item)


    def parse_item(self,response):
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
        item['description'] = response.xpath("string(//*[@id='productDescription']/p/text())").get().strip()
        item['keywords'] = ""
        yield item


    # shop-product-carousels-58339243 > div > div > div > div > div > div.pager-carousel-content > div > ul > li:nth-child(10) > div > div > div.product-block-mini__image-anchor > a
    # shop-product-carousels-58339243 > div > div > div > div > div > div.pager-carousel-content > div > ul > li:nth-child(10) > div > div > div.product-block-mini__image-anchor
##pdp-content > div:nth-child(2) > section > div.pdp-mini-carousel-wrapper > div > div.carousel-container > div > div > div.outterSlideWrapper
    def parse_once(self,response):
        item = AmazonItem()
        item['price'] = response.xpath("string(//*[@id='price_inside_buybox'])").get().strip()
        item['name'] = response.xpath("string(//*[@id='productTitle'])").get().strip()
        item['url'] = response.request.url
        item['description'] = response.xpath("string(//*[@id='productDescription']/p/text())").get().strip()
        item['keywords'] = ""
        yield item

