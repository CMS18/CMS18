import React, { Component } from "react";
import DailyForecast from "./DailyForecast";
import HourlyForecast from "./HourlyForecast";
import moment from "moment";
import "moment-timezone";
import "moment/locale/sv";
import Slider from "react-slick";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";

export default class Forecast extends Component {
  state = {
    dailyForecast: [],
    hourlyForecast: []
  };

  componentWillMount() {
    fetch(
      "https://api.openweathermap.org/data/2.5/forecast?q=Stockholm,SE&appid=90f257b3069e625823b544c241fd1c26&units=metric"
    )
      .then(resp => resp.json())
      .then(json => {
        let filteredHourly = this.filteredHourly(json.list);
        let filteredDaily = this.filteredDaily(json.list);
        this.setState({
          dailyForecast: filteredDaily,
          hourlyForecast: filteredHourly
        });
      });
  }

  filteredHourly = list => {
    let hourlyForecast = list.filter(item => {
      let hour = moment.unix(item.dt).hours();
      return hour;
    });
    return hourlyForecast;
  };

  filteredDaily = list => {
    let dailyForecast = list.filter(item => {
      let hour = moment
        .unix(item.dt)
        .utc()
        .hour();
      // if (hour >= 12 && hour <= 21) {
      if (hour === 15) {
        // create a function that returns an array of object based of what day it is

        return item;
      }
      return null;
    });
    return dailyForecast;
  };

  render() {
    let settings = {
      infinite: true,
      speed: 500,
      slidesToShow: 1,
      slidesToScroll: 1
    };

    let styles = {
      sliderLayout: {
        width: "25%",
        background: "rgba(255, 255, 255, .2)",
        borderRadius: "1.5em",
        padding: "1em 2.5em",
        boxSizing: "border-box",
        minHeight: "13em"
      }
    };

    let dailyForecast = this.state.dailyForecast.map((item, i) => (
      <DailyForecast key={i} {...item} />
    ));
    return (
      <React.Fragment>
        <div style={{ width: "23%", marginBottom: ".2em" }}>Hourly</div>
        <HourlyForecast hourlyForecast={this.state.hourlyForecast} />
        <div style={{ width: "23%", marginBottom: ".2em" }}>Daily</div>
        <div style={styles.sliderLayout} className="lol">
          <Slider {...settings}>{dailyForecast}</Slider>
        </div>
      </React.Fragment>
    );
  }
}
