const express = require('express');
const app = express();
const port = 3000;

app.get('/', async (req, res) => {
    const fetch = (await import('node-fetch')).default;
    const url = 'https://api.cirrus.center/api/v1/random/8ball/';

    fetch(url)
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            return response.json();
        })
        .then(data => {
            res.json(data);
        })
        .catch(error => {
            res.status(500).send('Error: ' + error.message);
        });
});

app.listen(port, () => {
    console.log(`Server running at http://localhost:${port}/`);
});