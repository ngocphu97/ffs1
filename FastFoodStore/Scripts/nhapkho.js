function delete_row(id) {
    $.ajax
        ({
            type: 'post',
            url: 'modify_records.php',
            data: {
                delete_row: 'delete_row',
                row_id: id,
            },
            success: function (response) {
                if (response == "success") {
                    var row = document.getElementById("row" + id);
                    row.parentNode.removeChild(row);
                }
            }
        });
}

function insert_row() {
    var stt = document.getElementById("new_id").value;
    var name = document.getElementById("new_name").value;
    var dvt = document.getElementById("new_dvt").value;
    var sl = document.getElementById("new_sl").value;
    var dg = document.getElementById("new_dg").value;
    var tt = document.getElementById("new_tt").value;

    $.ajax
        ({
            type: 'post',
            url: 'Add',
            data: {
                insert_row: 'insert_row',
                stt_val: stt,
                name_val: name,
                dvt_val: dvt,
                sl_val: sl,
                dg_val: dg,
                tt_val: tt
            },
            success: function (response) {
                if (response != "") {
                    var id = response;
                    var table = document.getElementById("user_table");
                    var table_len = (table.rows.length) - 1;

                    var row = table.insertRow(table_len).outerHTML =
                        "<tr id='row" + id + "'><td id='stt_val" + id + "'>" + stt+ "</td><td id='name_val" + id + "'>" + name+ "</td><td id='dvt_val" + id + "'>" + dvt+ "</td><td id='sl_val" + id + "'>" + sl+ "</td><td id='dg_val" + id + "'>" + dg+ "</td><td id='tt_val" + id + "'>" + tt + "</td><td><input type='button' class='delete_button' id='delete_button" + id+ "' value='delete' onclick='delete_row(" + id + ");'/></td></tr>";

                    document.getElementById("new_id").value = "";
                    document.getElementById("new_name").value = "";
                    document.getElementById("new_dvt").value = "";
                    document.getElementById("new_sl").value = "";
                    document.getElementById("new_dg").value = "";
                    document.getElementById("new_tt").value = "";

                }
            }
        });
}