import requests
import json

url = 'https://api.cirrus.center/api/v1/random/8ball/'
response = requests.get(url)

if response.status_code == 200:
    try:
        decoded_result = response.json()
        print(json.dumps(decoded_result))
    except json.JSONDecodeError:
        print('Error: Unable to decode JSON response.')
else:
    print(f'Error: Check API docs. HTTP Status Code: {response.status_code}')