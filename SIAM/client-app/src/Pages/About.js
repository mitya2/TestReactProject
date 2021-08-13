import React from "react";
import Draggable from 'react-draggable'

const About = () => {
  return (
    <Draggable
    axis="x"
    handle=".handle"
    defaultPosition={{x: 0, y: 0}}
    position={null}
    grid={[25, 25]}
    scale={1}>

    <div className="m-2">
      <h4>О проекте...</h4>
    </div>
    </Draggable>
  );
};

export default About;
