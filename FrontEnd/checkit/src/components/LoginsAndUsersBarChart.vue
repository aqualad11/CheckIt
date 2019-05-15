<script>
  //AXIOS WILL SPLIT 24 List into 2-12 Lists

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
              label: 'Logins',
              backgroundColor: '#66BB6A',
              //Data to be represented on y-axis
              data: [40, 20, 30, 50, 90, 10, 20, 40, 50, 70, 90, 100],
              borderWidth: 1
            },
            {
              label: 'Total Users',
              backgroundColor: '#006064',
              //Data to be represented on y-axis
              data: [20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130],
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