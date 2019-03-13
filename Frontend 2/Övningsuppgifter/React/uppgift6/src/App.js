import React, { Component } from "react";
import logo from "./logo.svg";
import "./App.css";
import {
  HelloReact,
  Message,
  Product,
  Fruitlist,
  AdressList,
  NewsList,
  Hello,
  Figure
} from "./index.js";

var date = new Date();
var currentDate = date.toDateString();
let fruits = ["Banan", "Äpple", "Apelsin", "Päron"];
const person = [
  { name: "lisa", email: "lisa@gmail.com", phone: "070-1212122" },
  { name: "kalle", email: "kalle@gmail.com", phone: "073-2424242" }
];
const newsList = [
  {
    title: "Ny version av React",
    text: "Det har kommit en uppdatering av React..."
  },
  { title: "Ny lag om tv-licens", text: "Nu dras licensen direkt ....." }
];

export default class App extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <HelloReact />
          <hr />

          {/* <Figure bgColor="#7df442"/>
          <Figure bgColor="#eb41f4"/>
          <Figure bgColor="#f9e5c7"/> */}
          <div className="Flag">
            <Figure w="50px" h="90px" background="#000000" />
            <Figure w="50px" h="90px" background="#FAE042" />
            <Figure w="50px" h="90px" background="#ED2939" />
          </div>

          <hr />

          <Hello />

          <hr />

          {/* PROPS */}

          <Message Message="Hello" messageDate={currentDate} />

          <hr />

          {/* Children */}

          <Product>
            <h3>Är jag ett barn?</h3>
          </Product>

          <hr />

          {/* Arraylist */}
          <Fruitlist array={fruits} />
          <hr />

          <AdressList People={person} />
          <hr />

          <NewsList News={newsList} />

          <hr />
        </header>
      </div>
    );
  }
}
