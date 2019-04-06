import React, { Component } from "react";
import ForecastItem from "./ForecastItem";
import ForecastDetails from "./ForecastDetails";
import moment from "moment";
import "moment-timezone";
import "moment/locale/sv";
import Slider from "react-slick";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";

export default class Forecast extends Component {
  state = {
    forecast: [],
    details: []
  };

  componentWillMount() {
    fetch(
      "https://api.openweathermap.org/data/2.5/forecast?q=Stockholm,SE&appid=90f257b3069e625823b544c241fd1c26&units=metric"
    )
      .then(resp => resp.json())
      .then(json => {
        let filteredDay = this.filteredDay(json.list);
        let filteredList = this.filterlist(json.list);
        this.setState({
          forecast: filteredList,
          details: filteredDay
        });
      });
  }

  filteredDay = list => {
    let forecastDetails = list.filter(item => {
      let day = moment
        .unix(item.dt)
        .utc()
        .hours();
      return day;
    });
    return forecastDetails;
  };
  filterlist = list => {
    let forecastDays = list.filter(item => {
      let hour = 
      moment
        .unix(item.dt)
        .utc()
        .hours();
      if (hour === 12) {
        return item;
      }
      return null;
    });
    return forecastDays;
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
        minHeight: "13em",
      }
    };

    let weatherForecast = this.state.forecast.map((item, i) => (
      <ForecastItem key={i} {...item} />
    ));
    return (
      <React.Fragment>
        <div style={{ width: "23%", marginBottom: ".2em" }}>Hourly</div>
        <ForecastDetails forecastDetails={this.state.details} />
        <div style={{ width: "23%", marginBottom: ".2em" }}>Daily</div>
        <div style={styles.sliderLayout} className="lol">
          <Slider {...settings}>{weatherForecast}</Slider>
        </div>
      </React.Fragment>
    );
  }
}
