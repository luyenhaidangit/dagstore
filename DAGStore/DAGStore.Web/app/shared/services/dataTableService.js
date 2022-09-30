

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
        
        function createDataTable(nameTable) {          
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
                        { extend: 'copy', className: 'btn btn-outline-light waves-effect d-block w-100 text-left', text: '<i class="fas fa-copy mr-2"></i>Copy' },
                        { extend: 'excel', className: 'btn btn-outline-light waves-effect d-block w-100 text-left', text: '<i class="fas fa-file-csv mr-2"></i>Excel' },
                        { extend: 'pdf', className: 'btn btn-outline-light waves-effect d-block w-100 text-left', text: '<i class="fas fa-file-pdf mr-2"></i>PDF' },      
                    ],  
                });
                table.buttons()
                    .container()
                    .appendTo(".group-btn-export")
            });
        }
    }
})(angular.module('DAGStore.common'));