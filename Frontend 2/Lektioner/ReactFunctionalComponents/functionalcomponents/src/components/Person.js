import React from "react";

export default function Person(props) {
  let personValues =
    props.person.height +
    "-" +
    props.person.mass +
    "-" +
    props.person.hair_color;
  return (
    <div>
      <h3>{props.person.name}</h3>
      <p>{personValues}</p>
    </div>
  );
}
