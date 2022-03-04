FROM debian

RUN apt-get update 

RUN apt-get upgrade -y

RUN apt-get install nodejs npm -y

WORKDIR /app

COPY . .

RUN npm install

ENTRYPOINT [ "node", "index.js" ]

