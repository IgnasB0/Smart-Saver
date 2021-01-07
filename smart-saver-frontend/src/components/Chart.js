import React, { useState, useEffect } from "react";
import { Line } from "react-chartjs-2";
import axios from "axios";

const Chart = () => {
  const [chartData, setChartData] = useState({});
  const [employeeSalary, setEmployeeSalary] = useState([]);
  const [employeeAge, setEmployeeAge] = useState([]);

  const chart = () => {
    let empSal = [];
    let empAge = [];
    axios
      .get("show-chart-for-one-user")
      .then(res => {
        console.log(res);
        for (const dataObj of res.data) {
          empSal.push(parseFloat(dataObj.amount).toFixed(2));
          empAge.push(dataObj.monthAndYear);
        }
        setChartData({
          labels: empAge,
          datasets: [
            {
              label: "Balance of every month",
              data: empSal,
              backgroundColor: 'rgb(201, 141, 21)',
              borderWidth: 4
            }
          ]
        });
      })
      .catch(err => {
        console.log(err);
      });
    console.log(empSal, empAge);
  };

  useEffect(() => {
    chart();
  }, []);
  return (
    <div className="App">
      <div>
        <Line
          data={chartData}
          width={100}
          height={50}
          options={{
            responsive: true,
            title: { text: "BALANCE EVERY MONTH", display: true },
            scales: {
              yAxes: [
                {
                  ticks: {
                    autoSkip: true,
                    maxTicksLimit: 5,
                    beginAtZero: true
                  },
                  gridLines: {
                    display: false
                  }
                }
              ],
              xAxes: [
                {
                  gridLines: {
                    display: false
                  }
                }
              ]
            }
          }}
        />
      </div>
    </div>
  );
};

export default Chart;