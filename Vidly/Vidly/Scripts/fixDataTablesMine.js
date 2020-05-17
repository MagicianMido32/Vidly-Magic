function fixDataTables() {
    //my own stuff , fix styling

    //navigation buttons ,didn't work when using ajax Api, I think datatables re-render them after the request is done
    //maybe think of a callback function that get's executed after the ajax call is done,Yup there's
    //https://datatables.net/reference/option/drawCallback

    /** on table draw
     *   $('#customers').on('draw.dt', function () {
                fixDataTables();
            });
     */

    /** draw callback , this fixes everything
     *  "drawCallback": function () {
                    alert('hmmm');
                    fixDataTables();
                }
                ==============

            $(document).ready(function () {
            var table = $("#tableMovies").DataTable({
                "drawCallback": function () {
                    alert('hmmm');
                    fixDataTables();
                }
            });
     */
    //1 2 3 .. buttons
    $(".paginate_button").addClass("btn btn-lg btn-default");

    //previous , next
    $(".paginate_button.previous,.paginate_button.next").addClass("btn btn-lg btn-primary");

    //fixing bootstrap oversize that I made
    $(".paginate_button.previous,.paginate_button.next,.paginate_button").css(
        {
            "padding": "2px 5px",
            "margin": "1px",
            "border-radius": "0px"
        });
    //making them round in the corners (previous
    //top left top right bottom left bottom right
    $(".paginate_button.previous").css(
        {
            "border-radius": "17px 0px 0px 17px"
        });
    ////making them round in the corners next)
    $(".paginate_button.next").css(
        {
            "border-radius": "0px 17px 17px 0px"
        });

    //search textbox , select list
    $(".dataTables_filter input[type='search'],.dataTables_length select").addClass("form-control");

    //still need to fix the table not responsive
    //the table is drawn by the size of the page, but it doesn't change it's size when window size is changed
    //wrap selectbox and textbox in a container to make them appear next to each others

    //    $(".dataTable").addClass("table table-bordered table-hover table-responsive");//not working
    //if , so as not to re wrap them each time the table is redrawn
    if (!$(".dataTables_filter,.dataTables_length").parent().hasClass('dwrapper')) {
        var wrapper = "<div class = 'dwrapper'></div>";
        $(".dataTables_filter,.dataTables_length").wrapAll(wrapper);
        $(".dwrapper").css({
            'display': 'flex',
            'justify-content': 'space-between',
            'align-items': 'center',
            'margin-top': '25px',
            'flex-wrap': 'wrap'
        });
    }
}