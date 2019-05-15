<script>
  import axios from 'axios'
  //Importing Line class from the vue-chartjs wrapper
  import { Line, mixins } from 'vue-chartjs'
  const API_URL = 'Backend'
  //Exporting this so it can be used in other components
  export default {
    extends: Line,
    mixins: [mixins.reactiveData],
    data () {
      return {
        linedata: {},
        //Chart.js options that controls the appearance of the chart
        options: {
          scales: {
            yAxes: [{
              ticks: {
                beginAtZero: true
              },
              gridLines: {
                display: true
              }
            }],
            xAxes: [ {
              gridLines: {
                display: false
              }
            }]
          },
          legend: {
            display: true
          },
          responsive: true,
          maintainAspectRatio: false
        }
      }
    },
    created () {
      axios.get(API_URL + "/api/admin/GetChart" ,{
          params:{
          chartName: 'AverageSessionLineChart',
        } ,
        headers: {
          token: this.userToken
        }
      }).then(response =>{
          this.linedata=  {
              //Data to be represented on x-axis
              labels: ['January', 'February', 'March', 'April', 'May', 'June'],
              datasets: [
                {
                  label: 'Session Minutes',
                  backgroundColor: '#00897B',
                  pointBackgroundColor: 'white',
                  borderWidth: 1,
                  pointBorderColor: '#249EBF',
                  //Data to be represented on y-axis
                  data: response.data
                }
                ]
            },
            //renderChart function renders the chart with the datacollection and options object.
            this.renderChart(this.linedata, this.options)
      })
    }
  }
</script>