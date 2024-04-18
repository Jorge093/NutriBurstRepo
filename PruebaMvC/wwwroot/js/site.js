// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
$(document).ready(function () {
    function filterTable() {
        var searchText = $('#filterInput').val().toLowerCase();
        $('#table1 tbody tr').each(function () {
            var text = $(this).text().toLowerCase();
            if (text.includes(searchText) || searchText === '') {
                $(this).show();
            } else {
                $(this).hide();
            }
        });
    }

    $('#filterInput').on('input', filterTable);
});