import csv, sqlite3, re

with open('productos.csv', 'r') as osinfo:
    c = csv.reader(osinfo)

    ww_filter = []

    for row in c:
        if re.search('Wonderware', row[0]):
            ww_filter.append(row)

    with open('wwProductOs.csv', 'w', newline='') as wwinfo:
        cw = csv.writer(wwinfo)

        for e in ww_filter:
            cw.writerow(e)

conn = sqlite3.connect('wwinfo.sqlite')
cursor = conn.cursor()
cursor.execute('CREATE TABLE osInfo (product varchar(255), os varchar(255))')
conn.commit()

with open('wwProductOs.csv', 'r', encoding='utf-8-sig') as passDb:
    c = csv.reader(passDb)
    for row in c:
        cursor.execute(f'INSERT INTO osInfo(product, os) values(?, ?)', [row[0], row[1]])
conn.commit()
conn.close()
