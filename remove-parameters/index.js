const express = require('express');
const fetch = require('node-fetch');
const app = express();
const port = 3000;

app.get('/remove-params/:link', async (req, res) => {
    const link = req.params.link;
    const url = `https://api.cirrus.center/api/v1/edit/remove-params/?url=${link}`;

    fetch(url)
        .then(response => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error(`HTTP Code: ${response.status}`);
            }
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