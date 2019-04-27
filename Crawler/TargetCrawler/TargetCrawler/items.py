# -*- coding: utf-8 -*-

# Define here the models for your scraped items
#
# See documentation in:
# https://doc.scrapy.org/en/latest/topics/items.html

import scrapy


class TargetItem(scrapy.Item):
        name = scrapy.Field()
        price = scrapy.Field()
        url = scrapy.Field()
        description = scrapy.Field()
        keywords = scrapy.Field()