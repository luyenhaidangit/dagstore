

(function (app) {
    app.factory('dataTableService', dataTableService);

    // apiService.$inject = ['$http'];

    function dataTableService() {
        return {
            createDataTable: createDataTable,
            desTroyDataTable: desTroyDataTable,
            deleteRowDataTable: deleteRowDataTable,
            createDefaultDataTable: createDefaultDataTable,
        }

        function createDefaultDataTable(nameTable) {
            return $('#' + nameTable).DataTable();
        }

        function desTroyDataTable(nameTable) {
            $('#' + nameTable).DataTable().destroy();
        }

        function deleteRowDataTable(nameTable,indexRow) {
            var table = $('#' + nameTable).DataTable();
            table.row(indexRow).remove().draw();
        }
        
        function createDataTable(nameTable,columnTable) {          
            angular.element(document).ready(function() { 
                $.fn.dataTable.ext.errMode = 'none';

                var table = $('#' + nameTable).DataTable({
                  language: {
                    paginate: {
                        previous: "<i class='mdi mdi-chevron-left'>"
                        , next: "<i class='mdi mdi-chevron-right'>"
                    },
                    info: "Hiển thị từ _START_ đến _END_ trong _TOTAL_ bản ghi",
                    search : "Tìm kiếm",
                    infoEmpty : "Không tìm thấy bản ghi",
                    infoFiltered:"(Trong tổng số _MAX_ bản ghi)",
                    lengthMenu:"Hiển thị _MENU_ bản ghi",
                    },
                    drawCallback: function () {
                    $(".dataTables_paginate > .pagination")
                        .addClass("pagination-rounded")
                    },

                    buttons: [
                        { extend: 'colvis', className: 'btn btn-success waves-effect d-block w-100 text-left extension-button me-1', text: '<i class="fal fa-table"></i>' },
                    ],
                    'columnDefs': columnTable,
                });
                table.buttons()
                    .container()
                    .appendTo(".datatable-extension")

                $('li.toggle-vis').on('click', function (e) {
                    

                    // Get the column API object
                    var column = table.column($(this).attr('data-column'));

                    // Toggle the visibility
                    column.visible(!column.visible());

                    $(this).children("input").is(":checked") ? $(this).children("input").prop('checked', false) : $(this).children("input").prop('checked', true);
                    
                });

                //$('li.toggle-vis input').on('click', function (e) {

                //    /*e.preventDefault();*/

                //     /*Get the column API object*/
                //    var column = table.column($(this).attr('data-column'));

                //     /*Toggle the visibility*/
                //    column.visible(!column.visible());

                //    $(this).is(":checked") ? $(this).prop('checked', false) : $(this).prop('checked', true);

                //});
            });
        }
    }
})(angular.module('DAGStore.common'));