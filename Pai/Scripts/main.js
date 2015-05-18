$(document).ready(function () {

    var drawChart = function (data) {
        var width = 960,
            height = 500;

        var x = d3.scale.ordinal()
            .rangeRoundBands([0, width], .1);

        var y = d3.scale.linear()
            .range([height, 0]);

        var chart = d3.select(".chart")
            .attr("width", width)
            .attr("height", height);

        d3.tsv(data, type, function(error, data) {
            x.domain(data.map(function(d) { return d.name; }));
            y.domain([0, d3.max(data, function(d) { return d.value; })]);

            var bar = chart.selectAll("g")
                .data(data)
              .enter().append("g")
                .attr("transform", function(d) { return "translate(" + x(d.name) + ",0)"; });

            bar.append("rect")
                .attr("y", function(d) { return y(d.value); })
                .attr("height", function(d) { return height - y(d.value); })
                .attr("width", x.rangeBand());

            bar.append("text")
                .attr("x", x.rangeBand() / 2)
                .attr("y", function(d) { return y(d.value) + 3; })
                .attr("dy", ".75em")
                .text(function(d) { return d.value; });
        });

        function type(d) {
            d.value = +d.value; // coerce to number
            return d;
        }


    //Retrieve data from 
    var retrieveChartData = function () {
        var projectId = $(this).attr('id');
        var options = {
            url: "/Home/SurveyInfo",
            data: { 'id': projectId },
            type: "GET",
        };
        $.ajax(options).done(function (data) {
            var items = [];//Need to use array
            $.each(data, function (key, val) {
                items.push(val);
            });
           
            $(".table tr").each(function () {
                $(this).attr("class", "");
            });
            $('#' + projectId).attr("class", "active");
            $(".chart").empty();
            $(".chart").fadeOut(10);
            $(".chart").fadeIn(200);
            drawChart(items);
        });

    };


    //Event after clicking a table row
    $("#project_table tbody tr").on("click", retrieveChartData);
});