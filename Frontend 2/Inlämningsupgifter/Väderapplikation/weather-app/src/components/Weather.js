import React, { Component } from "react";
import Moment from "react-moment";
import "moment-timezone";
import "moment/locale/sv";
import "../css/weather-icons.min.css";

export default class Weather extends Component {
  state = {
    weather: null,
    date: null,
    icon: null,
    city: null,
    maxTemp: null,
    minTemp: null,
    desc: null
  };

  componentWillMount() {
    fetch(
      "https://api.openweathermap.org/data/2.5/weather?q=Stockholm,SE&appid=90f257b3069e625823b544c241fd1c26&units=metric"
    )
      .then(resp => resp.json())
      .then(json =>
        this.setState({
          weather: Math.ceil(json.main.temp),
          date: json.dt,
          icon: json.weather[0].id,
          city: json.name,
          minTemp: Math.ceil(json.main.temp_min),
          maxTemp: Math.ceil(json.main.temp_max),
          desc: json.weather[0].main
        })
      );
  }

  render() {
    let iconString = "wi wi-owm-" + this.state.icon;

    let styles = {
      weatherStyle: {
        margin: "1em",
        display: "flex",
        flexDirection: "column",
        alignItems: "center"
      }
    };

    return (
      <div>
        <div style={{ display: "flex", fontSize: "2rem", marginTop: "2em" }}>
          <i
            className="fas fa-map-marker-alt"
            style={{
              alignSelf: "center",
              marginRight: ".7em"
            }}
          />
          <h2 style={{ margin: "0" }}>{this.state.city}</h2>
        </div>
        <div style={{ display: "flex", justifyContent: "center" }}>
          <Moment
            interval={1000}
            format="ddd, D MMM HH:mm:ss"
            tz="Europe/Stockholm"
            locale="en"
          />
        </div>
        <div style={styles.weatherStyle}>
          <div style={{ display: "flex", alignItems: "center" }}>
            <div
              style={{
                marginRight: ".2em",
                fontSize: "3rem"
              }}
            >
              <i className={iconString} />
            </div>
            <div style={{ fontSize: "5rem" }}>
              {this.state.weather}
              <i className="wi wi-degrees" style={{ marginLeft: ".1em" }} />
            </div>
          </div>
          <div style={{ fontSize: "1.2rem", display: "flex" }}>
            {this.state.maxTemp}
            <i
              className="wi wi-degrees"
              style={{ margin: "0 .1em", fontSize: "1.7rem" }}
            />
            <span style={{ marginRight: ".2em" }}>/</span>
            {this.state.minTemp}
            <i
              className="wi wi-degrees"
              style={{ margin: "0 .1em", fontSize: "1.7rem" }}
            />
          </div>
          <div style={{ margin: "1em", fontWeight: "400" }}>
            {this.state.desc}
          </div>
        </div>
      </div>
    );
  }
}
