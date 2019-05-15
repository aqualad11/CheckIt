<script>
  import axios from 'axios'
  //Importing Bar class from the vue-chartjs wrapper
  import { Bar, mixins } from 'vue-chartjs'
  const API_URL = 'Backend'
  //Exporting this so it can be used in other components
  export default {
    extends: Bar,
    mixins: [mixins.reactiveData],
    data () {
      return {
        bardata: {},
        //Chart.js options that controls the appearance of the chart
        options: {
          title : {
            display : true,
            position : "top",
            text : "",
            fontSize : 18,
            fontColor : "#111"
        },
          legend: {
            display: true
          },
          responsive: true,
          maintainAspectRatio: false,
          scales : {
            yAxes : [{
            ticks : {
            min : 0
            }
            }]
          }
        }
      }
    },
    created () {
      axios.get(API_URL + "/api/admin/GetChart" ,{
          params:{
          chartName: 'AverageSessionBarChart',
        } ,
        headers: {
          token: this.userToken
        }
        }).then(response => {
          this.bardata = {
            labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
            datasets: [
            {
              label: 'Minimum Time',
              backgroundColor: '#EF5350',
              //Data to be represented on y-axis
              data: response.data.slice(0,12),
              borderWidth: 1
            },
            {
              label: 'Average Time',
              backgroundColor: '#0277BD',
              //Data to be represented on y-axis
              data: response.data.slice(12,24),
              borderWidth: 1
            },
            {
              label: 'Maximum Time',
              backgroundColor: '#66BB6A',
              //Data to be represented on y-axis
              data: response.data.slice(24,36),
              borderWidth: 1
            }
            ]
        },
        //renderChart function renders the chart with the datacollection and options object.
        this.renderChart(this.bardata, this.options)
        })
    }
  }
</script>