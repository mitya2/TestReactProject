import React from "react";
import "./css/Loading.css";

const Loading = () => {
  return (
    <div style={{ display: "flex", justifyContent: "center", margin: "5rem" }}>
      <div className="lds-dual-ring" />
    </div>
  );
};

export default Loading;
