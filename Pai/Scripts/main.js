$(document).ready(function () {

    var w = 600,
                h = 400,
                z = d3.scale.category20b(),
                i = 0;

    var svg = d3.select("body").append("svg:svg")
        .attr("width", w)
        .attr("height", h)
        .on("mousemove", particle);

    function particle() {
        var m = d3.mouse(this);

        svg.append("svg:rect")
            .attr("x", m[0] - 10)
            .attr("y", m[1] - 10)
            .attr("height", 20)
            .attr("width", 20)
            .attr("rx", 10)
            .attr("ry", 10)
            .style("stroke", z(++i))
            .style("stroke-opacity", 1)
            .style("opacity", 0.7)
          .transition()
            .duration(5000)
            .ease(Math.sqrt)
            .attr("x", m[0] - 100)
            .attr("y", m[1] - 100)
            .attr("height", 200)
            .attr("width", 200)
            .style("stroke-opacity", 1e-6)
            .style("opacity", 1e-6)
            .remove();
    }

    //Retrieve data from 
    var retrieveChartData = function () {
        var projectId = $(this).attr('id');
        var options = {
            url: "/Home/SurveyInfo",
            data: {'id':projectId},
            type: "GET",
        };
        $.ajax(options).done(function (data) {
            var outinfo ="gmail";
            $.each(data, function (key, val) {
                outinfo =val;

            });
            //alert(outinfo);
            
});

    };


    //Event after clicking a table row
    $("#project_table tbody tr").on("click", retrieveChartData);
});