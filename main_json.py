import csv, json, re

with open('productos.csv', 'r', encoding='utf-8-sig') as osinfo:
    c = csv.reader(osinfo)

    ww_filter = []

    for row in c:
        if re.search('Wonderware', row[0]):
            ww_filter.append(row)

    with open('wwProductOs.csv', 'w', newline='') as wwinfo:
        cw = csv.writer(wwinfo)

        for e in ww_filter:
            e[0] = e[0].replace('Wonderware', '').strip()
            cw.writerow(e)

os_dict = {}

with open('wwProductOs.csv', 'r') as csv_json:
    c = csv.reader(csv_json)

    for row in c:
        if row[0] not in os_dict.keys():
            os_dict[row[0]] = {'OS' : []}
        
        else:
            os_dict[row[0]]['OS'].append(row[1])

with open('productOs.json', 'w') as outfile:
    json.dump(os_dict, outfile)

