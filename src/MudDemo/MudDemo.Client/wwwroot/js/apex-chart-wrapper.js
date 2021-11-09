function apexChart(id, options) {
    
    var chart = new ApexCharts(document.querySelector("#" + id), options);
    chart.render();
}
    
