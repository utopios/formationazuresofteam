const express = require('express')
 
const app = express()

app.get('/', (req,res) => {
    res.end('hello softeam')
})

app.listen(2000, () => {
    console.log("hello from our first service")
})