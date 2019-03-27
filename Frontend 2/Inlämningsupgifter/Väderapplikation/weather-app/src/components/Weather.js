import React, { Component } from "react";
import Moment from "react-moment";
import "moment-timezone";
import "moment/locale/sv";
import "../css/weather-icons.min.css";

export default class Weather extends Component {
  constructor(props) {
    super(props);

    this.state = {
      weather: null,
      date: null,
      icon: null,
      city: null
    };
  }

  componentWillMount() {
    fetch(
      "https://api.openweathermap.org/data/2.5/weather?q=Stockholm,SE&appid=90f257b3069e625823b544c241fd1c26&units=metric"
    )
      .then(resp => resp.json())
      .then(json =>
        this.setState({
          weather: json.main.temp,
          date: json.dt,
          icon: json.weather[0].id,
          city: json.name
        })
      );
  }

  render() {
    let iconString = "wi wi-owm-" + this.state.icon;
    let weather = Math.ceil(this.state.weather);

    let weatherBox = {
      width: "auto",
      height: "10em",
      background: "rgba(255, 255, 255, .4)",
      borderRadius: ".2em",
      display: "flex",
      alignItems: "center",
      justifyContent: "center",
      flexDirection: "column",
      padding: ".5em",
      textTransform: "uppercase"
    };

    return (
      <div style={weatherBox}>
        <h2>{this.state.city}</h2>
        <div>
          <i className={iconString} />
          {weather} <i className="wi wi-celsius" />
        </div>
        <Moment unix tz="Europe/Stockholm" format="LT">
          {this.state.date}
        </Moment>
      </div>
    );
  }
}
