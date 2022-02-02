import requests
import json

 

try:
    with open('key.txt') as file:
        TOKEN = file.read()
    inputLink = input("Enter your link: ")
     
    headers = {
        'Authorization': 'Bearer '+TOKEN,
        'Content-Type': 'application/json',
    }

    data = '{ "long_url": "'+inputLink+'", "domain": "bit.ly" }'

    response = requests.post('https://api-ssl.bitly.com/v4/shorten', headers=headers, data=data)

    returnedObject = json.loads(response.text)
    if(response.status_code == 200):
        print(returnedObject["link"])
    else:
        print("status code =>" + str(response.status_code))
except:
    print("Something went wrong")
