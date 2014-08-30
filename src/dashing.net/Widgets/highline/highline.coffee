class Dashing.Highline extends Dashing.Widget

  createChart: (series, categories, color) ->
    container = $(@node).find('.highchart-container')
    if $(container)[0] != null
      @chart = new Highcharts.Chart(
        chart:
          renderTo: $(container)[0]
          type: "line"
          backgroundColor: color
          marginTop: 2

        title:
          text: ' '

        xAxis:
          categories: categories

        yAxis:
          title:
            enabled: false

        legend:
          enabled: false

        series: series

        plotOptions:
          line:
            lineWidth: 4
            marker:
              enabled: false
      )  

  onData: (data) ->
    @createChart(data.series, data.categories, data.color)
