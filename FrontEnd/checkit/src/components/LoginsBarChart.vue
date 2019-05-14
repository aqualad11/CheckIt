<script>
  import axios from 'axios'
  //Importing Bar class from the vue-chartjs wrapper
  import { Bar, mixins } from 'vue-chartjs'
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
    created() {
        axios.get(API_URL + "/api/admin/GetChart" ,{
          params:{
          chartName: 'LoginsBarChart',
        } ,
        headers: {
          token: this.userToken
        }
        }).then(response => {
          this.bardata = {
              labels: ['Failed', 'Successful', 'Total'],
              datasets: [
              {
                label: 'Attempts',
                backgroundColor: '#455A64',
                //Data to be represented on y-axis
                data: response.data,
                borderWidth: 1
              }
              ]
            },
            //console.log(this.bardata)
            this.renderChart(this.bardata, this.options)

        })          
      }
  }
</script>