<script>
  //Importing Bar class from the vue-chartjs wrapper
  import { Bar } from 'vue-chartjs'
  //Exporting this so it can be used in other components
  export default {
    extends: Bar,
    data () {
      return {
        bardata: {
            labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
            datasets: [
            {
              label: 'Minimum Time',
              backgroundColor: '#EF5350',
              //Data to be represented on y-axis
              data: [25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25],
              borderWidth: 1
            },
            {
              label: 'Average Time',
              backgroundColor: '#0277BD',
              //Data to be represented on y-axis
              data: [50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50],
              borderWidth: 1
            },
            {
              label: 'Maximum Time',
              backgroundColor: '#66BB6A',
              //Data to be represented on y-axis
              data: [75, 75, 75, 75, 75, 75, 75, 75, 75, 75, 75, 75],
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
      }
    },
    mounted () {
      //renderChart function renders the chart with the datacollection and options object.
      this.renderChart(this.bardata, this.options)
    }
  }
</script>