import React, { Component } from "react";
import moment from "moment";
import "moment-timezone";
import "moment/locale/sv";
import "../css/weather-icons.min.css";

export default class ForecastItem extends Component {
  render() {
    let styles = {
      dailyLayout: {
        height: "10em",
        display: "flex",
        flexDirection: "column",
        justifyContent: "space-between"
      }
    };
    let iconString = "wi wi-owm-" + this.props.weather[0].id;
    let date = moment
      .unix(this.props.dt)
      .utc()
      .locale("en")
      .calendar(null, {
        sameDay: "[Today]",
        nextDay: "[Tomorrow]",
        nextWeek: "dddd",
        lastDay: "[Yesterday]",
        lastWeek: "[Last] dddd",
        sameElse: "DD/MM/YYYY"
      });

    return (
      <div style={styles.dailyLayout}>
        <div style={{ fontSize: "1.5em" }}>{date}</div>
        <div>
          <i className={iconString} style={{ fontSize: "3rem" }} />

          <div
            style={{
              display: "flex",
              justifyContent: "center",
              alignItems: "center"
            }}
          >
            <i className="wi wi-humidity" style={{ fontSize: ".8em" }} />
            <div
              style={{
                margin: ".2em",
                fontSize: "1.2rem"
              }}
            >
              {Math.ceil(this.props.main.humidity)}%
            </div>
          </div>
        </div>
        <div
          style={{
            fontSize: "1.1rem"
          }}
        >
           <div style={{ fontSize: "1.2rem" }}>
            {Math.ceil(this.props.main.temp_max)}
            <i className="wi wi-degrees" style={{ margin: "0 .1em", fontSize: "1.7rem" }} />
            <span style={{ marginRight: ".2em" }}>/</span>
            {Math.ceil(this.props.main.temp_min)}
            <i className="wi wi-degrees" style={{ margin: "0 .1em", fontSize: "1.7rem" }} />
          </div>
        </div>
      </div>
    );
  }
}
