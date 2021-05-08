//----------------------------------------------------------------搜索
$(document).ready(function () {
    $("#myInput").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#myTable tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
        });
    });
});



//--------------------------------------------------------------排序
th = document.getElementsByTagName('th');

for (var t = 0; t < th.length; t++) {
    th[t].addEventListener('click', item(t));
};

asc = true;

function item(t) {
    return function () {
        asc = !asc;
        sortTable(t);
    }
}

function sortTable(t) {
    var table, rows, switching, i, x, y, shouldSwitch;
    table = document.getElementById("myTable");
    switching = true;
    if (asc) {
        /*Make a loop that will continue until
    no switching has been done:*/
        while (switching) {
            // start by saying: no switching is done:
            switching = false;
            rows = table.rows;
            /*Loop through all table rows (except the
            first, which contains table headers):*/
            for (i = 0; i < (rows.length - 1); i++) {
                //  start by saying there should be no switching:
                shouldSwitch = false;
                /*Get the two elements you want to compare,
                one from current row and one from the next:*/
                x = rows[i].getElementsByTagName("TD")[t];
                y = rows[i + 1].getElementsByTagName("TD")[t];
                // check if the two rows should switch place:

                if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                    //  if so, mark as a switch and break the loop:
                    shouldSwitch = true;
                    break;
                }
            }
            if (shouldSwitch) {
                /*If a switch has been marked, make the switch
                and mark that a switch has been done:*/
                rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
                switching = true;
            }
        }
    }
    else {
        /*Make a loop that will continue until
    no switching has been done:*/
        while (switching) {
            // start by saying: no switching is done:
            switching = false;
            rows = table.rows;
            /*Loop through all table rows (except the
            first, which contains table headers):*/
            for (i = 0; i < (rows.length - 1); i++) {
                // start by saying there should be no switching:
                shouldSwitch = false;
                /*Get the two elements you want to compare,
                one from current row and one from the next:*/
                x = rows[i].getElementsByTagName("TD")[t];
                y = rows[i + 1].getElementsByTagName("TD")[t];
                //check if the two rows should switch place:

                if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
                    //  if so, mark as a switch and break the loop:
                    shouldSwitch = true;
                    break;
                }
            }
            if (shouldSwitch) {
                /*If a switch has been marked, make the switch
                and mark that a switch has been done:*/
                rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
                switching = true;
            }
        }
    }
}


//--------------------------------------------------保存为excel------------------

<button id="btn">保存为excel</button>

    <script src="~/Content/jquery.min.js"></script>
    <script src="~/Content/table2excel.js"></script>

<script>
    //export to excel
    $('#btn').click(function () {
        $('#myTable').table2excel({
            filename: $('#d1').val() + '@title'
        });
    });
</script>
