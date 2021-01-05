import { timers } from 'jquery';
import React, {Component} from 'react';
import CanvasJSReact from './canvasjs.react';
var CanvasJS = CanvasJSReact.CanvasJS;
var CanvasJSChart = CanvasJSReact.CanvasJSChart;


var dataPoints =[];
export class Chart extends React.Component {

  constructor(props) {
    super(props);
      this.state = {
        expensecategories1: [],
        label: "APPLE",
        y: 100
      }; 

    
  }

    componentDidMount() {
      
        
        var chart = new CanvasJS.Chart("chartContainer", {
            animationEnabled: true,
            title:{
              text: "Basic Column Chart"
            },
            
            data: [
              {
                type: "column",
                dataPoints: [
                  { label: this.state.label,  y: this.state.y  }
                ]
              }
            ]
        });
    chart.render();
    console.log(this.state.label);
  }
  
  render() {
    fetch("https://localhost:44317/chart/kazkas" )
        .then(res => res.json()).then(
            result => {
                this.setState({expensecategories1:result}
                  );
            }
        );
    return (
      <div id="chartContainer" style={{height: 360 + "px", width: 100 + "%"}}>
      </div>
    );
  }
}

// ========================================


 
