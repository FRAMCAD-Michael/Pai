$(document).ready(function () {
    var drawChart = function (info) {
        var width = 600;
        var height = 1200;
        var tt = info;
            var canvas = d3.select(".chart").append("svg")
            .attr("width", 500)
            .attr("height", 500)
            canvas.selectAll("rect")
            .data(tt)
            .enter()
            .append("rect")
            .attr("width", function (d) { return d.value * 2; })
            .attr("height", 10)
            .attr("y", function (d, i) { return i * 12; })
            .attr("fill", "blue");

            //canvas.selectAll("text")
            //.data(data)
            //.append("text")
            //.attr("fill", "white")

    };



    //Retrieve data from 
    var retrieveChartData = function () {
        var projectId = $(this).attr('id');
        var options = {
            url: "/Home/SurveyInfo",
            data: { 'id': projectId },
            type: "GET",
        };
        $.ajax(options).done(function (data) {
            //var items = [];//Need to use array
            //$.each(data, function (key, val) {
            //    items.push(val);
            //});
            $(".table tr").each(function () {
                $(this).attr("class", "");
            });
            $('#' + projectId).attr("class", "active");
            $(".chart").empty();
            $(".chart").fadeOut(10);
            $(".chart").fadeIn(200);
            data = [
  { name: "Locke", value: 4 },
  { name: "Reyes", value: 8 },
  { name: "Ford", value: 43},
  { name: "Jarrah", value: 16 },
  { name: "Shephard", value: 23 },
  { name: "Kwon", value: 42 }
            ];
            drawChart(data);
        });

    };


    //Event after clicking a table row
    $("#project_table tbody tr").on("click", retrieveChartData);
});