package main

import (
    "encoding/json"
    "fmt"
    "io/ioutil"
    "net/http"
)

func main() {
    url := "https://api.cirrus.center/api/v1/random/8ball/"
    resp, err := http.Get(url)
    if err != nil {
        fmt.Println("Error: ", err)
        return
    }
    defer resp.Body.Close()

    if resp.StatusCode == http.StatusOK {
        bodyBytes, err := ioutil.ReadAll(resp.Body)
        if err != nil {
            fmt.Println("Error: ", err)
            return
        }

        var result map[string]interface{}
        jsonErr := json.Unmarshal(bodyBytes, &result)
        if jsonErr != nil {
            fmt.Println("Error: Unable to decode JSON response.")
            return
        }

        jsonString, _ := json.Marshal(result)
        fmt.Println(string(jsonString))
    } else {
        fmt.Printf("Error: HTTP status code %d. Check API docs.\n", resp.StatusCode)
    }
}