<script>
  //Importing Bar class from the vue-chartjs wrapper
  import { Bar, mixins } from 'vue-chartjs'
  import axios from 'axios'
  const API_URL = 'http://localhost:58881'

  //Exporting this so it can be used in other components
  export default {
    extends: Bar,
    mixins: [mixins.reactiveData],
    data () {
      return {
        bardata: {},
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
    created() {
      axios.get(API_URL + "/api/admin/GetChart" ,{
          params:{
          chartName: 'TopFiveFeaturesBarChart',
        } ,
        headers: {
          token: this.userToken
        }
        }).then(response => {
          this.bardata = {
          //Data to be represented on x-axis
          labels: ['Search', 'Watchlist', 'Profile', 'Admin Dashboard', 'View Items'],
          datasets: [
            {
              label: 'Times Feature Used',
              backgroundColor: '#EF6C00',
              pointBackgroundColor: 'white',
              borderWidth: 1,
              pointBorderColor: '#249EBF',
              //Data to be represented on y-axis
              data: response.data
            }
          ]
        },
        this.renderChart(this.bardata, this.options)
    })
  }
  }
</script>