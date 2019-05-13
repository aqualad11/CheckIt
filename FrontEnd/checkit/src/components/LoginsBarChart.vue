<script>
  import axios from 'axios'
  //Importing Bar class from the vue-chartjs wrapper
  import { Bar } from 'vue-chartjs'
  const API_URL = 'http://localhost:58881'
  //Exporting this so it can be used in other components
  export default {
    extends: Bar,
    data () {
      return {
        bardata: {
            labels: ['Failed', 'Successful', 'Total'],
            datasets: [
            {
              label: 'Attempts',
              backgroundColor: '#455A64',
              //Data to be represented on y-axis
              data: [],
              borderWidth: 1
            }
            ]
        },
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
      };
    },
    mounted () {
      //renderChart function renders the chart with the datacollection and options object.
      this.renderChart(this.bardata, this.options)
    },
    methods: {
      getLoginData(){
        axios.get(API_URL + "/api/admin/GetChart" ,{
          params:{
          chartName: 'LoginsBarChart',
          userToken: this.userToken,
        } ,
        headers: {
          token: this.userToken
        }
        }).then(response => {
          this.bardata.datasets.data = response.data
          this.renderChart(this.bardata, this.options)
          console.log(response.data)
          console.alert('Hello')
        })          
      }
    }
  }
</script>