class Dashing.Number extends Dashing.Widget
  @accessor 'current', Dashing.AnimatedValue

  @accessor 'difference', ->
    if @get('last')
      last = parseInt(@get('last'))
      current = parseInt(@get('current'))
      if last != 0
        diff = Math.abs(Math.round((current - last) / last * 100))
        "#{diff}%"
    else
      ""

  @accessor 'arrow', ->
    if @get('last')
      arrow_direction = 'right'
      if parseInt(@get('current')) > parseInt(@get('last'))
        arrow_direction ='up' 
      else if parseInt(@get('current')) < parseInt(@get('last'))
        arrow_direction = 'down'
      return 'fa fa-arrow-' + arrow_direction 