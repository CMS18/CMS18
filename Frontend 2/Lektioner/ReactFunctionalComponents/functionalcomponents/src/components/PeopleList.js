import React from "react";
import Person from "./Person";

export default function PeopleList(props) {
  let allItems = props.people.map(person => {
    return <Person person={person} key={person.url}/>;
  });
  return <React.Fragment>{allItems}</React.Fragment>;
}
