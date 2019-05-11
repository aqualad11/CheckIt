<template>
  <section class="container">
    <h1>Usage Analysis Dashboard</h1>
    <div class="Chart">
      <div class="column">
        <h3>Time Spent Per Page</h3>
        <time-per-page-bar-chart></time-per-page-bar-chart>
      </div>
      <div class="column">
        <h3>Logins vs Failures</h3>
        <failed-and-successful-login-bar-chart></failed-and-successful-login-bar-chart>
      </div>
      <div class="column">
        <h3>Logins vs Total Users</h3>
        <logins-and-users-bar-chart></logins-and-users-bar-chart>
      </div>
      <div class="column">
        <h3>Top Feature Popularity</h3>
        <top-five-features-bar-chart></top-five-features-bar-chart>
      </div>
      <div class="column">
        <h3>Average Session Times</h3>
        <average-session-bar-chart></average-session-bar-chart>
      </div>
      <div class="column">
        <h3>Average Session Times</h3>
        <average-session-line-chart></average-session-line-chart>
      </div>
      <div class="column">
        <h3>Logged-In Users</h3>
        <average-logged-in-users-line-chart></average-logged-in-users-line-chart>
      </div>
    </div>
  </section>
</template>
<script>
  import TimePerPageBarChart from '@/components/TimePerPageBarChart.vue'
  import FailedAndSuccessfulLoginBarChart from '@/components/FailedAndSuccessfulLoginBarChart.vue'
  import LoginsAndUsersBarChart from '@/components/LoginsAndUsersBarChart.vue'
  import TopFiveFeaturesBarChart from '@/components/TopFiveFeaturesBarChart.vue'
  import AverageSessionBarChart from '@/components/AverageSessionBarChart.vue'
  import AverageSessionLineChart from '@/components/AverageSessionLineChart.vue'
  import AverageLoggedInUsersLineChart from '@/components/AverageLoggedInUsersLineChart.vue'

  export default {
    name: 'VueChartJS',
    components: {
      // Bar Chart 
        TimePerPageBarChart,
        FailedAndSuccessfulLoginBarChart,
        LoginsAndUsersBarChart,
        TopFiveFeaturesBarChart,
        AverageSessionBarChart,
        AverageSessionLineChart,
        AverageLoggedInUsersLineChart
    }
  }
</script>

<style>
.dashboard h1 {
  font-size: 50px;
  color:#000000;
  margin: auto;
  margin-left: 20px;
  padding: 15px 0;
}
.Chart {
  background:white;
  border-radius: 15px;
  box-shadow: 0px 2px 15px rgba(25, 25, 25, 0.27);
  margin:  25px 0;
  
}
.Chart h3 {
  margin-top: 0;
  margin-left: 20px;
  padding: 15px 0;
  font-size:20px;
  color:  hsl(147, 96%, 38%);
  border-bottom: 1px solid #323d54;
}
</style>