import random

# name
# contact
# logo
import string


def generateOrgNames(number):
    emailDomains = ["hotmail.com", "gmail.com", "aol.com", "mail.com", "mail.kz", "yahoo.com", "ua.pt"]
    extensions = ['.com', '.org', '.gg']
    alpha = list(string.ascii_letters)
    digit = list(string.digits)
    special = ['.', '-', '_']
    letters = alpha + digit + special

    def get_one_random_name():
        email_name = ''.join(random.choice(alpha))
        for i in range(random.randint(0, 22)):
            gen = random.choice(letters)
            if not (gen in special and email_name[-1] in special):
                email_name = email_name + random.choice(letters)
        if email_name[-1] in special:
            email_name = email_name[:-1]
        return email_name

    orgs = []
    emails = []
    with open('orgs.txt', 'r', encoding='utf8') as f:
        for org in f:
            data = org.strip().replace('\n', '')
            if len(data) <= 25:
                orgs.append(data)
                decider = random.randint(0, 100)
                if decider > 75:
                    emails.append(str(get_one_random_name() + '@' + random.choice(emailDomains)))
                elif decider > 20:
                    emails.append(str(get_one_random_name() + '@' + data.replace(' ', '') + random.choice(extensions)))

    return random.sample(list(set(orgs)), number), random.sample(list(set(emails)), number)

def generateRandomLogo(number) -> list:
    lst = []
    logos = ['https://images.crowdspring.com/blog/wp-content/uploads/2019/06/27130108/800px-chanel_logo_interlocking_cs.svg_.png',
             'https://1000logos.net/wp-content/uploads/2021/11/logo-Pepsi.png',
             'https://www.creativefabrica.com/wp-content/uploads/2021/05/09/Cleaning-Company-Logo-Graphics-11862916-2-580x387.png',
             'https://www.zilliondesigns.com/images/portfolio/construction-company/Construction-Company-Logo-1356919.png',
             'https://helios-i.mashable.com/imagery/articles/057j8wdpMlBCEcPRqiVe4DY/images-2.fit_lim.size_2000x.v1619018990.png',
             'https://brandlogos.net/wp-content/uploads/2022/05/instagram-2022-logo_brandlogos.net_kamyn-512x512.png',
             'https://www.jetpunk.com/img/user-photo-library/38/38a12fe9c0-450.png',
             'https://cdn.logojoy.com/wp-content/uploads/2018/08/23162125/apple-logo-1024x728.png',
             'https://www.newdesigngroup.ca/ndgcnt/uploads/2014/11/1280px-Intel-logo.svg_.png',
             'https://brandlogos.net/wp-content/uploads/2022/03/panda_express-logo-brandlogos.net_-512x512.png',
             'https://bcassetcdn.com/public/blog/wp-content/uploads/2021/11/30150053/Tide_Logo-1024x1024.png',
             'https://www.logodesign.net/images/tutorials/famous-logos-fun-facts/logos-60.png',
             'https://logospng.org/download/the-walt-disney-company/logo-disney-512.png',
             'https://s3.eu-west-1.amazonaws.com/niice-cms/2020/08/06/5f2b4873c0102Xbox_Game_Studios-Logo.wine.png',
             'https://www.lmsa.pt/wp-content/uploads/sites/3/2020/10/logo_clientes_lmsa_0006_stone.png',
             'https://logosmarcas.net/wp-content/uploads/2020/05/NASA-Logo-650x366.png',
             'https://upload.wikimedia.org/wikipedia/commons/thumb/2/2f/ABC-2021-LOGO.svg/1200px-ABC-2021-LOGO.svg.png',
             'https://seeklogo.com/images/H/hewlett-packard-company-logo-4082756A03-seeklogo.com.png',
             'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTyo5ceW9XTS6vY50Z97kIUkSm772SuK66hHg&usqp=CAU',
             'https://www.carlogos.org/logo/Volkswagen-logo-2015-1920x1080.png',
             'https://www.smithfieldfoods.com/getmedia/5e4ec9f2-8e28-4cf0-978d-da735dac27e6/logo_armour.png',
             'https://www.carlogos.org/car-logos/nissan-logo-2013-700x700.png',
             'https://logos-world.net/wp-content/uploads/2020/04/Sony-Logo-1957-1961.png',
             'https://logodownload.org/wp-content/uploads/2018/03/drupal-logo-3.png',
             'https://irp.cdn-website.com/dfcfecfc/dms3rep/multi/AIM+Icon-a35c53b8.png',
             'https://1000logos.net/wp-content/uploads/2021/11/logo-Starbucks.png',
             'https://cdn.freebiesupply.com/images/thumbs/1x/apex-legends-logo.png',
             'https://logos-world.net/wp-content/uploads/2021/12/Motorola-Logo-700x394.png',
             'https://www.nestle.com/sites/default/files/asset-library/publishingimages/brands/chocolate-confectionery/kitkat-logo-round.png',
             'https://brandlogos.net/wp-content/uploads/2022/03/nvidia-logo-brandlogos.net_.png',
             'https://s3.amazonaws.com/cdn.designcrowd.com/blog/2017/April/35-Famous-Square-Logos/18_300.png',
             'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSDkDwIAIw-ktJlZV_PsjZbIeIgJG4SxST3Hg&usqp=CAU',
             'https://cdn.freebiesupply.com/logos/thumbs/1x/vans-3-logo.png',
             'https://cdn.logojoy.com/wp-content/uploads/20200805115535/olympic-rings-600x277.png',
             'https://marcas-logos.net/wp-content/uploads/2020/03/Electronic-Arts-Logo-2000.png',
             'https://www.visme.co/wp-content/uploads/2020/05/v_zuric.png',
             'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT2Z0_qkMPcJcEmiTw1EheNwCw84qF8gJ09QA&usqp=CAU',
             'https://www.designwizard.com/wp-content/uploads/2019/07/ferrari-ges-logo.png',
             'https://cdn.eslgaming.com/misc/media/es/prensa/logos/esl_2014_horizontal_dark.png',
             'https://liquipedia.net/commons/images/d/d2/BLASTLogo.png',
             'https://prowly-uploads.s3.eu-west-1.amazonaws.com/uploads/press_rooms/company_logos/11487/80529475ee925a1d22b1ebf033a33ae3.png'
             'https://egamersworld.com/uploads/tournaments/vct-2021-south-america-la1617094971551-logo.png'
             ]

    for i in range(0, number):
        decider = random.randint(0, 100)
        choice = random.choice(logos)
        if decider > 45 or len(choice) > 500:
            lst.append(None)
        else:
            lst.append(choice)

    return lst

def generateRandomOrgs(number) -> list[list]:

    orgs = []
    names, emails = generateOrgNames(number)
    logo = generateRandomLogo(number)

    for i in range(0, number):
        org = [names[i], emails[i], logo[i]]
        orgs.append(org)

    return orgs
