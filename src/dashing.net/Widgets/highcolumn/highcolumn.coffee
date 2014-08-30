class Dashing.Highcolumn extends Dashing.Widget

  createChart: (series, categories, color) ->
    container = $(@node).find('.highchart-container')
    if $(container)[0]
      @chart = new Highcharts.Chart(
        chart:
          renderTo: $(container)[0]
          type: "column"
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
          column:
            stacking: 'normal',
            borderWidth: 0
      )

  onData: (data) ->
    @createChart(data.series, data.categories, data.color)
