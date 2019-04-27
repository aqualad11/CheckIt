import scrapy
from bs4 import BeautifulSoup
#from scrapy_splash import SplashRequest
from selenium import webdriver
from threading import Thread
from selenium.webdriver.support.ui import WebDriverWait
from selenium.common.exceptions import TimeoutException
from time import sleep
from selenium.webdriver.common.by import By
from selenium.webdriver.support import expected_conditions as EC
#from webdriver_manager import ChromeDriverManager
from TargetCrawler.items import TargetItem

class TargetSpider(scrapy.Spider):
    name = "Target"
    allowed_domains = ["target.com"]
    start_urls = [
        #'https://www.target.com/c/desktop-gaming-computers-computers-office-electronics/-/N-5xtf7?lnk=DesktopGamingCo'
        #'https://www.target.com/p/hp-pre-owned-certified-desktop-computer-with-6200-sff-core-i3-2100-processor-black-tt2-0003/-/A-50745620',
        'https://www.target.com/c/desktop-gaming-computers-office-electronics/-/N-5xtf7'
    ]
    def parse(self, response):
        # Get the URL using Selenium. We will wait 20s for the page to fully load the html we need.
        # Use BeautifulSoup so we can read the new html page.
        driver = webdriver.Chrome(executable_path=r"C:\Users\Bryan\Downloads\chromedriver_win32\chromedriver.exe")
        driver.get(response.url)
        driver.implicitly_wait(10)
        soup = BeautifulSoup(driver.page_source,features="html.parser")
        driver.close()
        # Get all the href tags in the html.
        # If the result starts with a '/p/ - it is a link to a product. So send a request to scrape it.
        for href in soup.find_all('a', href=True):
            link = href['href']
            if link == "":
                pass
            elif link[0] == '#':
                pass
            elif link[0] == 'h':
                pass
            elif link[0:2] == "/p":
                url = "https://www.target.com" + link
                yield scrapy.Request(url, callback=self.parse_item)
            else:
                pass
    def parse_item(self, response):
        driver = webdriver.Chrome(executable_path=r"C:\Users\Bryan\Downloads\chromedriver_win32\chromedriver.exe")
        driver.get(response.url)
        driver.implicitly_wait(10)
        soup = BeautifulSoup(driver.page_source, features="html.parser")
        driver.quit()
        price = soup.find('span', {"data-test": "product-price"}).getText()
        name = soup.find('span', {"data-test": "product-title"}).getText()
        descp = soup.find('div', {"class": "h-margin-v-default"}).getText()
        item = TargetItem()
        item['name'] = name
        item['price'] = price
        item['url'] = response.request.url
        item['description'] = descp
        item['keywords'] = ""
        yield item
        # Get all related items on the product page.
        for href in soup.find_all('a', href=True):
            link = href['href']
            if link == "":
                pass
            elif link[0] == '#':
                pass
            elif link[0] == 'h':
                pass
            elif link[0:2] == "/p":
                url = "https://www.target.com" + link
                yield scrapy.Request(url, callback=self.parse_item)
            else:
                pass
