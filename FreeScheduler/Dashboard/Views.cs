﻿#if Dashboard

namespace FreeScheduler.Dashboard
{
	//private set 预留给外部设置
    public static class Views
    {
		public static string ClusterLog_list { get; private set; } = @"
<div class=""box"">
	<div class=""box-header with-border"">
		<h3 id=""box-title"" class=""box-title""></h3>
		<span class=""form-group mr15""></span><button class=""btn btn-success pull-right"" onclick=""top.downloadLog()"">下载日志</button>
	</div>
	<div class=""box-body"">
		<div class=""table-responsive"">
			<form id=""form_list"" action=""./del"" method=""post"">
				<input type=""hidden"" name=""__callback"" value=""del_callback""/>
				<table id=""GridView1"" cellspacing=""0"" rules=""all"" border=""1"" style=""border-collapse:collapse;"" class=""table table-bordered table-hover"">
					<tr>
						<th scope=""col"">时间</th>
						<th scope=""col"">集群Id</th>
						<th scope=""col"">集群名称</th>
						<th scope=""col"">内容</th>
					</tr>
					<tbody id=dto_list>
					</tbody>
				</table>
			</form>
			<div id=""kkpager""></div>
		</div>
	</div>
</div>

<script type=""text/javascript"">
	(function () {
var dto = {};
var sb = [];
for (var a = 0; a < dto.Logs.length; a++) {
	var log = dto.Logs[a];
	for(var b in log) if(log[b]==null)log[b]='';
	sb.push('<tr>\
								<td>' + log.CreateTime + '</td>\
								<td>' + log.ClusterId + '</td>\
								<td>' + log.ClusterName + '</td>\
								<td style=""overflow-wrap: break-word;word-break: break-all;"">' + log.Message + '</td>\
                            </tr>');
}
if (sb.length > 0) $('#dto_list').html(sb);

		top.downloadLog = function() {
			var line = prompt('请输入日志行数...');
			if (typeof(line) == 'string' && cint(line) > 0) {
				var dqs = _clone(top.mainViewNav.query);
				dqs.paxrefersh = new Date().getTime();
				dqs.download = 1;
				delete dqs.page;
				dqs.limit = line;
				var act = top.mainViewNav.trans('?' + qs_stringify(dqs));
				window.open(act);
			} else {
				alert('标签名输入错误.')
			}
		};
		top.del_callback = function(rt) {
			if (rt.code == 0) return top.mainViewNav.goto('./?' + new Date().getTime());
			alert(rt.message);
		};

		var qs = _clone(top.mainViewNav.query);
		var page = cint(qs.page, 1);
		delete qs.page;
		$('#kkpager').html(cms2Pager(dto.Total, page, 20, qs, 'page'));
		var fqs = _clone(top.mainViewNav.query);
		delete fqs.page;
		var fsc = [
			null
		];
		fsc.pop();
		cms2Filter(fsc, fqs);
		top.mainViewInit();
	})();
</script>
";

        public static string TaskLog_list { get; private set; } = @"
<div class=""box"">
	<div class=""box-header with-border"">
		<h3 id=""box-title"" class=""box-title""></h3>
		<span class=""form-group mr15""></span><button class=""btn btn-success pull-right"" onclick=""top.downloadLog()"">下载日志</button>
	</div>
	<div class=""box-body"">
		<div class=""table-responsive"">
			<form id=""form_list"" action=""./del"" method=""post"">
				<input type=""hidden"" name=""__callback"" value=""del_callback""/>
				<table id=""GridView1"" cellspacing=""0"" rules=""all"" border=""1"" style=""border-collapse:collapse;"" class=""table table-bordered table-hover"">
					<tr>
						<th scope=""col"">任务编号</th>
						<th scope=""col"" class=""text-right"">第几轮</th>
						<th scope=""col"" class=""text-right"">耗时</th>
						<th scope=""col"" class=""text-center"">是否成功</th>
						<th scope=""col"">异常信息</th>
						<th scope=""col"">备注</th>
						<th scope=""col"">创建时间</th>
					</tr>
					<tbody id=dto_list>
					</tbody>
				</table>
			</form>
			<div id=""kkpager""></div>
		</div>
	</div>
</div>

<script type=""text/javascript"">
	(function () {

function htmlEncode(html){
    var temp = document.createElement (""div"");
    (temp.textContent != undefined ) ? (temp.textContent = html) : (temp.innerText = html);
    var output = temp.innerHTML;
    temp = null;
    return output;
}
var dto = {};
var sb = [];
for (var a = 0; a < dto.Logs.length; a++) {
	var log = dto.Logs[a];
	for(var b in log) if(log[b]==null)log[b]='';
	sb.push('<tr>\
								<td>' + log.TaskId + '</td>\
								<td class=""text-right"">' + log.Round + '</td>\
								<td class=""text-right"">' + log.ElapsedMilliseconds + 'ms</td>\
								<td class=""text-center"">' + (log.Success ? '<font color=green>是</font>' : '<font color=red>否</font>') + '</td>\
								<td style=""overflow-wrap: break-word;word-break: break-all;"">' + log.Exception + '</td>\
								<td style=""overflow-wrap: break-word;word-break: break-all;"">' + htmlEncode(log.Remark) + '</td>\
								<td>' + log.CreateTime + '</td>\
                            </tr>');
}
if (sb.length > 0) $('#dto_list').html(sb);

		top.downloadLog = function() {
			var line = prompt('请输入日志行数...');
			if (typeof(line) == 'string' && cint(line) > 0) {
				var dqs = _clone(top.mainViewNav.query);
				dqs.paxrefersh = new Date().getTime();
				dqs.download = 1;
				delete dqs.page;
				dqs.limit = line;
				var act = top.mainViewNav.trans('?' + qs_stringify(dqs));
				window.open(act);
			} else {
				alert('标签名输入错误.')
			}
		};
		top.del_callback = function(rt) {
			if (rt.code == 0) return top.mainViewNav.goto('./?' + new Date().getTime());
			alert(rt.message);
		};

		var qs = _clone(top.mainViewNav.query);
		var page = cint(qs.page, 1);
		delete qs.page;
		$('#kkpager').html(cms2Pager(dto.Total, page, 20, qs, 'page'));
		var fqs = _clone(top.mainViewNav.query);
		delete fqs.page;
		var fsc = [
			null
		];
		fsc.pop();
		cms2Filter(fsc, fqs);
		top.mainViewInit();
	})();
</script>
";

        public static string TaskInfo_list { get; private set; } = @"
<div class=""box"">
	<div class=""box-header with-border"">
		<h3 id=""box-title"" class=""box-title""></h3> （<span id=dto_Description></span>）
		<span class=""form-group mr15""></span><a href=""./add"" data-toggle=""modal"" class=""btn btn-success pull-right"">添加</a>
	</div>
	<div class=""box-body"">
		<div class=""table-responsive"">
			<form id=""form_search"">
				<div id=""div_filter""></div>
			</form>
			<div style=""line-height:36px;border-bottom:1px solid #ddd;word-wrap:break-word;word-break:break-all;"">
				<div style=""float:left;width:70px;"">标题</div>
				<div style=""float:left;width:80%"">
					<input id=topic_1 type=""text"" placeholder=""按【标题】搜索""
						onkeyup=""if(event.keyCode==13)top.searchByTopic();"" 
						style=""font-size:16px;padding:0 9px 0 9px;margin:0;height:32px"" />
				</div>
				<div style=""clear:both;""></div>
			</div>
			<div style=""line-height:36px;border-bottom:1px solid #ddd;word-wrap:break-word;word-break:break-all;"">
				<div style=""float:left;width:70px;"">创建时间</div>
				<div style=""float:left;width:80%"">
					<input id=createtime_1 type=""text"" value=""2020-01-01"" 
						onkeyup=""if(event.keyCode==13)top.searchByCreateTime();"" 
						style=""font-size:16px;padding:0 9px 0 9px;margin:0;height:32px"" />
					至
					<input id=createtime_2 type=""text"" value=""2023-11-11""
						onkeyup=""if(event.keyCode==13)top.searchByCreateTime();"" 
						style=""font-size:16px;padding:0 9px 0 9px;margin:0;height:32px"" />
				</div>
				<div style=""clear:both;""></div>
			</div>
			<form id=""form_list"" action=""./del"" method=""post"">
				<input type=""hidden"" name=""__callback"" value=""del_callback""/>
				<table id=""GridView1"" cellspacing=""0"" rules=""all"" border=""1"" style=""border-collapse:collapse;"" class=""table table-bordered table-hover"">
					<tr>
						<th scope=""col"">操作</th>
						<th scope=""col"">编号</th>
						<th scope=""col"">标题</th>
						<th scope=""col"">定时</th>
						<th scope=""col"" class=""text-right"">轮次</th>
						<th scope=""col"">状态</th>
						<th scope=""col"">Body</th>
						<th scope=""col"">创建时间</th>
						<th scope=""col"">最后运行时间</th>
						<th scope=""col"">下次运行时间</th>
						<th scope=""col"">错次数</th>
					</tr>
					<tbody id=dto_list>
					</tbody>
				</table>
			</form>
			<div id=""kkpager""></div>
		</div>
	</div>
</div>

<script type=""text/javascript"">
	(function () {
var dto = {};
$('#dto_Description').html(dto.Description.replace(/存储\: (FreeSql|Redis)/, '存储: $1 <a href=""./add?tasktpl=2"">数据太多如何清理？</a>'));
var fscClusterText = [];
var fscClusterValue = [];
for (var a = 0; dto.Clusters != null && a < dto.Clusters.length; a++) {
    var cluster = dto.Clusters[a];
	var name = cluster.Name;
	if (name == null || name == '') name = cluster.Id;
    if (dto.Timestamp - cluster.Heartbeat < 10) name = name + '(' + cluster.TaskCount + ')';
    else if (dto.Timestamp - cluster.Heartbeat < 30) name = '<font color=red>' + name + '(' + cluster.TaskCount + ')[可能离线]</font>';
	else name = '<font color=red>' + name + '(' + cluster.TaskCount + ')[离线]</font>';
	fscClusterText.push(name);
	fscClusterValue.push(cluster.Id);
}
var sb = [];
for (var a = 0; a < dto.Tasks.length; a++) {
	var task = dto.Tasks[a];
	for(var b in task) if(task[b]==null)task[b]='';
	sb.push('<tr>\
								<td class=""text-nowrap"">\
									<input type=""button"" class=""btn btn-xs btn-danger"" value=""删除"" onclick=""if (confirm(\'确认删除吗？\')) top.callTask(\'delete\', \'' + task.Id + '\')"" /> \
' + (function() {
	if (task.Status == 2 || task.Status == 'Completed') return '';
	var btn = '';
	if (task.Status == 1 || task.Status == 'Paused') btn += '<input type=""button"" class=""btn btn-xs btn-success"" value=""恢复"" onclick=""top.callTask(\'resume\', \'' + task.Id + '\')"" /> ';
	if (task.Status == 0 || task.Status == 'Running') btn += '<input type=""button"" class=""btn btn-xs btn-warning"" value=""暂停"" onclick=""top.callTask(\'pause\', \'' + task.Id + '\')"" /> ';
	return btn + '<input type=""button"" class=""btn btn-xs btn-info"" value=""立即触发"" onclick=""top.callTask(\'run\', \'' + task.Id + '\')"" />';
})() + '\
								</td>\
								<td>' + task.Id + '</td>\
								<td class=""text-nowrap"">' + task.Topic + '</td>\
								<td class=""text-nowrap"">' + task.Interval + ' ' + task.IntervalArgument + '</td>\
								<td class=""text-right"">' + (function() {
	if (dto.Description.indexOf('存储: Memory') == -1) return '<a href=""../TaskLog/?taskId=' + task.Id + '"">' + task.CurrentRound + '/' + task.Round + '</a>';
	return task.CurrentRound + '/' + task.Round;
})() + '</td>\
								<td>' + task.Status + '</td>\
								<td style=""overflow-wrap: break-word;word-break: break-all;"">' + task.Body + '</td>\
								<td>' + task.CreateTime + '</td>\
								<td>' + (function() {
	if (dto.Description.indexOf('存储: Memory') == -1) return '<a href=""../TaskLog/?taskId=' + task.Id + '"">' + task.LastRunTime + '</a>';
	return task.LastRunTime;
})() + '</td>\
								<td>' + (dto.NextTimes[a] == null ? '' : dto.NextTimes[a]) + '</td>\
								<td>' + task.ErrorTimes + '</td>\
                            </tr>');
}
if (sb.length > 0) $('#dto_list').html(sb);

		top.callTask = function(opt, id) {
			$.ajax({
				type: 'GET',
				url: top.mainViewNav.trans('./callTask'),
				data: { id: id, opt: opt },
				dataType: 'json',
				success: (rt) => {
					console.log(rt);
					setTimeout(top.mainViewNav.reload, 1000);
				},
			});
		};
		top.searchByTopic = function() {
			var qs = _clone(top.mainViewNav.query);
			delete qs.page;
			qs.topic = $('#topic_1').val();
			console.log(qs)
			top.mainViewNav.goto('?' + qs_stringify(qs));
		};
		top.searchByCreateTime = function() {
			var qs = _clone(top.mainViewNav.query);
			delete qs.page;
			qs.createtime_1 = $('#createtime_1').val();
			qs.createtime_2 = $('#createtime_2').val();
			console.log(qs)
			top.mainViewNav.goto('?' + qs_stringify(qs));
		};

		top.del_callback = function(rt) {
			if (rt.code == 0) return top.mainViewNav.goto('./?' + new Date().getTime());
			alert(rt.message);
		};

		var qs = _clone(top.mainViewNav.query);
		$('#topic_1').val((qs.topic || '').trim());
		var yyyy = new Date().getYear() + 1900;
		var mm = new Date().getMonth() + 1;
		var dd = new Date().getDate();
		dd += 1;
		var maxdd = 0;
		if (mm == 1 || mm == 3 || mm == 5 || mm == 7 || mm == 8 || mm == 10 || mm == 12) maxdd = 31;
		else if (mm == 2) maxdd = (yyyy - 2000) % 4 == 0 ? 28 : 29;
		else maxdd = 30;
		if (dd > maxdd) {
			dd = 1;
			mm += 1;
			if (mm > 12) {
				mm = 1;
				yyyy += 1;
			}
		}
		var date = yyyy + '-' + mm + '-' + dd;
		if (qs.createtime_1) $('#createtime_1').val(qs.createtime_1);
		$('#createtime_2').val(qs.createtime_2 || date);
		var page = cint(qs.page, 1);
		delete qs.page;
		$('#kkpager').html(cms2Pager(dto.Total, page, 20, qs, 'page'));
		var fqs = _clone(top.mainViewNav.query);
		delete fqs.page;
		var fsc = [
			{ name: '集群', field: 'clusterId', single: 1, text: fscClusterText, value: fscClusterValue },
			{ name: '状态', field: 'status', single: 1, text: ['运行中','暂停中','已完成'], value: [0,1,2] },
			null
		];
		fsc.pop();
		cms2Filter(fsc, fqs);
		top.mainViewInit();
	})();
</script>
";

		public static string TaskInfo_add { get; private set; } = @"
<div class=""box"">
	<div class=""box-header with-border"">
		<h3 class=""box-title"" id=""box-title""></h3>
	</div>
	<div class=""box-body"">
		<div class=""table-responsive"">
			<form id=""form_add"" method=""post"">
				<input type=""hidden"" name=""__callback"" value=""edit_callback"" />
				<div>
					<table cellspacing=""0"" rules=""all"" class=""table table-bordered table-hover"" border=""1"" style=""border-collapse:collapse;"">
						<tr>
							<td>模板</td>
							<td>
								<input id=tasktpl_01 name=tasktpl type=radio value=1 /><label for=tasktpl_01>HTTP请求</label>
								<input id=tasktpl_02 name=tasktpl type=radio value=2 /><label for=tasktpl_02>清理任务数据</label>

							</td>
						</tr>
						<tr>
							<td>标题</td>
							<td><input name=""Topic"" type=""text"" class=""datepicker"" style=""width:60%;"" placeholder=""用在 OnExecuting 区分任务"" /></td>
						</tr>
					    <tr>
							<td id=""BodyLabel"">数据</td>
							<td><textarea name=""Body"" style=""width:60%;height:200px;"" editor=""ueditor"" placeholder=""用在 OnExecuting 区分相同 Title 任务的参数数据""></textarea></td>
						</tr>
					    <tr>
							<td>轮次</td>
							<td><input name=""Round"" type=""text"" class=""datepicker"" style=""width:60%;"" placeholder=""循环多少次，-1 是永久循环"" /></td>
						</tr>
					    <tr>
							<td>定时类型</td>
							<td>
                                <select name=""Interval"" onchange=""top.IntervalChange(this.value);""><option value="""">------ 请选择 ------</option>
									<option value=""SEC"">SEC 秒间隔</option>
									<option value=""RunOnDay"">RunOnDay 每天</option>
									<option value=""RunOnWeek"">RunOnWeek 每周</option>
									<option value=""RunOnMonth"">RunOnMonth 每月</option>
									<option value=""Custom"">Custom 自定义</option>
								</select>
                            </td>
						</tr>
					    <tr>
							<td>定时参数(UTC)</td>
							<td>
								<input name=""IntervalArgument"" type=""text"" class=""datepicker"" style=""width:60%;"" />
								<div id=""IntervalArgument_tips""></div>
							</td>
						</tr>
						<tr>
							<td width=""8%"">&nbsp</td>
							<td><input type=""submit"" class=""btn btn-info"" value=""添加"" />&nbsp;<input type=""button"" class=""btn"" value=""取消"" /></td>
						</tr>
					</table>
				</div>
			</form>

		</div>
	</div>
</div>

<script type=""text/javascript"">
	(function () {
		var form = $('#form_add')[0];

$('input[name=tasktpl]').change(function() {
	var val = $(this).val();
	if (val == '1') {
		form.Topic.value = '[系统预留]Http请求';
		form.Body.value = `{
	""method"": ""get"",
	""url"": ""https://freesql.net/guide/freescheduler.html"",
	""header"":
	{
		""Content-Type"": ""application/json"",
	},
	""body"": ""{}"",
}
`;
		form.Round.value = -1;
		return;
	}
	if (val == '2') {
		form.Topic.value = '[系统预留]清理任务数据';
		form.Body.value = '86400';
		$('#form_add #BodyLabel').html('清理多久之前的记录（单位：秒）<br>已完成的任务');
		form.Round.value = -1;
		return;
	}
});
if (top.mainViewNav.query.tasktpl) {
	var radio = $('input[name=tasktpl][value=' + top.mainViewNav.query.tasktpl + ']');
	radio.click();
}

		top.IntervalChange = function(val) {
			var tips = null;
			if (val == 'SEC') {
				form.IntervalArgument.value = '5'
				tips = `
//每5秒触发，执行N次
var id = scheduler.AddTask(""topic1"", ""body1"", round: -1, 5)

//每次 不同的间隔秒数触发，执行6次
var id = scheduler.AddTask(""topic1"", ""body1"", new [] { 5, 5, 10, 10, 60, 60 })`
			}
			if (val == 'RunOnDay') {
				form.IntervalArgument.value = '08:00:00'
				tips = `
//每天 08:00:00 触发，执行N次（注意时区）
var id = scheduler.AddTaskRunOnDay(""topic1"", ""body1"", round: -1, ""08:00:00"")`
			}
			if (val == 'RunOnWeek') {
				form.IntervalArgument.value = '1:08:00:00'
				tips = `
//每周一 08:00:00 触发，执行1次（注意时区）
var id = scheduler.AddTaskRunOnWeek(""topic1"", ""body1"", round: 1, ""1:08:00:00"")

//每周日 08:00:00 触发，执行1次（注意时区）
var id = scheduler.AddTaskRunOnWeek(""topic1"", ""body1"", round: 1, ""0:08:00:00"")`
			}
			if (val == 'RunOnMonth') {
				form.IntervalArgument.value = '1:08:00:00'
				tips = `
//每月1日 08:00:00 触发，执行12次（注意时区）
var id = scheduler.AddTaskRunOnMonth(""topic1"", ""body1"", round: 12, ""1:08:00:00"")

//每月最后一日 08:00:00 触发，执行12次
var id = scheduler.AddTaskRunOnMonth(""topic1"", ""body1"", round: 12, ""-1:08:00:00"")`
			}
			if (val == 'Custom') {
				form.IntervalArgument.value = '0/1 * * * * ?'
				tips = `
//自定义间隔 cron
var id = scheduler.AddTaskCustom(""topic1"", ""body1"", ""0/1 * * * * ? "")

new FreeSchedulerBuilder()
    ...
    .UseCustomInterval(task =>
    {
        //利用 cron 功能库解析 task.IntervalArgument 得到下一次执行时间
        //与当前时间相减，得到 TimeSpan，若返回 null 则任务完成
        return TimeSpan.FromSeconds(5);
    })
    .Build();`
			}
			if (tips) $('#IntervalArgument_tips').html(tips.replace(/ /g, '&nbsp;').replace(/\n/g, '<br>'))
		}
		top.edit_callback = function (rt) {
			if (rt.code == 0) return top.mainViewNav.goto('./?' + new Date().getTime());
			alert(rt.message);
		};

		
		var item = null;

		top.mainViewInit();
	})();
</script>
";

        public static string Home { get; private set; } = @"
<!DOCTYPE html>
<html lang=""zh-cmn-Hans"">
<head>
	<meta charset=""utf-8"" />
	<meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />
	<title>FreeScheduler</title>
	<meta content=""width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no"" name=""viewport"" />
	<link href=""./htm/bootstrap/css/bootstrap.min.css"" rel=""stylesheet"" />
	<link href=""./htm/plugins/font-awesome/css/font-awesome.min.css"" rel=""stylesheet"" />
	<link href=""./htm/css/skins/_all-skins.css"" rel=""stylesheet"" />
	<link href=""./htm/plugins/pace/pace.min.css"" rel=""stylesheet"" />
	<link href=""./htm/css/system.css"" rel=""stylesheet"" />
	<link href=""./htm/css/index.css"" rel=""stylesheet"" />
	<script type=""text/javascript"" src=""./htm/js/jQuery-2.1.4.min.js""></script>
	<script type=""text/javascript"" src=""./htm/bootstrap/js/bootstrap.min.js""></script>
	<script type=""text/javascript"" src=""./htm/plugins/pace/pace.min.js""></script>
	<script type=""text/javascript"" src=""./htm/js/lib.js""></script>
	<script type=""text/javascript"" src=""./htm/js/bmw.js""></script>
	<!--[if lt IE 9]>
	<script type='text/javascript' src='./htm/plugins/html5shiv/html5shiv.min.js'></script>
	<script type='text/javascript' src='./htm/plugins/respond/respond.min.js'></script>
	<![endif]-->
</head>
<body class=""hold-transition skin-blue sidebar-mini"">
	<div class=""wrapper"">
		<!-- Main Header-->
		<header class=""main-header"">
			<!-- Logo--><a href=""./"" class=""logo"">
				<!-- mini logo for sidebar mini 50x50 pixels--><span class=""logo-mini""><b>Free</b></span>
				<!-- logo for regular state and mobile devices--><span class=""logo-lg""><b>FreeScheduler</b></span>
			</a>
			<!-- Header Navbar-->
			<nav role=""navigation"" class=""navbar navbar-static-top"">
				<!-- Sidebar toggle button--><a href=""#"" data-toggle=""offcanvas"" role=""button"" class=""sidebar-toggle""><span class=""sr-only"">Toggle navigation</span></a>
				<!-- Navbar Right Menu-->
				<div class=""navbar-custom-menu"">
					<ul class=""nav navbar-nav"">
						<li>
							<a href=""https://www.cnblogs.com/FreeSql/gallery/image/338860.html"" target=""_blank"">支付宝打赏</a>
						</li>
						<li>
							<a href=""https://www.cnblogs.com/FreeSql/gallery/image/338859.html"" target=""_blank"">微信打赏</a>
						</li>
						<li>
							<a href=""{0}account/logout"">退出</a>
						</li>
					</ul>
				</div>
			</nav>
		</header>
		<!-- Left side column. contains the logo and sidebar-->
		<aside class=""main-sidebar"">
			<!-- sidebar: style can be found in sidebar.less-->
			<section class=""sidebar"">
				<!-- Sidebar Menu-->
				<ul class=""sidebar-menu"">
					<!-- Optionally, you can add icons to the links-->

					<li class=""treeview active"">
						<a href=""#""><i class=""fa fa-laptop""></i><span>通用管理</span><i class=""fa fa-angle-left pull-right""></i></a>
						<ul class=""treeview-menu""></ul>
					</li>

					<li class=""treeview active"">
						<a href=""#""><i class=""fa fa-laptop""></i><span>开发文档</span><i class=""fa fa-angle-left pull-right""></i></a>
						<ul class=""treeview-menu"">
							<li><a href=""https://freesql.net/guide/freescheduler.html"" target=""_blank""><i class=""fa fa-circle-o""></i>FreeScheduler</a></li>
							<li><a href=""https://freesql.net/"" target=""_blank""><i class=""fa fa-circle-o""></i>FreeSql</a></li>
							<li><a href=""https://freesql.net/guide/freeredis.html"" target=""_blank""><i class=""fa fa-circle-o""></i>FreeRedis</a></li>
							<li><a href=""https://freesql.net/guide/freeim.html"" target=""_blank""><i class=""fa fa-circle-o""></i>FreeIM</a></li>
						</ul>
					</li>
				</ul>
				<!-- /.sidebar-menu-->
			</section>
			<!-- /.sidebar-->
		</aside>
		<!-- Content Wrapper. Contains page content-->
		<div class=""content-wrapper"">
			<!-- Main content-->
			<section id=""right_content"" class=""content"">
				<div style=""display:none;"">
					<!-- Your Page Content Here-->
					Loading...
				</div>
			</section>
			<!-- /.content-->
		</div>
		<!-- /.content-wrapper-->
	</div>
	<!-- ./wrapper-->
	<script type=""text/javascript"" src=""./htm/js/system.js""></script>
	<script type=""text/javascript"" src=""./htm/js/admin.js?v=1""></script>
	<script type=""text/javascript"">
		if (!location.hash) $('#right_content div:first').show();
		// 路由功能
		//针对上面的html初始化路由列表
		function hash_encode(str) { return url_encode(base64.encode(str)).replace(/%/g, '_'); }
		function hash_decode(str) { return base64.decode(url_decode(str.replace(/_/g, '%'))); }
		window.div_left_router = {};
		$('li.treeview.active ul li a').each(function (index, ele) {
			if (ele.target == '_blank') return;
			var href = $(ele).attr('href');
			$(ele).attr('href', '#base64url' + hash_encode(href));
			window.div_left_router[href] = $(ele).text();
        });
        if (!location.hash) $('li.treeview.active ul li a')[0].click();
		(function () {
			function Vipspa() {
			}
			Vipspa.prototype.start = function (config) {
				Vipspa.mainView = $(config.view);
				startRouter();
				window.onhashchange = function () {
					if (location._is_changed) return location._is_changed = false;
					startRouter();
				};
			};
			function startRouter() {
				var hash = location.hash;
				if (hash === '') return //location.hash = $('li.treeview.active ul li a:first').attr('href');//'#base64url' + hash_encode('/resume_type/');
				if (hash.indexOf('#base64url') !== 0) return;
				var act = hash_decode(hash.substr(10, hash.length - 10));
				//加载或者提交form后，显示内容
				function ajax_success(refererUrl) {
					if (refererUrl == location.pathname) { startRouter(); return function(){}; }
					var hash = '#base64url' + hash_encode(refererUrl);
					if (location.hash != hash) {
						location._is_changed = true;
						location.hash = hash;
					}'\''
					return function (data, status, xhr) {
						var div;
						Function.prototype.ajax = $.ajax;
						top.mainViewNav = {
							url: refererUrl,
							trans: function (url) {
								var act = url;
								act = act.substr(0, 1) === '/' || act.indexOf('://') !== -1 || act.indexOf('data:') === 0 ? act : join_url(refererUrl, act);
								return act;
							},
							goto: function (url_or_form, target) {
								var form = url_or_form;
								if (typeof form === 'string') {
									var act = this.trans(form);
									if (String(target).toLowerCase() === '_blank') return window.open(act);
									location.hash = '#base64url' + hash_encode(act);
								}
								else {
									if (!window.ajax_form_iframe_max) window.ajax_form_iframe_max = 1;
									window.ajax_form_iframe_max++;
									var iframe = $('<iframe name=""ajax_form_iframe{0}""></iframe>'.format(window.ajax_form_iframe_max));
									Vipspa.mainView.append(iframe);
									var act = $(form).attr('action') || '';
									act = act.substr(0, 1) === '/' || act.indexOf('://') !== -1 ? act : join_url(refererUrl, act);
									if ($(form).find(':file[name]').length > 0) $(form).attr('enctype', 'multipart/form-data');
									$(form).attr('action', act);
									$(form).attr('target', iframe.attr('name'));
									iframe.on('load', function () {
										var doc = this.contentWindow ? this.contentWindow.document : this.document;
										if (doc.body.innerHTML.length === 0) return;
										if (doc.body.innerHTML.indexOf('Error:') === 0) return alert(doc.body.innerHTML.substr(6));
										//以下 '<script ' + '是防止与本页面相匹配，不要删除
										if (doc.body.innerHTML.indexOf('<script ' + 'type=""text/javascript"">location.href=""') === -1) {
											ajax_success(doc.location.pathname + doc.location.search)(doc.body.innerHTML, 200, null);
										}
									});
								}
							},
							reload: startRouter,
							query: qs_parseByUrl(refererUrl)
						};
						top.mainViewInit = function () {
							if (!div) return setTimeout(top.mainViewInit, 10);
							admin_init(function (selector) {
								if (/<[^>]+>/.test(selector)) return $(selector);
								return div.find(selector);
							}, top.mainViewNav);
						};
						if (/<body[^>]*>/i.test(data))
							data = data.match(/<body[^>]*>(([^<]|<(?!\/body>))*)<\/body>/i)[1];
						div = Vipspa.mainView.html(data);
					};
				};
				$.ajax({
					type: 'GET',
					url: act,
					dataType: 'html',
					success: ajax_success(act),
					error: function (jqXHR, textStatus, errorThrown) {
						var data = jqXHR.responseText;
						if (/<body[^>]*>/i.test(data))
							data = data.match(/<body[^>]*>(([^<]|<(?!\/body>))*)<\/body>/i)[1];
						Vipspa.mainView.html(data);
					}
				});
			}
			window.vipspa = new Vipspa();
		})();
		$(function () {
			vipspa.start({
				view: '#right_content',
			});
		});
		// 页面加载进度条
		$(document).ajaxStart(function() { Pace.restart(); });
	</script>
</body>
</html>
";

		public static string Login { get; private set; } = @"<html lang=""en"">

<head>
  <script type=""module"" src=""/@vite/client""></script>

  <meta charset=""UTF-8"">
  <link rel=""icon"" type=""image/svg+xml"" href=""/favicon.svg"">
  <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
  <title>Scheduler</title>
  <style type=""text/css"" data-vite-dev-id=""E:/code/test/ui/panda.net.web/src/assets/main.css"">
    /* color palette from <https://github.com/vuejs/theme> */
    :root {
      --vt-c-white: #ffffff;
      --vt-c-white-soft: #f8f8f8;
      --vt-c-white-mute: #f2f2f2;

      --vt-c-black: #181818;
      --vt-c-black-soft: #222222;
      --vt-c-black-mute: #282828;

      --vt-c-indigo: #2c3e50;

      --vt-c-divider-light-1: rgba(60, 60, 60, 0.29);
      --vt-c-divider-light-2: rgba(60, 60, 60, 0.12);
      --vt-c-divider-dark-1: rgba(84, 84, 84, 0.65);
      --vt-c-divider-dark-2: rgba(84, 84, 84, 0.48);

      --vt-c-text-light-1: var(--vt-c-indigo);
      --vt-c-text-light-2: rgba(60, 60, 60, 0.66);
      --vt-c-text-dark-1: var(--vt-c-white);
      --vt-c-text-dark-2: rgba(235, 235, 235, 0.64);
    }

    /* semantic color variables for this project */
    :root {
      --color-background: var(--vt-c-white);
      --color-background-soft: var(--vt-c-white-soft);
      --color-background-mute: var(--vt-c-white-mute);

      --color-border: var(--vt-c-divider-light-2);
      --color-border-hover: var(--vt-c-divider-light-1);

      --color-heading: var(--vt-c-text-light-1);
      --color-text: var(--vt-c-text-light-1);

      --section-gap: 160px;
    }

    @media (prefers-color-scheme: dark) {
      :root {
        --color-background: var(--vt-c-black);
        --color-background-soft: var(--vt-c-black-soft);
        --color-background-mute: var(--vt-c-black-mute);

        --color-border: var(--vt-c-divider-dark-2);
        --color-border-hover: var(--vt-c-divider-dark-1);

        --color-heading: var(--vt-c-text-dark-1);
        --color-text: var(--vt-c-text-dark-2);
      }
    }

    *,
    *::before,
    *::after {
      box-sizing: border-box;
      margin: 0;
      font-weight: normal;
    }

    body {
      min-height: 100vh;
      color: var(--color-text);
      background: var(--color-background);
      transition:
        color 0.5s,
        background-color 0.5s;
      line-height: 1.6;
      font-family:
        Inter,
        -apple-system,
        BlinkMacSystemFont,
        'Segoe UI',
        Roboto,
        Oxygen,
        Ubuntu,
        Cantarell,
        'Fira Sans',
        'Droid Sans',
        'Helvetica Neue',
        sans-serif;
      font-size: 15px;
      text-rendering: optimizeLegibility;
      -webkit-font-smoothing: antialiased;
      -moz-osx-font-smoothing: grayscale;
    }

    .app {
      font-weight: normal;
    }

    a,
    .green {
      text-decoration: none;
      color: hsla(160, 100%, 37%, 1);
      transition: 0.4s;
      padding: 3px;
    }

    @media (hover: hover) {
      a:hover {
        background-color: hsla(160, 100%, 37%, 0.2);
      }
    }
  </style>
  <style type=""text/css"" data-vite-dev-id=""E:/code/test/ui/panda.net.web/node_modules/element-plus/dist/index.css"">
    @charset ""UTF-8"";

    :root {
      --el-color-white: #ffffff;
      --el-color-black: #000000;
      --el-color-primary-rgb: 64, 158, 255;
      --el-color-success-rgb: 103, 194, 58;
      --el-color-warning-rgb: 230, 162, 60;
      --el-color-danger-rgb: 245, 108, 108;
      --el-color-error-rgb: 245, 108, 108;
      --el-color-info-rgb: 144, 147, 153;
      --el-font-size-extra-large: 20px;
      --el-font-size-large: 18px;
      --el-font-size-medium: 16px;
      --el-font-size-base: 14px;
      --el-font-size-small: 13px;
      --el-font-size-extra-small: 12px;
      --el-font-family: 'Helvetica Neue', Helvetica, 'PingFang SC', 'Hiragino Sans GB', 'Microsoft YaHei', '微软雅黑', Arial, sans-serif;
      --el-font-weight-primary: 500;
      --el-font-line-height-primary: 24px;
      --el-index-normal: 1;
      --el-index-top: 1000;
      --el-index-popper: 2000;
      --el-border-radius-base: 4px;
      --el-border-radius-small: 2px;
      --el-border-radius-round: 20px;
      --el-border-radius-circle: 100%;
      --el-transition-duration: 0.3s;
      --el-transition-duration-fast: 0.2s;
      --el-transition-function-ease-in-out-bezier: cubic-bezier(0.645, 0.045, 0.355, 1);
      --el-transition-function-fast-bezier: cubic-bezier(0.23, 1, 0.32, 1);
      --el-transition-all: all var(--el-transition-duration) var(--el-transition-function-ease-in-out-bezier);
      --el-transition-fade: opacity var(--el-transition-duration) var(--el-transition-function-fast-bezier);
      --el-transition-md-fade: transform var(--el-transition-duration) var(--el-transition-function-fast-bezier), opacity var(--el-transition-duration) var(--el-transition-function-fast-bezier);
      --el-transition-fade-linear: opacity var(--el-transition-duration-fast) linear;
      --el-transition-border: border-color var(--el-transition-duration-fast) var(--el-transition-function-ease-in-out-bezier);
      --el-transition-box-shadow: box-shadow var(--el-transition-duration-fast) var(--el-transition-function-ease-in-out-bezier);
      --el-transition-color: color var(--el-transition-duration-fast) var(--el-transition-function-ease-in-out-bezier);
      --el-component-size-large: 40px;
      --el-component-size: 32px;
      --el-component-size-small: 24px
    }

    :root {
      color-scheme: light;
      --el-color-white: #ffffff;
      --el-color-black: #000000;
      --el-color-primary: #409eff;
      --el-color-primary-light-3: #79bbff;
      --el-color-primary-light-5: #a0cfff;
      --el-color-primary-light-7: #c6e2ff;
      --el-color-primary-light-8: #d9ecff;
      --el-color-primary-light-9: #ecf5ff;
      --el-color-primary-dark-2: #337ecc;
      --el-color-success: #67c23a;
      --el-color-success-light-3: #95d475;
      --el-color-success-light-5: #b3e19d;
      --el-color-success-light-7: #d1edc4;
      --el-color-success-light-8: #e1f3d8;
      --el-color-success-light-9: #f0f9eb;
      --el-color-success-dark-2: #529b2e;
      --el-color-warning: #e6a23c;
      --el-color-warning-light-3: #eebe77;
      --el-color-warning-light-5: #f3d19e;
      --el-color-warning-light-7: #f8e3c5;
      --el-color-warning-light-8: #faecd8;
      --el-color-warning-light-9: #fdf6ec;
      --el-color-warning-dark-2: #b88230;
      --el-color-danger: #f56c6c;
      --el-color-danger-light-3: #f89898;
      --el-color-danger-light-5: #fab6b6;
      --el-color-danger-light-7: #fcd3d3;
      --el-color-danger-light-8: #fde2e2;
      --el-color-danger-light-9: #fef0f0;
      --el-color-danger-dark-2: #c45656;
      --el-color-error: #f56c6c;
      --el-color-error-light-3: #f89898;
      --el-color-error-light-5: #fab6b6;
      --el-color-error-light-7: #fcd3d3;
      --el-color-error-light-8: #fde2e2;
      --el-color-error-light-9: #fef0f0;
      --el-color-error-dark-2: #c45656;
      --el-color-info: #909399;
      --el-color-info-light-3: #b1b3b8;
      --el-color-info-light-5: #c8c9cc;
      --el-color-info-light-7: #dedfe0;
      --el-color-info-light-8: #e9e9eb;
      --el-color-info-light-9: #f4f4f5;
      --el-color-info-dark-2: #73767a;
      --el-bg-color: #ffffff;
      --el-bg-color-page: #f2f3f5;
      --el-bg-color-overlay: #ffffff;
      --el-text-color-primary: #303133;
      --el-text-color-regular: #606266;
      --el-text-color-secondary: #909399;
      --el-text-color-placeholder: #a8abb2;
      --el-text-color-disabled: #c0c4cc;
      --el-border-color: #dcdfe6;
      --el-border-color-light: #e4e7ed;
      --el-border-color-lighter: #ebeef5;
      --el-border-color-extra-light: #f2f6fc;
      --el-border-color-dark: #d4d7de;
      --el-border-color-darker: #cdd0d6;
      --el-fill-color: #f0f2f5;
      --el-fill-color-light: #f5f7fa;
      --el-fill-color-lighter: #fafafa;
      --el-fill-color-extra-light: #fafcff;
      --el-fill-color-dark: #ebedf0;
      --el-fill-color-darker: #e6e8eb;
      --el-fill-color-blank: #ffffff;
      --el-box-shadow: 0px 12px 32px 4px rgba(0, 0, 0, 0.04), 0px 8px 20px rgba(0, 0, 0, 0.08);
      --el-box-shadow-light: 0px 0px 12px rgba(0, 0, 0, 0.12);
      --el-box-shadow-lighter: 0px 0px 6px rgba(0, 0, 0, 0.12);
      --el-box-shadow-dark: 0px 16px 48px 16px rgba(0, 0, 0, 0.08), 0px 12px 32px rgba(0, 0, 0, 0.12), 0px 8px 16px -8px rgba(0, 0, 0, 0.16);
      --el-disabled-bg-color: var(--el-fill-color-light);
      --el-disabled-text-color: var(--el-text-color-placeholder);
      --el-disabled-border-color: var(--el-border-color-light);
      --el-overlay-color: rgba(0, 0, 0, 0.8);
      --el-overlay-color-light: rgba(0, 0, 0, 0.7);
      --el-overlay-color-lighter: rgba(0, 0, 0, 0.5);
      --el-mask-color: rgba(255, 255, 255, 0.9);
      --el-mask-color-extra-light: rgba(255, 255, 255, 0.3);
      --el-border-width: 1px;
      --el-border-style: solid;
      --el-border-color-hover: var(--el-text-color-disabled);
      --el-border: var(--el-border-width) var(--el-border-style) var(--el-border-color);
      --el-svg-monochrome-grey: var(--el-border-color)
    }

    .fade-in-linear-enter-active,
    .fade-in-linear-leave-active {
      transition: var(--el-transition-fade-linear)
    }

    .fade-in-linear-enter-from,
    .fade-in-linear-leave-to {
      opacity: 0
    }

    .el-fade-in-linear-enter-active,
    .el-fade-in-linear-leave-active {
      transition: var(--el-transition-fade-linear)
    }

    .el-fade-in-linear-enter-from,
    .el-fade-in-linear-leave-to {
      opacity: 0
    }

    .el-fade-in-enter-active,
    .el-fade-in-leave-active {
      transition: all var(--el-transition-duration) cubic-bezier(.55, 0, .1, 1)
    }

    .el-fade-in-enter-from,
    .el-fade-in-leave-active {
      opacity: 0
    }

    .el-zoom-in-center-enter-active,
    .el-zoom-in-center-leave-active {
      transition: all var(--el-transition-duration) cubic-bezier(.55, 0, .1, 1)
    }

    .el-zoom-in-center-enter-from,
    .el-zoom-in-center-leave-active {
      opacity: 0;
      transform: scaleX(0)
    }

    .el-zoom-in-top-enter-active,
    .el-zoom-in-top-leave-active {
      opacity: 1;
      transform: scaleY(1);
      transition: var(--el-transition-md-fade);
      transform-origin: center top
    }

    .el-zoom-in-top-enter-active[data-popper-placement^=top],
    .el-zoom-in-top-leave-active[data-popper-placement^=top] {
      transform-origin: center bottom
    }

    .el-zoom-in-top-enter-from,
    .el-zoom-in-top-leave-active {
      opacity: 0;
      transform: scaleY(0)
    }

    .el-zoom-in-bottom-enter-active,
    .el-zoom-in-bottom-leave-active {
      opacity: 1;
      transform: scaleY(1);
      transition: var(--el-transition-md-fade);
      transform-origin: center bottom
    }

    .el-zoom-in-bottom-enter-from,
    .el-zoom-in-bottom-leave-active {
      opacity: 0;
      transform: scaleY(0)
    }

    .el-zoom-in-left-enter-active,
    .el-zoom-in-left-leave-active {
      opacity: 1;
      transform: scale(1, 1);
      transition: var(--el-transition-md-fade);
      transform-origin: top left
    }

    .el-zoom-in-left-enter-from,
    .el-zoom-in-left-leave-active {
      opacity: 0;
      transform: scale(.45, .45)
    }

    .collapse-transition {
      transition: var(--el-transition-duration) height ease-in-out, var(--el-transition-duration) padding-top ease-in-out, var(--el-transition-duration) padding-bottom ease-in-out
    }

    .el-collapse-transition-enter-active,
    .el-collapse-transition-leave-active {
      transition: var(--el-transition-duration) max-height ease-in-out, var(--el-transition-duration) padding-top ease-in-out, var(--el-transition-duration) padding-bottom ease-in-out
    }

    .horizontal-collapse-transition {
      transition: var(--el-transition-duration) width ease-in-out, var(--el-transition-duration) padding-left ease-in-out, var(--el-transition-duration) padding-right ease-in-out
    }

    .el-list-enter-active,
    .el-list-leave-active {
      transition: all 1s
    }

    .el-list-enter-from,
    .el-list-leave-to {
      opacity: 0;
      transform: translateY(-30px)
    }

    .el-list-leave-active {
      position: absolute !important
    }

    .el-opacity-transition {
      transition: opacity var(--el-transition-duration) cubic-bezier(.55, 0, .1, 1)
    }

    .el-icon-loading {
      -webkit-animation: rotating 2s linear infinite;
      animation: rotating 2s linear infinite
    }

    .el-icon--right {
      margin-left: 5px
    }

    .el-icon--left {
      margin-right: 5px
    }

    @-webkit-keyframes rotating {
      0% {
        transform: rotateZ(0)
      }

      100% {
        transform: rotateZ(360deg)
      }
    }

    @keyframes rotating {
      0% {
        transform: rotateZ(0)
      }

      100% {
        transform: rotateZ(360deg)
      }
    }

    .el-icon {
      --color: inherit;
      height: 1em;
      width: 1em;
      line-height: 1em;
      display: inline-flex;
      justify-content: center;
      align-items: center;
      position: relative;
      fill: currentColor;
      color: var(--color);
      font-size: inherit
    }

    .el-icon.is-loading {
      -webkit-animation: rotating 2s linear infinite;
      animation: rotating 2s linear infinite
    }

    .el-icon svg {
      height: 1em;
      width: 1em
    }

    .el-affix--fixed {
      position: fixed
    }

    .el-alert {
      --el-alert-padding: 8px 16px;
      --el-alert-border-radius-base: var(--el-border-radius-base);
      --el-alert-title-font-size: 13px;
      --el-alert-description-font-size: 12px;
      --el-alert-close-font-size: 12px;
      --el-alert-close-customed-font-size: 13px;
      --el-alert-icon-size: 16px;
      --el-alert-icon-large-size: 28px;
      width: 100%;
      padding: var(--el-alert-padding);
      margin: 0;
      box-sizing: border-box;
      border-radius: var(--el-alert-border-radius-base);
      position: relative;
      background-color: var(--el-color-white);
      overflow: hidden;
      opacity: 1;
      display: flex;
      align-items: center;
      transition: opacity var(--el-transition-duration-fast)
    }

    .el-alert.is-light .el-alert__close-btn {
      color: var(--el-text-color-placeholder)
    }

    .el-alert.is-dark .el-alert__close-btn {
      color: var(--el-color-white)
    }

    .el-alert.is-dark .el-alert__description {
      color: var(--el-color-white)
    }

    .el-alert.is-center {
      justify-content: center
    }

    .el-alert--success {
      --el-alert-bg-color: var(--el-color-success-light-9)
    }

    .el-alert--success.is-light {
      background-color: var(--el-alert-bg-color);
      color: var(--el-color-success)
    }

    .el-alert--success.is-light .el-alert__description {
      color: var(--el-color-success)
    }

    .el-alert--success.is-dark {
      background-color: var(--el-color-success);
      color: var(--el-color-white)
    }

    .el-alert--info {
      --el-alert-bg-color: var(--el-color-info-light-9)
    }

    .el-alert--info.is-light {
      background-color: var(--el-alert-bg-color);
      color: var(--el-color-info)
    }

    .el-alert--info.is-light .el-alert__description {
      color: var(--el-color-info)
    }

    .el-alert--info.is-dark {
      background-color: var(--el-color-info);
      color: var(--el-color-white)
    }

    .el-alert--warning {
      --el-alert-bg-color: var(--el-color-warning-light-9)
    }

    .el-alert--warning.is-light {
      background-color: var(--el-alert-bg-color);
      color: var(--el-color-warning)
    }

    .el-alert--warning.is-light .el-alert__description {
      color: var(--el-color-warning)
    }

    .el-alert--warning.is-dark {
      background-color: var(--el-color-warning);
      color: var(--el-color-white)
    }

    .el-alert--error {
      --el-alert-bg-color: var(--el-color-error-light-9)
    }

    .el-alert--error.is-light {
      background-color: var(--el-alert-bg-color);
      color: var(--el-color-error)
    }

    .el-alert--error.is-light .el-alert__description {
      color: var(--el-color-error)
    }

    .el-alert--error.is-dark {
      background-color: var(--el-color-error);
      color: var(--el-color-white)
    }

    .el-alert__content {
      display: table-cell;
      padding: 0 8px
    }

    .el-alert .el-alert__icon {
      font-size: var(--el-alert-icon-size);
      width: var(--el-alert-icon-size)
    }

    .el-alert .el-alert__icon.is-big {
      font-size: var(--el-alert-icon-large-size);
      width: var(--el-alert-icon-large-size)
    }

    .el-alert__title {
      font-size: var(--el-alert-title-font-size);
      line-height: 18px;
      vertical-align: text-top
    }

    .el-alert__title.is-bold {
      font-weight: 700
    }

    .el-alert .el-alert__description {
      font-size: var(--el-alert-description-font-size);
      margin: 5px 0 0 0
    }

    .el-alert .el-alert__close-btn {
      font-size: var(--el-alert-close-font-size);
      opacity: 1;
      position: absolute;
      top: 12px;
      right: 15px;
      cursor: pointer
    }

    .el-alert .el-alert__close-btn.is-customed {
      font-style: normal;
      font-size: var(--el-alert-close-customed-font-size);
      top: 9px
    }

    .el-alert-fade-enter-from,
    .el-alert-fade-leave-active {
      opacity: 0
    }

    .el-aside {
      overflow: auto;
      box-sizing: border-box;
      flex-shrink: 0;
      width: var(--el-aside-width, 300px)
    }

    .el-autocomplete {
      position: relative;
      display: inline-block
    }

    .el-autocomplete__popper.el-popper {
      background: var(--el-bg-color-overlay);
      border: 1px solid var(--el-border-color-light);
      box-shadow: var(--el-box-shadow-light)
    }

    .el-autocomplete__popper.el-popper .el-popper__arrow::before {
      border: 1px solid var(--el-border-color-light)
    }

    .el-autocomplete__popper.el-popper[data-popper-placement^=top] .el-popper__arrow::before {
      border-top-color: transparent;
      border-left-color: transparent
    }

    .el-autocomplete__popper.el-popper[data-popper-placement^=bottom] .el-popper__arrow::before {
      border-bottom-color: transparent;
      border-right-color: transparent
    }

    .el-autocomplete__popper.el-popper[data-popper-placement^=left] .el-popper__arrow::before {
      border-left-color: transparent;
      border-bottom-color: transparent
    }

    .el-autocomplete__popper.el-popper[data-popper-placement^=right] .el-popper__arrow::before {
      border-right-color: transparent;
      border-top-color: transparent
    }

    .el-autocomplete-suggestion {
      border-radius: var(--el-border-radius-base);
      box-sizing: border-box
    }

    .el-autocomplete-suggestion__wrap {
      max-height: 280px;
      padding: 10px 0;
      box-sizing: border-box
    }

    .el-autocomplete-suggestion__list {
      margin: 0;
      padding: 0
    }

    .el-autocomplete-suggestion li {
      padding: 0 20px;
      margin: 0;
      line-height: 34px;
      cursor: pointer;
      color: var(--el-text-color-regular);
      font-size: var(--el-font-size-base);
      list-style: none;
      text-align: left;
      white-space: nowrap;
      overflow: hidden;
      text-overflow: ellipsis
    }

    .el-autocomplete-suggestion li:hover {
      background-color: var(--el-fill-color-light)
    }

    .el-autocomplete-suggestion li.highlighted {
      background-color: var(--el-fill-color-light)
    }

    .el-autocomplete-suggestion li.divider {
      margin-top: 6px;
      border-top: 1px solid var(--el-color-black)
    }

    .el-autocomplete-suggestion li.divider:last-child {
      margin-bottom: -6px
    }

    .el-autocomplete-suggestion.is-loading li {
      text-align: center;
      height: 100px;
      line-height: 100px;
      font-size: 20px;
      color: var(--el-text-color-secondary)
    }

    .el-autocomplete-suggestion.is-loading li::after {
      display: inline-block;
      content: """";
      height: 100%;
      vertical-align: middle
    }

    .el-autocomplete-suggestion.is-loading li:hover {
      background-color: var(--el-bg-color-overlay)
    }

    .el-autocomplete-suggestion.is-loading .el-icon-loading {
      vertical-align: middle
    }

    .el-avatar {
      --el-avatar-text-color: var(--el-color-white);
      --el-avatar-bg-color: var(--el-text-color-disabled);
      --el-avatar-text-size: 14px;
      --el-avatar-icon-size: 18px;
      --el-avatar-border-radius: var(--el-border-radius-base);
      --el-avatar-size-large: 56px;
      --el-avatar-size: 40px;
      --el-avatar-size-small: 24px;
      --el-avatar-size: 40px;
      display: inline-flex;
      justify-content: center;
      align-items: center;
      box-sizing: border-box;
      text-align: center;
      overflow: hidden;
      color: var(--el-avatar-text-color);
      background: var(--el-avatar-bg-color);
      width: var(--el-avatar-size);
      height: var(--el-avatar-size);
      font-size: var(--el-avatar-text-size)
    }

    .el-avatar>img {
      display: block;
      width: 100%;
      height: 100%
    }

    .el-avatar--circle {
      border-radius: 50%
    }

    .el-avatar--square {
      border-radius: var(--el-avatar-border-radius)
    }

    .el-avatar--icon {
      font-size: var(--el-avatar-icon-size)
    }

    .el-avatar--small {
      --el-avatar-size: 24px
    }

    .el-avatar--large {
      --el-avatar-size: 56px
    }

    .el-backtop {
      --el-backtop-bg-color: var(--el-bg-color-overlay);
      --el-backtop-text-color: var(--el-color-primary);
      --el-backtop-hover-bg-color: var(--el-border-color-extra-light);
      position: fixed;
      background-color: var(--el-backtop-bg-color);
      width: 40px;
      height: 40px;
      border-radius: 50%;
      color: var(--el-backtop-text-color);
      display: flex;
      align-items: center;
      justify-content: center;
      font-size: 20px;
      box-shadow: var(--el-box-shadow-lighter);
      cursor: pointer;
      z-index: 5
    }

    .el-backtop:hover {
      background-color: var(--el-backtop-hover-bg-color)
    }

    .el-backtop__icon {
      font-size: 20px
    }

    .el-badge {
      --el-badge-bg-color: var(--el-color-danger);
      --el-badge-radius: 10px;
      --el-badge-font-size: 12px;
      --el-badge-padding: 6px;
      --el-badge-size: 18px;
      position: relative;
      vertical-align: middle;
      display: inline-block;
      width: -webkit-fit-content;
      width: -moz-fit-content;
      width: fit-content
    }

    .el-badge__content {
      background-color: var(--el-badge-bg-color);
      border-radius: var(--el-badge-radius);
      color: var(--el-color-white);
      display: inline-flex;
      justify-content: center;
      align-items: center;
      font-size: var(--el-badge-font-size);
      height: var(--el-badge-size);
      padding: 0 var(--el-badge-padding);
      white-space: nowrap;
      border: 1px solid var(--el-bg-color)
    }

    .el-badge__content.is-fixed {
      position: absolute;
      top: 0;
      right: calc(1px + var(--el-badge-size)/ 2);
      transform: translateY(-50%) translateX(100%);
      z-index: var(--el-index-normal)
    }

    .el-badge__content.is-fixed.is-dot {
      right: 5px
    }

    .el-badge__content.is-dot {
      height: 8px;
      width: 8px;
      padding: 0;
      right: 0;
      border-radius: 50%
    }

    .el-badge__content--primary {
      background-color: var(--el-color-primary)
    }

    .el-badge__content--success {
      background-color: var(--el-color-success)
    }

    .el-badge__content--warning {
      background-color: var(--el-color-warning)
    }

    .el-badge__content--info {
      background-color: var(--el-color-info)
    }

    .el-badge__content--danger {
      background-color: var(--el-color-danger)
    }

    .el-breadcrumb {
      font-size: 14px;
      line-height: 1
    }

    .el-breadcrumb::after,
    .el-breadcrumb::before {
      display: table;
      content: """"
    }

    .el-breadcrumb::after {
      clear: both
    }

    .el-breadcrumb__separator {
      margin: 0 9px;
      font-weight: 700;
      color: var(--el-text-color-placeholder)
    }

    .el-breadcrumb__separator.el-icon {
      margin: 0 6px;
      font-weight: 400
    }

    .el-breadcrumb__separator.el-icon svg {
      vertical-align: middle
    }

    .el-breadcrumb__item {
      float: left;
      display: inline-flex;
      align-items: center
    }

    .el-breadcrumb__inner {
      color: var(--el-text-color-regular)
    }

    .el-breadcrumb__inner a,
    .el-breadcrumb__inner.is-link {
      font-weight: 700;
      text-decoration: none;
      transition: var(--el-transition-color);
      color: var(--el-text-color-primary)
    }

    .el-breadcrumb__inner a:hover,
    .el-breadcrumb__inner.is-link:hover {
      color: var(--el-color-primary);
      cursor: pointer
    }

    .el-breadcrumb__item:last-child .el-breadcrumb__inner,
    .el-breadcrumb__item:last-child .el-breadcrumb__inner a,
    .el-breadcrumb__item:last-child .el-breadcrumb__inner a:hover,
    .el-breadcrumb__item:last-child .el-breadcrumb__inner:hover {
      font-weight: 400;
      color: var(--el-text-color-regular);
      cursor: text
    }

    .el-breadcrumb__item:last-child .el-breadcrumb__separator {
      display: none
    }

    .el-button-group {
      display: inline-block;
      vertical-align: middle
    }

    .el-button-group::after,
    .el-button-group::before {
      display: table;
      content: """"
    }

    .el-button-group::after {
      clear: both
    }

    .el-button-group>.el-button {
      float: left;
      position: relative
    }

    .el-button-group>.el-button+.el-button {
      margin-left: 0
    }

    .el-button-group>.el-button:first-child {
      border-top-right-radius: 0;
      border-bottom-right-radius: 0
    }

    .el-button-group>.el-button:last-child {
      border-top-left-radius: 0;
      border-bottom-left-radius: 0
    }

    .el-button-group>.el-button:first-child:last-child {
      border-top-right-radius: var(--el-border-radius-base);
      border-bottom-right-radius: var(--el-border-radius-base);
      border-top-left-radius: var(--el-border-radius-base);
      border-bottom-left-radius: var(--el-border-radius-base)
    }

    .el-button-group>.el-button:first-child:last-child.is-round {
      border-radius: var(--el-border-radius-round)
    }

    .el-button-group>.el-button:first-child:last-child.is-circle {
      border-radius: 50%
    }

    .el-button-group>.el-button:not(:first-child):not(:last-child) {
      border-radius: 0
    }

    .el-button-group>.el-button:not(:last-child) {
      margin-right: -1px
    }

    .el-button-group>.el-button:active,
    .el-button-group>.el-button:focus,
    .el-button-group>.el-button:hover {
      z-index: 1
    }

    .el-button-group>.el-button.is-active {
      z-index: 1
    }

    .el-button-group>.el-dropdown>.el-button {
      border-top-left-radius: 0;
      border-bottom-left-radius: 0;
      border-left-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--primary:first-child {
      border-right-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--primary:last-child {
      border-left-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--primary:not(:first-child):not(:last-child) {
      border-left-color: var(--el-button-divide-border-color);
      border-right-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--success:first-child {
      border-right-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--success:last-child {
      border-left-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--success:not(:first-child):not(:last-child) {
      border-left-color: var(--el-button-divide-border-color);
      border-right-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--warning:first-child {
      border-right-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--warning:last-child {
      border-left-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--warning:not(:first-child):not(:last-child) {
      border-left-color: var(--el-button-divide-border-color);
      border-right-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--danger:first-child {
      border-right-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--danger:last-child {
      border-left-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--danger:not(:first-child):not(:last-child) {
      border-left-color: var(--el-button-divide-border-color);
      border-right-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--info:first-child {
      border-right-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--info:last-child {
      border-left-color: var(--el-button-divide-border-color)
    }

    .el-button-group .el-button--info:not(:first-child):not(:last-child) {
      border-left-color: var(--el-button-divide-border-color);
      border-right-color: var(--el-button-divide-border-color)
    }

    .el-button {
      --el-button-font-weight: var(--el-font-weight-primary);
      --el-button-border-color: var(--el-border-color);
      --el-button-bg-color: var(--el-fill-color-blank);
      --el-button-text-color: var(--el-text-color-regular);
      --el-button-disabled-text-color: var(--el-disabled-text-color);
      --el-button-disabled-bg-color: var(--el-fill-color-blank);
      --el-button-disabled-border-color: var(--el-border-color-light);
      --el-button-divide-border-color: rgba(255, 255, 255, 0.5);
      --el-button-hover-text-color: var(--el-color-primary);
      --el-button-hover-bg-color: var(--el-color-primary-light-9);
      --el-button-hover-border-color: var(--el-color-primary-light-7);
      --el-button-active-text-color: var(--el-button-hover-text-color);
      --el-button-active-border-color: var(--el-color-primary);
      --el-button-active-bg-color: var(--el-button-hover-bg-color);
      --el-button-outline-color: var(--el-color-primary-light-5);
      --el-button-hover-link-text-color: var(--el-color-info);
      --el-button-active-color: var(--el-text-color-primary)
    }

    .el-button {
      display: inline-flex;
      justify-content: center;
      align-items: center;
      line-height: 1;
      height: 32px;
      white-space: nowrap;
      cursor: pointer;
      color: var(--el-button-text-color);
      text-align: center;
      box-sizing: border-box;
      outline: 0;
      transition: .1s;
      font-weight: var(--el-button-font-weight);
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      vertical-align: middle;
      -webkit-appearance: none;
      background-color: var(--el-button-bg-color);
      border: var(--el-border);
      border-color: var(--el-button-border-color);
      padding: 8px 15px;
      font-size: var(--el-font-size-base);
      border-radius: var(--el-border-radius-base)
    }

    .el-button:focus,
    .el-button:hover {
      color: var(--el-button-hover-text-color);
      border-color: var(--el-button-hover-border-color);
      background-color: var(--el-button-hover-bg-color);
      outline: 0
    }

    .el-button:active {
      color: var(--el-button-active-text-color);
      border-color: var(--el-button-active-border-color);
      background-color: var(--el-button-active-bg-color);
      outline: 0
    }

    .el-button:focus-visible {
      outline: 2px solid var(--el-button-outline-color);
      outline-offset: 1px
    }

    .el-button>span {
      display: inline-flex;
      align-items: center
    }

    .el-button+.el-button {
      margin-left: 12px
    }

    .el-button.is-round {
      padding: 8px 15px
    }

    .el-button::-moz-focus-inner {
      border: 0
    }

    .el-button [class*=el-icon]+span {
      margin-left: 6px
    }

    .el-button [class*=el-icon] svg {
      vertical-align: bottom
    }

    .el-button.is-plain {
      --el-button-hover-text-color: var(--el-color-primary);
      --el-button-hover-bg-color: var(--el-fill-color-blank);
      --el-button-hover-border-color: var(--el-color-primary)
    }

    .el-button.is-active {
      color: var(--el-button-active-text-color);
      border-color: var(--el-button-active-border-color);
      background-color: var(--el-button-active-bg-color);
      outline: 0
    }

    .el-button.is-disabled,
    .el-button.is-disabled:focus,
    .el-button.is-disabled:hover {
      color: var(--el-button-disabled-text-color);
      cursor: not-allowed;
      background-image: none;
      background-color: var(--el-button-disabled-bg-color);
      border-color: var(--el-button-disabled-border-color)
    }

    .el-button.is-loading {
      position: relative;
      pointer-events: none
    }

    .el-button.is-loading:before {
      z-index: 1;
      pointer-events: none;
      content: """";
      position: absolute;
      left: -1px;
      top: -1px;
      right: -1px;
      bottom: -1px;
      border-radius: inherit;
      background-color: var(--el-mask-color-extra-light)
    }

    .el-button.is-round {
      border-radius: var(--el-border-radius-round)
    }

    .el-button.is-circle {
      width: 32px;
      border-radius: 50%;
      padding: 8px
    }

    .el-button.is-text {
      color: var(--el-button-text-color);
      border: 0 solid transparent;
      background-color: transparent
    }

    .el-button.is-text.is-disabled {
      color: var(--el-button-disabled-text-color);
      background-color: transparent !important
    }

    .el-button.is-text:not(.is-disabled):focus,
    .el-button.is-text:not(.is-disabled):hover {
      background-color: var(--el-fill-color-light)
    }

    .el-button.is-text:not(.is-disabled):focus-visible {
      outline: 2px solid var(--el-button-outline-color);
      outline-offset: 1px
    }

    .el-button.is-text:not(.is-disabled):active {
      background-color: var(--el-fill-color)
    }

    .el-button.is-text:not(.is-disabled).is-has-bg {
      background-color: var(--el-fill-color-light)
    }

    .el-button.is-text:not(.is-disabled).is-has-bg:focus,
    .el-button.is-text:not(.is-disabled).is-has-bg:hover {
      background-color: var(--el-fill-color)
    }

    .el-button.is-text:not(.is-disabled).is-has-bg:active {
      background-color: var(--el-fill-color-dark)
    }

    .el-button__text--expand {
      letter-spacing: .3em;
      margin-right: -.3em
    }

    .el-button.is-link {
      border-color: transparent;
      color: var(--el-button-text-color);
      background: 0 0;
      padding: 2px;
      height: auto
    }

    .el-button.is-link:focus,
    .el-button.is-link:hover {
      color: var(--el-button-hover-link-text-color)
    }

    .el-button.is-link.is-disabled {
      color: var(--el-button-disabled-text-color);
      background-color: transparent !important;
      border-color: transparent !important
    }

    .el-button.is-link:not(.is-disabled):focus,
    .el-button.is-link:not(.is-disabled):hover {
      border-color: transparent;
      background-color: transparent
    }

    .el-button.is-link:not(.is-disabled):active {
      color: var(--el-button-active-color);
      border-color: transparent;
      background-color: transparent
    }

    .el-button--text {
      border-color: transparent;
      background: 0 0;
      color: var(--el-color-primary);
      padding-left: 0;
      padding-right: 0
    }

    .el-button--text.is-disabled {
      color: var(--el-button-disabled-text-color);
      background-color: transparent !important;
      border-color: transparent !important
    }

    .el-button--text:not(.is-disabled):focus,
    .el-button--text:not(.is-disabled):hover {
      color: var(--el-color-primary-light-3);
      border-color: transparent;
      background-color: transparent
    }

    .el-button--text:not(.is-disabled):active {
      color: var(--el-color-primary-dark-2);
      border-color: transparent;
      background-color: transparent
    }

    .el-button__link--expand {
      letter-spacing: .3em;
      margin-right: -.3em
    }

    .el-button--primary {
      --el-button-text-color: var(--el-color-white);
      --el-button-bg-color: var(--el-color-primary);
      --el-button-border-color: var(--el-color-primary);
      --el-button-outline-color: var(--el-color-primary-light-5);
      --el-button-active-color: var(--el-color-primary-dark-2);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-link-text-color: var(--el-color-primary-light-5);
      --el-button-hover-bg-color: var(--el-color-primary-light-3);
      --el-button-hover-border-color: var(--el-color-primary-light-3);
      --el-button-active-bg-color: var(--el-color-primary-dark-2);
      --el-button-active-border-color: var(--el-color-primary-dark-2);
      --el-button-disabled-text-color: var(--el-color-white);
      --el-button-disabled-bg-color: var(--el-color-primary-light-5);
      --el-button-disabled-border-color: var(--el-color-primary-light-5)
    }

    .el-button--primary.is-link,
    .el-button--primary.is-plain,
    .el-button--primary.is-text {
      --el-button-text-color: var(--el-color-primary);
      --el-button-bg-color: var(--el-color-primary-light-9);
      --el-button-border-color: var(--el-color-primary-light-5);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-bg-color: var(--el-color-primary);
      --el-button-hover-border-color: var(--el-color-primary);
      --el-button-active-text-color: var(--el-color-white)
    }

    .el-button--primary.is-link.is-disabled,
    .el-button--primary.is-link.is-disabled:active,
    .el-button--primary.is-link.is-disabled:focus,
    .el-button--primary.is-link.is-disabled:hover,
    .el-button--primary.is-plain.is-disabled,
    .el-button--primary.is-plain.is-disabled:active,
    .el-button--primary.is-plain.is-disabled:focus,
    .el-button--primary.is-plain.is-disabled:hover,
    .el-button--primary.is-text.is-disabled,
    .el-button--primary.is-text.is-disabled:active,
    .el-button--primary.is-text.is-disabled:focus,
    .el-button--primary.is-text.is-disabled:hover {
      color: var(--el-color-primary-light-5);
      background-color: var(--el-color-primary-light-9);
      border-color: var(--el-color-primary-light-8)
    }

    .el-button--success {
      --el-button-text-color: var(--el-color-white);
      --el-button-bg-color: var(--el-color-success);
      --el-button-border-color: var(--el-color-success);
      --el-button-outline-color: var(--el-color-success-light-5);
      --el-button-active-color: var(--el-color-success-dark-2);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-link-text-color: var(--el-color-success-light-5);
      --el-button-hover-bg-color: var(--el-color-success-light-3);
      --el-button-hover-border-color: var(--el-color-success-light-3);
      --el-button-active-bg-color: var(--el-color-success-dark-2);
      --el-button-active-border-color: var(--el-color-success-dark-2);
      --el-button-disabled-text-color: var(--el-color-white);
      --el-button-disabled-bg-color: var(--el-color-success-light-5);
      --el-button-disabled-border-color: var(--el-color-success-light-5)
    }

    .el-button--success.is-link,
    .el-button--success.is-plain,
    .el-button--success.is-text {
      --el-button-text-color: var(--el-color-success);
      --el-button-bg-color: var(--el-color-success-light-9);
      --el-button-border-color: var(--el-color-success-light-5);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-bg-color: var(--el-color-success);
      --el-button-hover-border-color: var(--el-color-success);
      --el-button-active-text-color: var(--el-color-white)
    }

    .el-button--success.is-link.is-disabled,
    .el-button--success.is-link.is-disabled:active,
    .el-button--success.is-link.is-disabled:focus,
    .el-button--success.is-link.is-disabled:hover,
    .el-button--success.is-plain.is-disabled,
    .el-button--success.is-plain.is-disabled:active,
    .el-button--success.is-plain.is-disabled:focus,
    .el-button--success.is-plain.is-disabled:hover,
    .el-button--success.is-text.is-disabled,
    .el-button--success.is-text.is-disabled:active,
    .el-button--success.is-text.is-disabled:focus,
    .el-button--success.is-text.is-disabled:hover {
      color: var(--el-color-success-light-5);
      background-color: var(--el-color-success-light-9);
      border-color: var(--el-color-success-light-8)
    }

    .el-button--warning {
      --el-button-text-color: var(--el-color-white);
      --el-button-bg-color: var(--el-color-warning);
      --el-button-border-color: var(--el-color-warning);
      --el-button-outline-color: var(--el-color-warning-light-5);
      --el-button-active-color: var(--el-color-warning-dark-2);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-link-text-color: var(--el-color-warning-light-5);
      --el-button-hover-bg-color: var(--el-color-warning-light-3);
      --el-button-hover-border-color: var(--el-color-warning-light-3);
      --el-button-active-bg-color: var(--el-color-warning-dark-2);
      --el-button-active-border-color: var(--el-color-warning-dark-2);
      --el-button-disabled-text-color: var(--el-color-white);
      --el-button-disabled-bg-color: var(--el-color-warning-light-5);
      --el-button-disabled-border-color: var(--el-color-warning-light-5)
    }

    .el-button--warning.is-link,
    .el-button--warning.is-plain,
    .el-button--warning.is-text {
      --el-button-text-color: var(--el-color-warning);
      --el-button-bg-color: var(--el-color-warning-light-9);
      --el-button-border-color: var(--el-color-warning-light-5);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-bg-color: var(--el-color-warning);
      --el-button-hover-border-color: var(--el-color-warning);
      --el-button-active-text-color: var(--el-color-white)
    }

    .el-button--warning.is-link.is-disabled,
    .el-button--warning.is-link.is-disabled:active,
    .el-button--warning.is-link.is-disabled:focus,
    .el-button--warning.is-link.is-disabled:hover,
    .el-button--warning.is-plain.is-disabled,
    .el-button--warning.is-plain.is-disabled:active,
    .el-button--warning.is-plain.is-disabled:focus,
    .el-button--warning.is-plain.is-disabled:hover,
    .el-button--warning.is-text.is-disabled,
    .el-button--warning.is-text.is-disabled:active,
    .el-button--warning.is-text.is-disabled:focus,
    .el-button--warning.is-text.is-disabled:hover {
      color: var(--el-color-warning-light-5);
      background-color: var(--el-color-warning-light-9);
      border-color: var(--el-color-warning-light-8)
    }

    .el-button--danger {
      --el-button-text-color: var(--el-color-white);
      --el-button-bg-color: var(--el-color-danger);
      --el-button-border-color: var(--el-color-danger);
      --el-button-outline-color: var(--el-color-danger-light-5);
      --el-button-active-color: var(--el-color-danger-dark-2);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-link-text-color: var(--el-color-danger-light-5);
      --el-button-hover-bg-color: var(--el-color-danger-light-3);
      --el-button-hover-border-color: var(--el-color-danger-light-3);
      --el-button-active-bg-color: var(--el-color-danger-dark-2);
      --el-button-active-border-color: var(--el-color-danger-dark-2);
      --el-button-disabled-text-color: var(--el-color-white);
      --el-button-disabled-bg-color: var(--el-color-danger-light-5);
      --el-button-disabled-border-color: var(--el-color-danger-light-5)
    }

    .el-button--danger.is-link,
    .el-button--danger.is-plain,
    .el-button--danger.is-text {
      --el-button-text-color: var(--el-color-danger);
      --el-button-bg-color: var(--el-color-danger-light-9);
      --el-button-border-color: var(--el-color-danger-light-5);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-bg-color: var(--el-color-danger);
      --el-button-hover-border-color: var(--el-color-danger);
      --el-button-active-text-color: var(--el-color-white)
    }

    .el-button--danger.is-link.is-disabled,
    .el-button--danger.is-link.is-disabled:active,
    .el-button--danger.is-link.is-disabled:focus,
    .el-button--danger.is-link.is-disabled:hover,
    .el-button--danger.is-plain.is-disabled,
    .el-button--danger.is-plain.is-disabled:active,
    .el-button--danger.is-plain.is-disabled:focus,
    .el-button--danger.is-plain.is-disabled:hover,
    .el-button--danger.is-text.is-disabled,
    .el-button--danger.is-text.is-disabled:active,
    .el-button--danger.is-text.is-disabled:focus,
    .el-button--danger.is-text.is-disabled:hover {
      color: var(--el-color-danger-light-5);
      background-color: var(--el-color-danger-light-9);
      border-color: var(--el-color-danger-light-8)
    }

    .el-button--info {
      --el-button-text-color: var(--el-color-white);
      --el-button-bg-color: var(--el-color-info);
      --el-button-border-color: var(--el-color-info);
      --el-button-outline-color: var(--el-color-info-light-5);
      --el-button-active-color: var(--el-color-info-dark-2);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-link-text-color: var(--el-color-info-light-5);
      --el-button-hover-bg-color: var(--el-color-info-light-3);
      --el-button-hover-border-color: var(--el-color-info-light-3);
      --el-button-active-bg-color: var(--el-color-info-dark-2);
      --el-button-active-border-color: var(--el-color-info-dark-2);
      --el-button-disabled-text-color: var(--el-color-white);
      --el-button-disabled-bg-color: var(--el-color-info-light-5);
      --el-button-disabled-border-color: var(--el-color-info-light-5)
    }

    .el-button--info.is-link,
    .el-button--info.is-plain,
    .el-button--info.is-text {
      --el-button-text-color: var(--el-color-info);
      --el-button-bg-color: var(--el-color-info-light-9);
      --el-button-border-color: var(--el-color-info-light-5);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-bg-color: var(--el-color-info);
      --el-button-hover-border-color: var(--el-color-info);
      --el-button-active-text-color: var(--el-color-white)
    }

    .el-button--info.is-link.is-disabled,
    .el-button--info.is-link.is-disabled:active,
    .el-button--info.is-link.is-disabled:focus,
    .el-button--info.is-link.is-disabled:hover,
    .el-button--info.is-plain.is-disabled,
    .el-button--info.is-plain.is-disabled:active,
    .el-button--info.is-plain.is-disabled:focus,
    .el-button--info.is-plain.is-disabled:hover,
    .el-button--info.is-text.is-disabled,
    .el-button--info.is-text.is-disabled:active,
    .el-button--info.is-text.is-disabled:focus,
    .el-button--info.is-text.is-disabled:hover {
      color: var(--el-color-info-light-5);
      background-color: var(--el-color-info-light-9);
      border-color: var(--el-color-info-light-8)
    }

    .el-button--large {
      --el-button-size: 40px;
      height: var(--el-button-size);
      padding: 12px 19px;
      font-size: var(--el-font-size-base);
      border-radius: var(--el-border-radius-base)
    }

    .el-button--large [class*=el-icon]+span {
      margin-left: 8px
    }

    .el-button--large.is-round {
      padding: 12px 19px
    }

    .el-button--large.is-circle {
      width: var(--el-button-size);
      padding: 12px
    }

    .el-button--small {
      --el-button-size: 24px;
      height: var(--el-button-size);
      padding: 5px 11px;
      font-size: 12px;
      border-radius: calc(var(--el-border-radius-base) - 1px)
    }

    .el-button--small [class*=el-icon]+span {
      margin-left: 4px
    }

    .el-button--small.is-round {
      padding: 5px 11px
    }

    .el-button--small.is-circle {
      width: var(--el-button-size);
      padding: 5px
    }

    .el-calendar {
      --el-calendar-border: var(--el-table-border, 1px solid var(--el-border-color-lighter));
      --el-calendar-header-border-bottom: var(--el-calendar-border);
      --el-calendar-selected-bg-color: var(--el-color-primary-light-9);
      --el-calendar-cell-width: 85px;
      background-color: var(--el-fill-color-blank)
    }

    .el-calendar__header {
      display: flex;
      justify-content: space-between;
      padding: 12px 20px;
      border-bottom: var(--el-calendar-header-border-bottom)
    }

    .el-calendar__title {
      color: var(--el-text-color);
      align-self: center
    }

    .el-calendar__body {
      padding: 12px 20px 35px
    }

    .el-calendar-table {
      table-layout: fixed;
      width: 100%
    }

    .el-calendar-table thead th {
      padding: 12px 0;
      color: var(--el-text-color-regular);
      font-weight: 400
    }

    .el-calendar-table:not(.is-range) td.next,
    .el-calendar-table:not(.is-range) td.prev {
      color: var(--el-text-color-placeholder)
    }

    .el-calendar-table td {
      border-bottom: var(--el-calendar-border);
      border-right: var(--el-calendar-border);
      vertical-align: top;
      transition: background-color var(--el-transition-duration-fast) ease
    }

    .el-calendar-table td.is-selected {
      background-color: var(--el-calendar-selected-bg-color)
    }

    .el-calendar-table td.is-today {
      color: var(--el-color-primary)
    }

    .el-calendar-table tr:first-child td {
      border-top: var(--el-calendar-border)
    }

    .el-calendar-table tr td:first-child {
      border-left: var(--el-calendar-border)
    }

    .el-calendar-table tr.el-calendar-table__row--hide-border td {
      border-top: none
    }

    .el-calendar-table .el-calendar-day {
      box-sizing: border-box;
      padding: 8px;
      height: var(--el-calendar-cell-width)
    }

    .el-calendar-table .el-calendar-day:hover {
      cursor: pointer;
      background-color: var(--el-calendar-selected-bg-color)
    }

    .el-card {
      --el-card-border-color: var(--el-border-color-light);
      --el-card-border-radius: 4px;
      --el-card-padding: 20px;
      --el-card-bg-color: var(--el-fill-color-blank)
    }

    .el-card {
      border-radius: var(--el-card-border-radius);
      border: 1px solid var(--el-card-border-color);
      background-color: var(--el-card-bg-color);
      overflow: hidden;
      color: var(--el-text-color-primary);
      transition: var(--el-transition-duration)
    }

    .el-card.is-always-shadow {
      box-shadow: var(--el-box-shadow-light)
    }

    .el-card.is-hover-shadow:focus,
    .el-card.is-hover-shadow:hover {
      box-shadow: var(--el-box-shadow-light)
    }

    .el-card__header {
      padding: calc(var(--el-card-padding) - 2px) var(--el-card-padding);
      border-bottom: 1px solid var(--el-card-border-color);
      box-sizing: border-box
    }

    .el-card__body {
      padding: var(--el-card-padding)
    }

    .el-card__footer {
      padding: calc(var(--el-card-padding) - 2px) var(--el-card-padding);
      border-top: 1px solid var(--el-card-border-color);
      box-sizing: border-box
    }

    .el-carousel__item {
      position: absolute;
      top: 0;
      left: 0;
      width: 100%;
      height: 100%;
      display: inline-block;
      overflow: hidden;
      z-index: calc(var(--el-index-normal) - 1)
    }

    .el-carousel__item.is-active {
      z-index: calc(var(--el-index-normal) - 1)
    }

    .el-carousel__item.is-animating {
      transition: transform .4s ease-in-out
    }

    .el-carousel__item--card {
      width: 50%;
      transition: transform .4s ease-in-out
    }

    .el-carousel__item--card.is-in-stage {
      cursor: pointer;
      z-index: var(--el-index-normal)
    }

    .el-carousel__item--card.is-in-stage.is-hover .el-carousel__mask,
    .el-carousel__item--card.is-in-stage:hover .el-carousel__mask {
      opacity: .12
    }

    .el-carousel__item--card.is-active {
      z-index: calc(var(--el-index-normal) + 1)
    }

    .el-carousel__item--card-vertical {
      width: 100%;
      height: 50%
    }

    .el-carousel__mask {
      position: absolute;
      width: 100%;
      height: 100%;
      top: 0;
      left: 0;
      background-color: var(--el-color-white);
      opacity: .24;
      transition: var(--el-transition-duration-fast)
    }

    .el-carousel {
      --el-carousel-arrow-font-size: 12px;
      --el-carousel-arrow-size: 36px;
      --el-carousel-arrow-background: rgba(31, 45, 61, 0.11);
      --el-carousel-arrow-hover-background: rgba(31, 45, 61, 0.23);
      --el-carousel-indicator-width: 30px;
      --el-carousel-indicator-height: 2px;
      --el-carousel-indicator-padding-horizontal: 4px;
      --el-carousel-indicator-padding-vertical: 12px;
      --el-carousel-indicator-out-color: var(--el-border-color-hover);
      position: relative
    }

    .el-carousel--horizontal {
      overflow: hidden
    }

    .el-carousel--vertical {
      overflow: hidden
    }

    .el-carousel__container {
      position: relative;
      height: 300px
    }

    .el-carousel__arrow {
      border: none;
      outline: 0;
      padding: 0;
      margin: 0;
      height: var(--el-carousel-arrow-size);
      width: var(--el-carousel-arrow-size);
      cursor: pointer;
      transition: var(--el-transition-duration);
      border-radius: 50%;
      background-color: var(--el-carousel-arrow-background);
      color: #fff;
      position: absolute;
      top: 50%;
      z-index: 10;
      transform: translateY(-50%);
      text-align: center;
      font-size: var(--el-carousel-arrow-font-size);
      display: inline-flex;
      justify-content: center;
      align-items: center
    }

    .el-carousel__arrow--left {
      left: 16px
    }

    .el-carousel__arrow--right {
      right: 16px
    }

    .el-carousel__arrow:hover {
      background-color: var(--el-carousel-arrow-hover-background)
    }

    .el-carousel__arrow i {
      cursor: pointer
    }

    .el-carousel__indicators {
      position: absolute;
      list-style: none;
      margin: 0;
      padding: 0;
      z-index: calc(var(--el-index-normal) + 1)
    }

    .el-carousel__indicators--horizontal {
      bottom: 0;
      left: 50%;
      transform: translateX(-50%)
    }

    .el-carousel__indicators--vertical {
      right: 0;
      top: 50%;
      transform: translateY(-50%)
    }

    .el-carousel__indicators--outside {
      bottom: calc(var(--el-carousel-indicator-height) + var(--el-carousel-indicator-padding-vertical) * 2);
      text-align: center;
      position: static;
      transform: none
    }

    .el-carousel__indicators--outside .el-carousel__indicator:hover button {
      opacity: .64
    }

    .el-carousel__indicators--outside button {
      background-color: var(--el-carousel-indicator-out-color);
      opacity: .24
    }

    .el-carousel__indicators--right {
      right: 0
    }

    .el-carousel__indicators--labels {
      left: 0;
      right: 0;
      transform: none;
      text-align: center
    }

    .el-carousel__indicators--labels .el-carousel__button {
      height: auto;
      width: auto;
      padding: 2px 18px;
      font-size: 12px;
      color: #000
    }

    .el-carousel__indicators--labels .el-carousel__indicator {
      padding: 6px 4px
    }

    .el-carousel__indicator {
      background-color: transparent;
      cursor: pointer
    }

    .el-carousel__indicator:hover button {
      opacity: .72
    }

    .el-carousel__indicator--horizontal {
      display: inline-block;
      padding: var(--el-carousel-indicator-padding-vertical) var(--el-carousel-indicator-padding-horizontal)
    }

    .el-carousel__indicator--vertical {
      padding: var(--el-carousel-indicator-padding-horizontal) var(--el-carousel-indicator-padding-vertical)
    }

    .el-carousel__indicator--vertical .el-carousel__button {
      width: var(--el-carousel-indicator-height);
      height: calc(var(--el-carousel-indicator-width)/ 2)
    }

    .el-carousel__indicator.is-active button {
      opacity: 1
    }

    .el-carousel__button {
      display: block;
      opacity: .48;
      width: var(--el-carousel-indicator-width);
      height: var(--el-carousel-indicator-height);
      background-color: #fff;
      border: none;
      outline: 0;
      padding: 0;
      margin: 0;
      cursor: pointer;
      transition: var(--el-transition-duration)
    }

    .carousel-arrow-left-enter-from,
    .carousel-arrow-left-leave-active {
      transform: translateY(-50%) translateX(-10px);
      opacity: 0
    }

    .carousel-arrow-right-enter-from,
    .carousel-arrow-right-leave-active {
      transform: translateY(-50%) translateX(10px);
      opacity: 0
    }

    .el-cascader-panel {
      --el-cascader-menu-text-color: var(--el-text-color-regular);
      --el-cascader-menu-selected-text-color: var(--el-color-primary);
      --el-cascader-menu-fill: var(--el-bg-color-overlay);
      --el-cascader-menu-font-size: var(--el-font-size-base);
      --el-cascader-menu-radius: var(--el-border-radius-base);
      --el-cascader-menu-border: solid 1px var(--el-border-color-light);
      --el-cascader-menu-shadow: var(--el-box-shadow-light);
      --el-cascader-node-background-hover: var(--el-fill-color-light);
      --el-cascader-node-color-disabled: var(--el-text-color-placeholder);
      --el-cascader-color-empty: var(--el-text-color-placeholder);
      --el-cascader-tag-background: var(--el-fill-color)
    }

    .el-cascader-panel {
      display: flex;
      border-radius: var(--el-cascader-menu-radius);
      font-size: var(--el-cascader-menu-font-size)
    }

    .el-cascader-panel.is-bordered {
      border: var(--el-cascader-menu-border);
      border-radius: var(--el-cascader-menu-radius)
    }

    .el-cascader-menu {
      min-width: 180px;
      box-sizing: border-box;
      color: var(--el-cascader-menu-text-color);
      border-right: var(--el-cascader-menu-border)
    }

    .el-cascader-menu:last-child {
      border-right: none
    }

    .el-cascader-menu:last-child .el-cascader-node {
      padding-right: 20px
    }

    .el-cascader-menu__wrap.el-scrollbar__wrap {
      height: 204px
    }

    .el-cascader-menu__list {
      position: relative;
      min-height: 100%;
      margin: 0;
      padding: 6px 0;
      list-style: none;
      box-sizing: border-box
    }

    .el-cascader-menu__hover-zone {
      position: absolute;
      top: 0;
      left: 0;
      width: 100%;
      height: 100%;
      pointer-events: none
    }

    .el-cascader-menu__empty-text {
      position: absolute;
      top: 50%;
      left: 50%;
      transform: translate(-50%, -50%);
      display: flex;
      align-items: center;
      color: var(--el-cascader-color-empty)
    }

    .el-cascader-menu__empty-text .is-loading {
      margin-right: 2px
    }

    .el-cascader-node {
      position: relative;
      display: flex;
      align-items: center;
      padding: 0 30px 0 20px;
      height: 34px;
      line-height: 34px;
      outline: 0
    }

    .el-cascader-node.is-selectable.in-active-path {
      color: var(--el-cascader-menu-text-color)
    }

    .el-cascader-node.in-active-path,
    .el-cascader-node.is-active,
    .el-cascader-node.is-selectable.in-checked-path {
      color: var(--el-cascader-menu-selected-text-color);
      font-weight: 700
    }

    .el-cascader-node:not(.is-disabled) {
      cursor: pointer
    }

    .el-cascader-node:not(.is-disabled):focus,
    .el-cascader-node:not(.is-disabled):hover {
      background: var(--el-cascader-node-background-hover)
    }

    .el-cascader-node.is-disabled {
      color: var(--el-cascader-node-color-disabled);
      cursor: not-allowed
    }

    .el-cascader-node__prefix {
      position: absolute;
      left: 10px
    }

    .el-cascader-node__postfix {
      position: absolute;
      right: 10px
    }

    .el-cascader-node__label {
      flex: 1;
      text-align: left;
      padding: 0 8px;
      white-space: nowrap;
      overflow: hidden;
      text-overflow: ellipsis
    }

    .el-cascader-node>.el-checkbox {
      margin-right: 0
    }

    .el-cascader-node>.el-radio {
      margin-right: 0
    }

    .el-cascader-node>.el-radio .el-radio__label {
      padding-left: 0
    }

    .el-cascader {
      --el-cascader-menu-text-color: var(--el-text-color-regular);
      --el-cascader-menu-selected-text-color: var(--el-color-primary);
      --el-cascader-menu-fill: var(--el-bg-color-overlay);
      --el-cascader-menu-font-size: var(--el-font-size-base);
      --el-cascader-menu-radius: var(--el-border-radius-base);
      --el-cascader-menu-border: solid 1px var(--el-border-color-light);
      --el-cascader-menu-shadow: var(--el-box-shadow-light);
      --el-cascader-node-background-hover: var(--el-fill-color-light);
      --el-cascader-node-color-disabled: var(--el-text-color-placeholder);
      --el-cascader-color-empty: var(--el-text-color-placeholder);
      --el-cascader-tag-background: var(--el-fill-color);
      display: inline-block;
      vertical-align: middle;
      position: relative;
      font-size: var(--el-font-size-base);
      line-height: 32px;
      outline: 0
    }

    .el-cascader:not(.is-disabled):hover .el-input__wrapper {
      cursor: pointer;
      box-shadow: 0 0 0 1px var(--el-input-hover-border-color) inset
    }

    .el-cascader .el-input {
      display: flex;
      cursor: pointer
    }

    .el-cascader .el-input .el-input__inner {
      text-overflow: ellipsis;
      cursor: pointer
    }

    .el-cascader .el-input .el-input__suffix-inner .el-icon {
      height: calc(100% - 2px)
    }

    .el-cascader .el-input .el-input__suffix-inner .el-icon svg {
      vertical-align: middle
    }

    .el-cascader .el-input .icon-arrow-down {
      transition: transform var(--el-transition-duration);
      font-size: 14px
    }

    .el-cascader .el-input .icon-arrow-down.is-reverse {
      transform: rotateZ(180deg)
    }

    .el-cascader .el-input .icon-circle-close:hover {
      color: var(--el-input-clear-hover-color, var(--el-text-color-secondary))
    }

    .el-cascader .el-input.is-focus .el-input__wrapper {
      box-shadow: 0 0 0 1px var(--el-input-focus-border-color, var(--el-color-primary)) inset
    }

    .el-cascader--large {
      font-size: 14px;
      line-height: 40px
    }

    .el-cascader--small {
      font-size: 12px;
      line-height: 24px
    }

    .el-cascader.is-disabled .el-cascader__label {
      z-index: calc(var(--el-index-normal) + 1);
      color: var(--el-disabled-text-color)
    }

    .el-cascader__dropdown {
      --el-cascader-menu-text-color: var(--el-text-color-regular);
      --el-cascader-menu-selected-text-color: var(--el-color-primary);
      --el-cascader-menu-fill: var(--el-bg-color-overlay);
      --el-cascader-menu-font-size: var(--el-font-size-base);
      --el-cascader-menu-radius: var(--el-border-radius-base);
      --el-cascader-menu-border: solid 1px var(--el-border-color-light);
      --el-cascader-menu-shadow: var(--el-box-shadow-light);
      --el-cascader-node-background-hover: var(--el-fill-color-light);
      --el-cascader-node-color-disabled: var(--el-text-color-placeholder);
      --el-cascader-color-empty: var(--el-text-color-placeholder);
      --el-cascader-tag-background: var(--el-fill-color)
    }

    .el-cascader__dropdown {
      font-size: var(--el-cascader-menu-font-size);
      border-radius: var(--el-cascader-menu-radius)
    }

    .el-cascader__dropdown.el-popper {
      background: var(--el-cascader-menu-fill);
      border: var(--el-cascader-menu-border);
      box-shadow: var(--el-cascader-menu-shadow)
    }

    .el-cascader__dropdown.el-popper .el-popper__arrow::before {
      border: var(--el-cascader-menu-border)
    }

    .el-cascader__dropdown.el-popper[data-popper-placement^=top] .el-popper__arrow::before {
      border-top-color: transparent;
      border-left-color: transparent
    }

    .el-cascader__dropdown.el-popper[data-popper-placement^=bottom] .el-popper__arrow::before {
      border-bottom-color: transparent;
      border-right-color: transparent
    }

    .el-cascader__dropdown.el-popper[data-popper-placement^=left] .el-popper__arrow::before {
      border-left-color: transparent;
      border-bottom-color: transparent
    }

    .el-cascader__dropdown.el-popper[data-popper-placement^=right] .el-popper__arrow::before {
      border-right-color: transparent;
      border-top-color: transparent
    }

    .el-cascader__dropdown.el-popper {
      box-shadow: var(--el-cascader-menu-shadow)
    }

    .el-cascader__tags {
      position: absolute;
      left: 0;
      right: 30px;
      top: 50%;
      transform: translateY(-50%);
      display: flex;
      flex-wrap: wrap;
      line-height: normal;
      text-align: left;
      box-sizing: border-box
    }

    .el-cascader__tags .el-tag {
      display: inline-flex;
      align-items: center;
      max-width: 100%;
      margin: 2px 0 2px 6px;
      text-overflow: ellipsis;
      background: var(--el-cascader-tag-background)
    }

    .el-cascader__tags .el-tag:not(.is-hit) {
      border-color: transparent
    }

    .el-cascader__tags .el-tag>span {
      flex: 1;
      overflow: hidden;
      text-overflow: ellipsis
    }

    .el-cascader__tags .el-tag .el-icon-close {
      flex: none;
      background-color: var(--el-text-color-placeholder);
      color: var(--el-color-white)
    }

    .el-cascader__tags .el-tag .el-icon-close:hover {
      background-color: var(--el-text-color-secondary)
    }

    .el-cascader__collapse-tags {
      white-space: normal;
      z-index: var(--el-index-normal)
    }

    .el-cascader__collapse-tags .el-tag {
      display: inline-flex;
      align-items: center;
      max-width: 100%;
      margin: 2px 0 2px 6px;
      text-overflow: ellipsis;
      background: var(--el-fill-color)
    }

    .el-cascader__collapse-tags .el-tag:not(.is-hit) {
      border-color: transparent
    }

    .el-cascader__collapse-tags .el-tag>span {
      flex: 1;
      overflow: hidden;
      text-overflow: ellipsis
    }

    .el-cascader__collapse-tags .el-tag .el-icon-close {
      flex: none;
      background-color: var(--el-text-color-placeholder);
      color: var(--el-color-white)
    }

    .el-cascader__collapse-tags .el-tag .el-icon-close:hover {
      background-color: var(--el-text-color-secondary)
    }

    .el-cascader__suggestion-panel {
      border-radius: var(--el-cascader-menu-radius)
    }

    .el-cascader__suggestion-list {
      max-height: 204px;
      margin: 0;
      padding: 6px 0;
      font-size: var(--el-font-size-base);
      color: var(--el-cascader-menu-text-color);
      text-align: center
    }

    .el-cascader__suggestion-item {
      display: flex;
      justify-content: space-between;
      align-items: center;
      height: 34px;
      padding: 0 15px;
      text-align: left;
      outline: 0;
      cursor: pointer
    }

    .el-cascader__suggestion-item:focus,
    .el-cascader__suggestion-item:hover {
      background: var(--el-cascader-node-background-hover)
    }

    .el-cascader__suggestion-item.is-checked {
      color: var(--el-cascader-menu-selected-text-color);
      font-weight: 700
    }

    .el-cascader__suggestion-item>span {
      margin-right: 10px
    }

    .el-cascader__empty-text {
      margin: 10px 0;
      color: var(--el-cascader-color-empty)
    }

    .el-cascader__search-input {
      flex: 1;
      height: 24px;
      min-width: 60px;
      margin: 2px 0 2px 11px;
      padding: 0;
      color: var(--el-cascader-menu-text-color);
      border: none;
      outline: 0;
      box-sizing: border-box;
      background: 0 0
    }

    .el-cascader__search-input::-moz-placeholder {
      color: transparent
    }

    .el-cascader__search-input:-ms-input-placeholder {
      color: transparent
    }

    .el-cascader__search-input::placeholder {
      color: transparent
    }

    .el-check-tag {
      background-color: var(--el-color-info-light-9);
      border-radius: var(--el-border-radius-base);
      color: var(--el-color-info);
      cursor: pointer;
      display: inline-block;
      font-size: var(--el-font-size-base);
      line-height: var(--el-font-size-base);
      padding: 7px 15px;
      transition: var(--el-transition-all);
      font-weight: 700
    }

    .el-check-tag:hover {
      background-color: var(--el-color-info-light-7)
    }

    .el-check-tag.is-checked.el-check-tag--primary {
      background-color: var(--el-color-primary-light-8);
      color: var(--el-color-primary)
    }

    .el-check-tag.is-checked.el-check-tag--primary:hover {
      background-color: var(--el-color-primary-light-7)
    }

    .el-check-tag.is-checked.el-check-tag--success {
      background-color: var(--el-color-success-light-8);
      color: var(--el-color-success)
    }

    .el-check-tag.is-checked.el-check-tag--success:hover {
      background-color: var(--el-color-success-light-7)
    }

    .el-check-tag.is-checked.el-check-tag--warning {
      background-color: var(--el-color-warning-light-8);
      color: var(--el-color-warning)
    }

    .el-check-tag.is-checked.el-check-tag--warning:hover {
      background-color: var(--el-color-warning-light-7)
    }

    .el-check-tag.is-checked.el-check-tag--danger {
      background-color: var(--el-color-danger-light-8);
      color: var(--el-color-danger)
    }

    .el-check-tag.is-checked.el-check-tag--danger:hover {
      background-color: var(--el-color-danger-light-7)
    }

    .el-check-tag.is-checked.el-check-tag--error {
      background-color: var(--el-color-error-light-8);
      color: var(--el-color-error)
    }

    .el-check-tag.is-checked.el-check-tag--error:hover {
      background-color: var(--el-color-error-light-7)
    }

    .el-check-tag.is-checked.el-check-tag--info {
      background-color: var(--el-color-info-light-8);
      color: var(--el-color-info)
    }

    .el-check-tag.is-checked.el-check-tag--info:hover {
      background-color: var(--el-color-info-light-7)
    }

    .el-checkbox-button {
      --el-checkbox-button-checked-bg-color: var(--el-color-primary);
      --el-checkbox-button-checked-text-color: var(--el-color-white);
      --el-checkbox-button-checked-border-color: var(--el-color-primary)
    }

    .el-checkbox-button {
      position: relative;
      display: inline-block
    }

    .el-checkbox-button__inner {
      display: inline-block;
      line-height: 1;
      font-weight: var(--el-checkbox-font-weight);
      white-space: nowrap;
      vertical-align: middle;
      cursor: pointer;
      background: var(--el-button-bg-color, var(--el-fill-color-blank));
      border: var(--el-border);
      border-left-color: transparent;
      color: var(--el-button-text-color, var(--el-text-color-regular));
      -webkit-appearance: none;
      text-align: center;
      box-sizing: border-box;
      outline: 0;
      margin: 0;
      position: relative;
      transition: var(--el-transition-all);
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      padding: 8px 15px;
      font-size: var(--el-font-size-base);
      border-radius: 0
    }

    .el-checkbox-button__inner.is-round {
      padding: 8px 15px
    }

    .el-checkbox-button__inner:hover {
      color: var(--el-color-primary)
    }

    .el-checkbox-button__inner [class*=el-icon-] {
      line-height: .9
    }

    .el-checkbox-button__inner [class*=el-icon-]+span {
      margin-left: 5px
    }

    .el-checkbox-button__original {
      opacity: 0;
      outline: 0;
      position: absolute;
      margin: 0;
      z-index: -1
    }

    .el-checkbox-button.is-checked .el-checkbox-button__inner {
      color: var(--el-checkbox-button-checked-text-color);
      background-color: var(--el-checkbox-button-checked-bg-color);
      border-color: var(--el-checkbox-button-checked-border-color);
      box-shadow: -1px 0 0 0 var(--el-color-primary-light-7)
    }

    .el-checkbox-button.is-checked:first-child .el-checkbox-button__inner {
      border-left-color: var(--el-checkbox-button-checked-border-color)
    }

    .el-checkbox-button.is-disabled .el-checkbox-button__inner {
      color: var(--el-disabled-text-color);
      cursor: not-allowed;
      background-image: none;
      background-color: var(--el-button-disabled-bg-color, var(--el-fill-color-blank));
      border-color: var(--el-button-disabled-border-color, var(--el-border-color-light));
      box-shadow: none
    }

    .el-checkbox-button.is-disabled:first-child .el-checkbox-button__inner {
      border-left-color: var(--el-button-disabled-border-color, var(--el-border-color-light))
    }

    .el-checkbox-button:first-child .el-checkbox-button__inner {
      border-left: var(--el-border);
      border-top-left-radius: var(--el-border-radius-base);
      border-bottom-left-radius: var(--el-border-radius-base);
      box-shadow: none !important
    }

    .el-checkbox-button.is-focus .el-checkbox-button__inner {
      border-color: var(--el-checkbox-button-checked-border-color)
    }

    .el-checkbox-button:last-child .el-checkbox-button__inner {
      border-top-right-radius: var(--el-border-radius-base);
      border-bottom-right-radius: var(--el-border-radius-base)
    }

    .el-checkbox-button--large .el-checkbox-button__inner {
      padding: 12px 19px;
      font-size: var(--el-font-size-base);
      border-radius: 0
    }

    .el-checkbox-button--large .el-checkbox-button__inner.is-round {
      padding: 12px 19px
    }

    .el-checkbox-button--small .el-checkbox-button__inner {
      padding: 5px 11px;
      font-size: 12px;
      border-radius: 0
    }

    .el-checkbox-button--small .el-checkbox-button__inner.is-round {
      padding: 5px 11px
    }

    .el-checkbox-group {
      font-size: 0;
      line-height: 0
    }

    .el-checkbox {
      --el-checkbox-font-size: 14px;
      --el-checkbox-font-weight: var(--el-font-weight-primary);
      --el-checkbox-text-color: var(--el-text-color-regular);
      --el-checkbox-input-height: 14px;
      --el-checkbox-input-width: 14px;
      --el-checkbox-border-radius: var(--el-border-radius-small);
      --el-checkbox-bg-color: var(--el-fill-color-blank);
      --el-checkbox-input-border: var(--el-border);
      --el-checkbox-disabled-border-color: var(--el-border-color);
      --el-checkbox-disabled-input-fill: var(--el-fill-color-light);
      --el-checkbox-disabled-icon-color: var(--el-text-color-placeholder);
      --el-checkbox-disabled-checked-input-fill: var(--el-border-color-extra-light);
      --el-checkbox-disabled-checked-input-border-color: var(--el-border-color);
      --el-checkbox-disabled-checked-icon-color: var(--el-text-color-placeholder);
      --el-checkbox-checked-text-color: var(--el-color-primary);
      --el-checkbox-checked-input-border-color: var(--el-color-primary);
      --el-checkbox-checked-bg-color: var(--el-color-primary);
      --el-checkbox-checked-icon-color: var(--el-color-white);
      --el-checkbox-input-border-color-hover: var(--el-color-primary)
    }

    .el-checkbox {
      color: var(--el-checkbox-text-color);
      font-weight: var(--el-checkbox-font-weight);
      font-size: var(--el-font-size-base);
      position: relative;
      cursor: pointer;
      display: inline-flex;
      align-items: center;
      white-space: nowrap;
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      margin-right: 30px;
      height: var(--el-checkbox-height, 32px)
    }

    .el-checkbox.is-disabled {
      cursor: not-allowed
    }

    .el-checkbox.is-bordered {
      padding: 0 15px 0 9px;
      border-radius: var(--el-border-radius-base);
      border: var(--el-border);
      box-sizing: border-box
    }

    .el-checkbox.is-bordered.is-checked {
      border-color: var(--el-color-primary)
    }

    .el-checkbox.is-bordered.is-disabled {
      border-color: var(--el-border-color-lighter)
    }

    .el-checkbox.is-bordered.el-checkbox--large {
      padding: 0 19px 0 11px;
      border-radius: var(--el-border-radius-base)
    }

    .el-checkbox.is-bordered.el-checkbox--large .el-checkbox__label {
      font-size: var(--el-font-size-base)
    }

    .el-checkbox.is-bordered.el-checkbox--large .el-checkbox__inner {
      height: 14px;
      width: 14px
    }

    .el-checkbox.is-bordered.el-checkbox--small {
      padding: 0 11px 0 7px;
      border-radius: calc(var(--el-border-radius-base) - 1px)
    }

    .el-checkbox.is-bordered.el-checkbox--small .el-checkbox__label {
      font-size: 12px
    }

    .el-checkbox.is-bordered.el-checkbox--small .el-checkbox__inner {
      height: 12px;
      width: 12px
    }

    .el-checkbox.is-bordered.el-checkbox--small .el-checkbox__inner::after {
      height: 6px;
      width: 2px
    }

    .el-checkbox input:focus-visible+.el-checkbox__inner {
      outline: 2px solid var(--el-checkbox-input-border-color-hover);
      outline-offset: 1px;
      border-radius: var(--el-checkbox-border-radius)
    }

    .el-checkbox__input {
      white-space: nowrap;
      cursor: pointer;
      outline: 0;
      display: inline-flex;
      position: relative
    }

    .el-checkbox__input.is-disabled .el-checkbox__inner {
      background-color: var(--el-checkbox-disabled-input-fill);
      border-color: var(--el-checkbox-disabled-border-color);
      cursor: not-allowed
    }

    .el-checkbox__input.is-disabled .el-checkbox__inner::after {
      cursor: not-allowed;
      border-color: var(--el-checkbox-disabled-icon-color)
    }

    .el-checkbox__input.is-disabled.is-checked .el-checkbox__inner {
      background-color: var(--el-checkbox-disabled-checked-input-fill);
      border-color: var(--el-checkbox-disabled-checked-input-border-color)
    }

    .el-checkbox__input.is-disabled.is-checked .el-checkbox__inner::after {
      border-color: var(--el-checkbox-disabled-checked-icon-color)
    }

    .el-checkbox__input.is-disabled.is-indeterminate .el-checkbox__inner {
      background-color: var(--el-checkbox-disabled-checked-input-fill);
      border-color: var(--el-checkbox-disabled-checked-input-border-color)
    }

    .el-checkbox__input.is-disabled.is-indeterminate .el-checkbox__inner::before {
      background-color: var(--el-checkbox-disabled-checked-icon-color);
      border-color: var(--el-checkbox-disabled-checked-icon-color)
    }

    .el-checkbox__input.is-disabled+span.el-checkbox__label {
      color: var(--el-disabled-text-color);
      cursor: not-allowed
    }

    .el-checkbox__input.is-checked .el-checkbox__inner {
      background-color: var(--el-checkbox-checked-bg-color);
      border-color: var(--el-checkbox-checked-input-border-color)
    }

    .el-checkbox__input.is-checked .el-checkbox__inner::after {
      transform: rotate(45deg) scaleY(1);
      border-color: var(--el-checkbox-checked-icon-color)
    }

    .el-checkbox__input.is-checked+.el-checkbox__label {
      color: var(--el-checkbox-checked-text-color)
    }

    .el-checkbox__input.is-focus:not(.is-checked) .el-checkbox__original:not(:focus-visible) {
      border-color: var(--el-checkbox-input-border-color-hover)
    }

    .el-checkbox__input.is-indeterminate .el-checkbox__inner {
      background-color: var(--el-checkbox-checked-bg-color);
      border-color: var(--el-checkbox-checked-input-border-color)
    }

    .el-checkbox__input.is-indeterminate .el-checkbox__inner::before {
      content: """";
      position: absolute;
      display: block;
      background-color: var(--el-checkbox-checked-icon-color);
      height: 2px;
      transform: scale(.5);
      left: 0;
      right: 0;
      top: 5px
    }

    .el-checkbox__input.is-indeterminate .el-checkbox__inner::after {
      display: none
    }

    .el-checkbox__inner {
      display: inline-block;
      position: relative;
      border: var(--el-checkbox-input-border);
      border-radius: var(--el-checkbox-border-radius);
      box-sizing: border-box;
      width: var(--el-checkbox-input-width);
      height: var(--el-checkbox-input-height);
      background-color: var(--el-checkbox-bg-color);
      z-index: var(--el-index-normal);
      transition: border-color .25s cubic-bezier(.71, -.46, .29, 1.46), background-color .25s cubic-bezier(.71, -.46, .29, 1.46), outline .25s cubic-bezier(.71, -.46, .29, 1.46)
    }

    .el-checkbox__inner:hover {
      border-color: var(--el-checkbox-input-border-color-hover)
    }

    .el-checkbox__inner::after {
      box-sizing: content-box;
      content: """";
      border: 1px solid transparent;
      border-left: 0;
      border-top: 0;
      height: 7px;
      left: 4px;
      position: absolute;
      top: 1px;
      transform: rotate(45deg) scaleY(0);
      width: 3px;
      transition: transform .15s ease-in 50ms;
      transform-origin: center
    }

    .el-checkbox__original {
      opacity: 0;
      outline: 0;
      position: absolute;
      margin: 0;
      width: 0;
      height: 0;
      z-index: -1
    }

    .el-checkbox__label {
      display: inline-block;
      padding-left: 8px;
      line-height: 1;
      font-size: var(--el-checkbox-font-size)
    }

    .el-checkbox.el-checkbox--large {
      height: 40px
    }

    .el-checkbox.el-checkbox--large .el-checkbox__label {
      font-size: 14px
    }

    .el-checkbox.el-checkbox--large .el-checkbox__inner {
      width: 14px;
      height: 14px
    }

    .el-checkbox.el-checkbox--small {
      height: 24px
    }

    .el-checkbox.el-checkbox--small .el-checkbox__label {
      font-size: 12px
    }

    .el-checkbox.el-checkbox--small .el-checkbox__inner {
      width: 12px;
      height: 12px
    }

    .el-checkbox.el-checkbox--small .el-checkbox__input.is-indeterminate .el-checkbox__inner::before {
      top: 4px
    }

    .el-checkbox.el-checkbox--small .el-checkbox__inner::after {
      width: 2px;
      height: 6px
    }

    .el-checkbox:last-of-type {
      margin-right: 0
    }

    [class*=el-col-] {
      box-sizing: border-box
    }

    [class*=el-col-].is-guttered {
      display: block;
      min-height: 1px
    }

    .el-col-0 {
      display: none
    }

    .el-col-0.is-guttered {
      display: none
    }

    .el-col-0 {
      max-width: 0%;
      flex: 0 0 0%
    }

    .el-col-offset-0 {
      margin-left: 0
    }

    .el-col-pull-0 {
      position: relative;
      right: 0
    }

    .el-col-push-0 {
      position: relative;
      left: 0
    }

    .el-col-1 {
      max-width: 4.1666666667%;
      flex: 0 0 4.1666666667%
    }

    .el-col-offset-1 {
      margin-left: 4.1666666667%
    }

    .el-col-pull-1 {
      position: relative;
      right: 4.1666666667%
    }

    .el-col-push-1 {
      position: relative;
      left: 4.1666666667%
    }

    .el-col-2 {
      max-width: 8.3333333333%;
      flex: 0 0 8.3333333333%
    }

    .el-col-offset-2 {
      margin-left: 8.3333333333%
    }

    .el-col-pull-2 {
      position: relative;
      right: 8.3333333333%
    }

    .el-col-push-2 {
      position: relative;
      left: 8.3333333333%
    }

    .el-col-3 {
      max-width: 12.5%;
      flex: 0 0 12.5%
    }

    .el-col-offset-3 {
      margin-left: 12.5%
    }

    .el-col-pull-3 {
      position: relative;
      right: 12.5%
    }

    .el-col-push-3 {
      position: relative;
      left: 12.5%
    }

    .el-col-4 {
      max-width: 16.6666666667%;
      flex: 0 0 16.6666666667%
    }

    .el-col-offset-4 {
      margin-left: 16.6666666667%
    }

    .el-col-pull-4 {
      position: relative;
      right: 16.6666666667%
    }

    .el-col-push-4 {
      position: relative;
      left: 16.6666666667%
    }

    .el-col-5 {
      max-width: 20.8333333333%;
      flex: 0 0 20.8333333333%
    }

    .el-col-offset-5 {
      margin-left: 20.8333333333%
    }

    .el-col-pull-5 {
      position: relative;
      right: 20.8333333333%
    }

    .el-col-push-5 {
      position: relative;
      left: 20.8333333333%
    }

    .el-col-6 {
      max-width: 25%;
      flex: 0 0 25%
    }

    .el-col-offset-6 {
      margin-left: 25%
    }

    .el-col-pull-6 {
      position: relative;
      right: 25%
    }

    .el-col-push-6 {
      position: relative;
      left: 25%
    }

    .el-col-7 {
      max-width: 29.1666666667%;
      flex: 0 0 29.1666666667%
    }

    .el-col-offset-7 {
      margin-left: 29.1666666667%
    }

    .el-col-pull-7 {
      position: relative;
      right: 29.1666666667%
    }

    .el-col-push-7 {
      position: relative;
      left: 29.1666666667%
    }

    .el-col-8 {
      max-width: 33.3333333333%;
      flex: 0 0 33.3333333333%
    }

    .el-col-offset-8 {
      margin-left: 33.3333333333%
    }

    .el-col-pull-8 {
      position: relative;
      right: 33.3333333333%
    }

    .el-col-push-8 {
      position: relative;
      left: 33.3333333333%
    }

    .el-col-9 {
      max-width: 37.5%;
      flex: 0 0 37.5%
    }

    .el-col-offset-9 {
      margin-left: 37.5%
    }

    .el-col-pull-9 {
      position: relative;
      right: 37.5%
    }

    .el-col-push-9 {
      position: relative;
      left: 37.5%
    }

    .el-col-10 {
      max-width: 41.6666666667%;
      flex: 0 0 41.6666666667%
    }

    .el-col-offset-10 {
      margin-left: 41.6666666667%
    }

    .el-col-pull-10 {
      position: relative;
      right: 41.6666666667%
    }

    .el-col-push-10 {
      position: relative;
      left: 41.6666666667%
    }

    .el-col-11 {
      max-width: 45.8333333333%;
      flex: 0 0 45.8333333333%
    }

    .el-col-offset-11 {
      margin-left: 45.8333333333%
    }

    .el-col-pull-11 {
      position: relative;
      right: 45.8333333333%
    }

    .el-col-push-11 {
      position: relative;
      left: 45.8333333333%
    }

    .el-col-12 {
      max-width: 50%;
      flex: 0 0 50%
    }

    .el-col-offset-12 {
      margin-left: 50%
    }

    .el-col-pull-12 {
      position: relative;
      right: 50%
    }

    .el-col-push-12 {
      position: relative;
      left: 50%
    }

    .el-col-13 {
      max-width: 54.1666666667%;
      flex: 0 0 54.1666666667%
    }

    .el-col-offset-13 {
      margin-left: 54.1666666667%
    }

    .el-col-pull-13 {
      position: relative;
      right: 54.1666666667%
    }

    .el-col-push-13 {
      position: relative;
      left: 54.1666666667%
    }

    .el-col-14 {
      max-width: 58.3333333333%;
      flex: 0 0 58.3333333333%
    }

    .el-col-offset-14 {
      margin-left: 58.3333333333%
    }

    .el-col-pull-14 {
      position: relative;
      right: 58.3333333333%
    }

    .el-col-push-14 {
      position: relative;
      left: 58.3333333333%
    }

    .el-col-15 {
      max-width: 62.5%;
      flex: 0 0 62.5%
    }

    .el-col-offset-15 {
      margin-left: 62.5%
    }

    .el-col-pull-15 {
      position: relative;
      right: 62.5%
    }

    .el-col-push-15 {
      position: relative;
      left: 62.5%
    }

    .el-col-16 {
      max-width: 66.6666666667%;
      flex: 0 0 66.6666666667%
    }

    .el-col-offset-16 {
      margin-left: 66.6666666667%
    }

    .el-col-pull-16 {
      position: relative;
      right: 66.6666666667%
    }

    .el-col-push-16 {
      position: relative;
      left: 66.6666666667%
    }

    .el-col-17 {
      max-width: 70.8333333333%;
      flex: 0 0 70.8333333333%
    }

    .el-col-offset-17 {
      margin-left: 70.8333333333%
    }

    .el-col-pull-17 {
      position: relative;
      right: 70.8333333333%
    }

    .el-col-push-17 {
      position: relative;
      left: 70.8333333333%
    }

    .el-col-18 {
      max-width: 75%;
      flex: 0 0 75%
    }

    .el-col-offset-18 {
      margin-left: 75%
    }

    .el-col-pull-18 {
      position: relative;
      right: 75%
    }

    .el-col-push-18 {
      position: relative;
      left: 75%
    }

    .el-col-19 {
      max-width: 79.1666666667%;
      flex: 0 0 79.1666666667%
    }

    .el-col-offset-19 {
      margin-left: 79.1666666667%
    }

    .el-col-pull-19 {
      position: relative;
      right: 79.1666666667%
    }

    .el-col-push-19 {
      position: relative;
      left: 79.1666666667%
    }

    .el-col-20 {
      max-width: 83.3333333333%;
      flex: 0 0 83.3333333333%
    }

    .el-col-offset-20 {
      margin-left: 83.3333333333%
    }

    .el-col-pull-20 {
      position: relative;
      right: 83.3333333333%
    }

    .el-col-push-20 {
      position: relative;
      left: 83.3333333333%
    }

    .el-col-21 {
      max-width: 87.5%;
      flex: 0 0 87.5%
    }

    .el-col-offset-21 {
      margin-left: 87.5%
    }

    .el-col-pull-21 {
      position: relative;
      right: 87.5%
    }

    .el-col-push-21 {
      position: relative;
      left: 87.5%
    }

    .el-col-22 {
      max-width: 91.6666666667%;
      flex: 0 0 91.6666666667%
    }

    .el-col-offset-22 {
      margin-left: 91.6666666667%
    }

    .el-col-pull-22 {
      position: relative;
      right: 91.6666666667%
    }

    .el-col-push-22 {
      position: relative;
      left: 91.6666666667%
    }

    .el-col-23 {
      max-width: 95.8333333333%;
      flex: 0 0 95.8333333333%
    }

    .el-col-offset-23 {
      margin-left: 95.8333333333%
    }

    .el-col-pull-23 {
      position: relative;
      right: 95.8333333333%
    }

    .el-col-push-23 {
      position: relative;
      left: 95.8333333333%
    }

    .el-col-24 {
      max-width: 100%;
      flex: 0 0 100%
    }

    .el-col-offset-24 {
      margin-left: 100%
    }

    .el-col-pull-24 {
      position: relative;
      right: 100%
    }

    .el-col-push-24 {
      position: relative;
      left: 100%
    }

    @media only screen and (max-width:767px) {
      .el-col-xs-0 {
        display: none
      }

      .el-col-xs-0.is-guttered {
        display: none
      }

      .el-col-xs-0 {
        max-width: 0%;
        flex: 0 0 0%
      }

      .el-col-xs-offset-0 {
        margin-left: 0
      }

      .el-col-xs-pull-0 {
        position: relative;
        right: 0
      }

      .el-col-xs-push-0 {
        position: relative;
        left: 0
      }

      .el-col-xs-1 {
        display: block;
        max-width: 4.1666666667%;
        flex: 0 0 4.1666666667%
      }

      .el-col-xs-offset-1 {
        margin-left: 4.1666666667%
      }

      .el-col-xs-pull-1 {
        position: relative;
        right: 4.1666666667%
      }

      .el-col-xs-push-1 {
        position: relative;
        left: 4.1666666667%
      }

      .el-col-xs-2 {
        display: block;
        max-width: 8.3333333333%;
        flex: 0 0 8.3333333333%
      }

      .el-col-xs-offset-2 {
        margin-left: 8.3333333333%
      }

      .el-col-xs-pull-2 {
        position: relative;
        right: 8.3333333333%
      }

      .el-col-xs-push-2 {
        position: relative;
        left: 8.3333333333%
      }

      .el-col-xs-3 {
        display: block;
        max-width: 12.5%;
        flex: 0 0 12.5%
      }

      .el-col-xs-offset-3 {
        margin-left: 12.5%
      }

      .el-col-xs-pull-3 {
        position: relative;
        right: 12.5%
      }

      .el-col-xs-push-3 {
        position: relative;
        left: 12.5%
      }

      .el-col-xs-4 {
        display: block;
        max-width: 16.6666666667%;
        flex: 0 0 16.6666666667%
      }

      .el-col-xs-offset-4 {
        margin-left: 16.6666666667%
      }

      .el-col-xs-pull-4 {
        position: relative;
        right: 16.6666666667%
      }

      .el-col-xs-push-4 {
        position: relative;
        left: 16.6666666667%
      }

      .el-col-xs-5 {
        display: block;
        max-width: 20.8333333333%;
        flex: 0 0 20.8333333333%
      }

      .el-col-xs-offset-5 {
        margin-left: 20.8333333333%
      }

      .el-col-xs-pull-5 {
        position: relative;
        right: 20.8333333333%
      }

      .el-col-xs-push-5 {
        position: relative;
        left: 20.8333333333%
      }

      .el-col-xs-6 {
        display: block;
        max-width: 25%;
        flex: 0 0 25%
      }

      .el-col-xs-offset-6 {
        margin-left: 25%
      }

      .el-col-xs-pull-6 {
        position: relative;
        right: 25%
      }

      .el-col-xs-push-6 {
        position: relative;
        left: 25%
      }

      .el-col-xs-7 {
        display: block;
        max-width: 29.1666666667%;
        flex: 0 0 29.1666666667%
      }

      .el-col-xs-offset-7 {
        margin-left: 29.1666666667%
      }

      .el-col-xs-pull-7 {
        position: relative;
        right: 29.1666666667%
      }

      .el-col-xs-push-7 {
        position: relative;
        left: 29.1666666667%
      }

      .el-col-xs-8 {
        display: block;
        max-width: 33.3333333333%;
        flex: 0 0 33.3333333333%
      }

      .el-col-xs-offset-8 {
        margin-left: 33.3333333333%
      }

      .el-col-xs-pull-8 {
        position: relative;
        right: 33.3333333333%
      }

      .el-col-xs-push-8 {
        position: relative;
        left: 33.3333333333%
      }

      .el-col-xs-9 {
        display: block;
        max-width: 37.5%;
        flex: 0 0 37.5%
      }

      .el-col-xs-offset-9 {
        margin-left: 37.5%
      }

      .el-col-xs-pull-9 {
        position: relative;
        right: 37.5%
      }

      .el-col-xs-push-9 {
        position: relative;
        left: 37.5%
      }

      .el-col-xs-10 {
        display: block;
        max-width: 41.6666666667%;
        flex: 0 0 41.6666666667%
      }

      .el-col-xs-offset-10 {
        margin-left: 41.6666666667%
      }

      .el-col-xs-pull-10 {
        position: relative;
        right: 41.6666666667%
      }

      .el-col-xs-push-10 {
        position: relative;
        left: 41.6666666667%
      }

      .el-col-xs-11 {
        display: block;
        max-width: 45.8333333333%;
        flex: 0 0 45.8333333333%
      }

      .el-col-xs-offset-11 {
        margin-left: 45.8333333333%
      }

      .el-col-xs-pull-11 {
        position: relative;
        right: 45.8333333333%
      }

      .el-col-xs-push-11 {
        position: relative;
        left: 45.8333333333%
      }

      .el-col-xs-12 {
        display: block;
        max-width: 50%;
        flex: 0 0 50%
      }

      .el-col-xs-offset-12 {
        margin-left: 50%
      }

      .el-col-xs-pull-12 {
        position: relative;
        right: 50%
      }

      .el-col-xs-push-12 {
        position: relative;
        left: 50%
      }

      .el-col-xs-13 {
        display: block;
        max-width: 54.1666666667%;
        flex: 0 0 54.1666666667%
      }

      .el-col-xs-offset-13 {
        margin-left: 54.1666666667%
      }

      .el-col-xs-pull-13 {
        position: relative;
        right: 54.1666666667%
      }

      .el-col-xs-push-13 {
        position: relative;
        left: 54.1666666667%
      }

      .el-col-xs-14 {
        display: block;
        max-width: 58.3333333333%;
        flex: 0 0 58.3333333333%
      }

      .el-col-xs-offset-14 {
        margin-left: 58.3333333333%
      }

      .el-col-xs-pull-14 {
        position: relative;
        right: 58.3333333333%
      }

      .el-col-xs-push-14 {
        position: relative;
        left: 58.3333333333%
      }

      .el-col-xs-15 {
        display: block;
        max-width: 62.5%;
        flex: 0 0 62.5%
      }

      .el-col-xs-offset-15 {
        margin-left: 62.5%
      }

      .el-col-xs-pull-15 {
        position: relative;
        right: 62.5%
      }

      .el-col-xs-push-15 {
        position: relative;
        left: 62.5%
      }

      .el-col-xs-16 {
        display: block;
        max-width: 66.6666666667%;
        flex: 0 0 66.6666666667%
      }

      .el-col-xs-offset-16 {
        margin-left: 66.6666666667%
      }

      .el-col-xs-pull-16 {
        position: relative;
        right: 66.6666666667%
      }

      .el-col-xs-push-16 {
        position: relative;
        left: 66.6666666667%
      }

      .el-col-xs-17 {
        display: block;
        max-width: 70.8333333333%;
        flex: 0 0 70.8333333333%
      }

      .el-col-xs-offset-17 {
        margin-left: 70.8333333333%
      }

      .el-col-xs-pull-17 {
        position: relative;
        right: 70.8333333333%
      }

      .el-col-xs-push-17 {
        position: relative;
        left: 70.8333333333%
      }

      .el-col-xs-18 {
        display: block;
        max-width: 75%;
        flex: 0 0 75%
      }

      .el-col-xs-offset-18 {
        margin-left: 75%
      }

      .el-col-xs-pull-18 {
        position: relative;
        right: 75%
      }

      .el-col-xs-push-18 {
        position: relative;
        left: 75%
      }

      .el-col-xs-19 {
        display: block;
        max-width: 79.1666666667%;
        flex: 0 0 79.1666666667%
      }

      .el-col-xs-offset-19 {
        margin-left: 79.1666666667%
      }

      .el-col-xs-pull-19 {
        position: relative;
        right: 79.1666666667%
      }

      .el-col-xs-push-19 {
        position: relative;
        left: 79.1666666667%
      }

      .el-col-xs-20 {
        display: block;
        max-width: 83.3333333333%;
        flex: 0 0 83.3333333333%
      }

      .el-col-xs-offset-20 {
        margin-left: 83.3333333333%
      }

      .el-col-xs-pull-20 {
        position: relative;
        right: 83.3333333333%
      }

      .el-col-xs-push-20 {
        position: relative;
        left: 83.3333333333%
      }

      .el-col-xs-21 {
        display: block;
        max-width: 87.5%;
        flex: 0 0 87.5%
      }

      .el-col-xs-offset-21 {
        margin-left: 87.5%
      }

      .el-col-xs-pull-21 {
        position: relative;
        right: 87.5%
      }

      .el-col-xs-push-21 {
        position: relative;
        left: 87.5%
      }

      .el-col-xs-22 {
        display: block;
        max-width: 91.6666666667%;
        flex: 0 0 91.6666666667%
      }

      .el-col-xs-offset-22 {
        margin-left: 91.6666666667%
      }

      .el-col-xs-pull-22 {
        position: relative;
        right: 91.6666666667%
      }

      .el-col-xs-push-22 {
        position: relative;
        left: 91.6666666667%
      }

      .el-col-xs-23 {
        display: block;
        max-width: 95.8333333333%;
        flex: 0 0 95.8333333333%
      }

      .el-col-xs-offset-23 {
        margin-left: 95.8333333333%
      }

      .el-col-xs-pull-23 {
        position: relative;
        right: 95.8333333333%
      }

      .el-col-xs-push-23 {
        position: relative;
        left: 95.8333333333%
      }

      .el-col-xs-24 {
        display: block;
        max-width: 100%;
        flex: 0 0 100%
      }

      .el-col-xs-offset-24 {
        margin-left: 100%
      }

      .el-col-xs-pull-24 {
        position: relative;
        right: 100%
      }

      .el-col-xs-push-24 {
        position: relative;
        left: 100%
      }
    }

    @media only screen and (min-width:768px) {
      .el-col-sm-0 {
        display: none
      }

      .el-col-sm-0.is-guttered {
        display: none
      }

      .el-col-sm-0 {
        max-width: 0%;
        flex: 0 0 0%
      }

      .el-col-sm-offset-0 {
        margin-left: 0
      }

      .el-col-sm-pull-0 {
        position: relative;
        right: 0
      }

      .el-col-sm-push-0 {
        position: relative;
        left: 0
      }

      .el-col-sm-1 {
        display: block;
        max-width: 4.1666666667%;
        flex: 0 0 4.1666666667%
      }

      .el-col-sm-offset-1 {
        margin-left: 4.1666666667%
      }

      .el-col-sm-pull-1 {
        position: relative;
        right: 4.1666666667%
      }

      .el-col-sm-push-1 {
        position: relative;
        left: 4.1666666667%
      }

      .el-col-sm-2 {
        display: block;
        max-width: 8.3333333333%;
        flex: 0 0 8.3333333333%
      }

      .el-col-sm-offset-2 {
        margin-left: 8.3333333333%
      }

      .el-col-sm-pull-2 {
        position: relative;
        right: 8.3333333333%
      }

      .el-col-sm-push-2 {
        position: relative;
        left: 8.3333333333%
      }

      .el-col-sm-3 {
        display: block;
        max-width: 12.5%;
        flex: 0 0 12.5%
      }

      .el-col-sm-offset-3 {
        margin-left: 12.5%
      }

      .el-col-sm-pull-3 {
        position: relative;
        right: 12.5%
      }

      .el-col-sm-push-3 {
        position: relative;
        left: 12.5%
      }

      .el-col-sm-4 {
        display: block;
        max-width: 16.6666666667%;
        flex: 0 0 16.6666666667%
      }

      .el-col-sm-offset-4 {
        margin-left: 16.6666666667%
      }

      .el-col-sm-pull-4 {
        position: relative;
        right: 16.6666666667%
      }

      .el-col-sm-push-4 {
        position: relative;
        left: 16.6666666667%
      }

      .el-col-sm-5 {
        display: block;
        max-width: 20.8333333333%;
        flex: 0 0 20.8333333333%
      }

      .el-col-sm-offset-5 {
        margin-left: 20.8333333333%
      }

      .el-col-sm-pull-5 {
        position: relative;
        right: 20.8333333333%
      }

      .el-col-sm-push-5 {
        position: relative;
        left: 20.8333333333%
      }

      .el-col-sm-6 {
        display: block;
        max-width: 25%;
        flex: 0 0 25%
      }

      .el-col-sm-offset-6 {
        margin-left: 25%
      }

      .el-col-sm-pull-6 {
        position: relative;
        right: 25%
      }

      .el-col-sm-push-6 {
        position: relative;
        left: 25%
      }

      .el-col-sm-7 {
        display: block;
        max-width: 29.1666666667%;
        flex: 0 0 29.1666666667%
      }

      .el-col-sm-offset-7 {
        margin-left: 29.1666666667%
      }

      .el-col-sm-pull-7 {
        position: relative;
        right: 29.1666666667%
      }

      .el-col-sm-push-7 {
        position: relative;
        left: 29.1666666667%
      }

      .el-col-sm-8 {
        display: block;
        max-width: 33.3333333333%;
        flex: 0 0 33.3333333333%
      }

      .el-col-sm-offset-8 {
        margin-left: 33.3333333333%
      }

      .el-col-sm-pull-8 {
        position: relative;
        right: 33.3333333333%
      }

      .el-col-sm-push-8 {
        position: relative;
        left: 33.3333333333%
      }

      .el-col-sm-9 {
        display: block;
        max-width: 37.5%;
        flex: 0 0 37.5%
      }

      .el-col-sm-offset-9 {
        margin-left: 37.5%
      }

      .el-col-sm-pull-9 {
        position: relative;
        right: 37.5%
      }

      .el-col-sm-push-9 {
        position: relative;
        left: 37.5%
      }

      .el-col-sm-10 {
        display: block;
        max-width: 41.6666666667%;
        flex: 0 0 41.6666666667%
      }

      .el-col-sm-offset-10 {
        margin-left: 41.6666666667%
      }

      .el-col-sm-pull-10 {
        position: relative;
        right: 41.6666666667%
      }

      .el-col-sm-push-10 {
        position: relative;
        left: 41.6666666667%
      }

      .el-col-sm-11 {
        display: block;
        max-width: 45.8333333333%;
        flex: 0 0 45.8333333333%
      }

      .el-col-sm-offset-11 {
        margin-left: 45.8333333333%
      }

      .el-col-sm-pull-11 {
        position: relative;
        right: 45.8333333333%
      }

      .el-col-sm-push-11 {
        position: relative;
        left: 45.8333333333%
      }

      .el-col-sm-12 {
        display: block;
        max-width: 50%;
        flex: 0 0 50%
      }

      .el-col-sm-offset-12 {
        margin-left: 50%
      }

      .el-col-sm-pull-12 {
        position: relative;
        right: 50%
      }

      .el-col-sm-push-12 {
        position: relative;
        left: 50%
      }

      .el-col-sm-13 {
        display: block;
        max-width: 54.1666666667%;
        flex: 0 0 54.1666666667%
      }

      .el-col-sm-offset-13 {
        margin-left: 54.1666666667%
      }

      .el-col-sm-pull-13 {
        position: relative;
        right: 54.1666666667%
      }

      .el-col-sm-push-13 {
        position: relative;
        left: 54.1666666667%
      }

      .el-col-sm-14 {
        display: block;
        max-width: 58.3333333333%;
        flex: 0 0 58.3333333333%
      }

      .el-col-sm-offset-14 {
        margin-left: 58.3333333333%
      }

      .el-col-sm-pull-14 {
        position: relative;
        right: 58.3333333333%
      }

      .el-col-sm-push-14 {
        position: relative;
        left: 58.3333333333%
      }

      .el-col-sm-15 {
        display: block;
        max-width: 62.5%;
        flex: 0 0 62.5%
      }

      .el-col-sm-offset-15 {
        margin-left: 62.5%
      }

      .el-col-sm-pull-15 {
        position: relative;
        right: 62.5%
      }

      .el-col-sm-push-15 {
        position: relative;
        left: 62.5%
      }

      .el-col-sm-16 {
        display: block;
        max-width: 66.6666666667%;
        flex: 0 0 66.6666666667%
      }

      .el-col-sm-offset-16 {
        margin-left: 66.6666666667%
      }

      .el-col-sm-pull-16 {
        position: relative;
        right: 66.6666666667%
      }

      .el-col-sm-push-16 {
        position: relative;
        left: 66.6666666667%
      }

      .el-col-sm-17 {
        display: block;
        max-width: 70.8333333333%;
        flex: 0 0 70.8333333333%
      }

      .el-col-sm-offset-17 {
        margin-left: 70.8333333333%
      }

      .el-col-sm-pull-17 {
        position: relative;
        right: 70.8333333333%
      }

      .el-col-sm-push-17 {
        position: relative;
        left: 70.8333333333%
      }

      .el-col-sm-18 {
        display: block;
        max-width: 75%;
        flex: 0 0 75%
      }

      .el-col-sm-offset-18 {
        margin-left: 75%
      }

      .el-col-sm-pull-18 {
        position: relative;
        right: 75%
      }

      .el-col-sm-push-18 {
        position: relative;
        left: 75%
      }

      .el-col-sm-19 {
        display: block;
        max-width: 79.1666666667%;
        flex: 0 0 79.1666666667%
      }

      .el-col-sm-offset-19 {
        margin-left: 79.1666666667%
      }

      .el-col-sm-pull-19 {
        position: relative;
        right: 79.1666666667%
      }

      .el-col-sm-push-19 {
        position: relative;
        left: 79.1666666667%
      }

      .el-col-sm-20 {
        display: block;
        max-width: 83.3333333333%;
        flex: 0 0 83.3333333333%
      }

      .el-col-sm-offset-20 {
        margin-left: 83.3333333333%
      }

      .el-col-sm-pull-20 {
        position: relative;
        right: 83.3333333333%
      }

      .el-col-sm-push-20 {
        position: relative;
        left: 83.3333333333%
      }

      .el-col-sm-21 {
        display: block;
        max-width: 87.5%;
        flex: 0 0 87.5%
      }

      .el-col-sm-offset-21 {
        margin-left: 87.5%
      }

      .el-col-sm-pull-21 {
        position: relative;
        right: 87.5%
      }

      .el-col-sm-push-21 {
        position: relative;
        left: 87.5%
      }

      .el-col-sm-22 {
        display: block;
        max-width: 91.6666666667%;
        flex: 0 0 91.6666666667%
      }

      .el-col-sm-offset-22 {
        margin-left: 91.6666666667%
      }

      .el-col-sm-pull-22 {
        position: relative;
        right: 91.6666666667%
      }

      .el-col-sm-push-22 {
        position: relative;
        left: 91.6666666667%
      }

      .el-col-sm-23 {
        display: block;
        max-width: 95.8333333333%;
        flex: 0 0 95.8333333333%
      }

      .el-col-sm-offset-23 {
        margin-left: 95.8333333333%
      }

      .el-col-sm-pull-23 {
        position: relative;
        right: 95.8333333333%
      }

      .el-col-sm-push-23 {
        position: relative;
        left: 95.8333333333%
      }

      .el-col-sm-24 {
        display: block;
        max-width: 100%;
        flex: 0 0 100%
      }

      .el-col-sm-offset-24 {
        margin-left: 100%
      }

      .el-col-sm-pull-24 {
        position: relative;
        right: 100%
      }

      .el-col-sm-push-24 {
        position: relative;
        left: 100%
      }
    }

    @media only screen and (min-width:992px) {
      .el-col-md-0 {
        display: none
      }

      .el-col-md-0.is-guttered {
        display: none
      }

      .el-col-md-0 {
        max-width: 0%;
        flex: 0 0 0%
      }

      .el-col-md-offset-0 {
        margin-left: 0
      }

      .el-col-md-pull-0 {
        position: relative;
        right: 0
      }

      .el-col-md-push-0 {
        position: relative;
        left: 0
      }

      .el-col-md-1 {
        display: block;
        max-width: 4.1666666667%;
        flex: 0 0 4.1666666667%
      }

      .el-col-md-offset-1 {
        margin-left: 4.1666666667%
      }

      .el-col-md-pull-1 {
        position: relative;
        right: 4.1666666667%
      }

      .el-col-md-push-1 {
        position: relative;
        left: 4.1666666667%
      }

      .el-col-md-2 {
        display: block;
        max-width: 8.3333333333%;
        flex: 0 0 8.3333333333%
      }

      .el-col-md-offset-2 {
        margin-left: 8.3333333333%
      }

      .el-col-md-pull-2 {
        position: relative;
        right: 8.3333333333%
      }

      .el-col-md-push-2 {
        position: relative;
        left: 8.3333333333%
      }

      .el-col-md-3 {
        display: block;
        max-width: 12.5%;
        flex: 0 0 12.5%
      }

      .el-col-md-offset-3 {
        margin-left: 12.5%
      }

      .el-col-md-pull-3 {
        position: relative;
        right: 12.5%
      }

      .el-col-md-push-3 {
        position: relative;
        left: 12.5%
      }

      .el-col-md-4 {
        display: block;
        max-width: 16.6666666667%;
        flex: 0 0 16.6666666667%
      }

      .el-col-md-offset-4 {
        margin-left: 16.6666666667%
      }

      .el-col-md-pull-4 {
        position: relative;
        right: 16.6666666667%
      }

      .el-col-md-push-4 {
        position: relative;
        left: 16.6666666667%
      }

      .el-col-md-5 {
        display: block;
        max-width: 20.8333333333%;
        flex: 0 0 20.8333333333%
      }

      .el-col-md-offset-5 {
        margin-left: 20.8333333333%
      }

      .el-col-md-pull-5 {
        position: relative;
        right: 20.8333333333%
      }

      .el-col-md-push-5 {
        position: relative;
        left: 20.8333333333%
      }

      .el-col-md-6 {
        display: block;
        max-width: 25%;
        flex: 0 0 25%
      }

      .el-col-md-offset-6 {
        margin-left: 25%
      }

      .el-col-md-pull-6 {
        position: relative;
        right: 25%
      }

      .el-col-md-push-6 {
        position: relative;
        left: 25%
      }

      .el-col-md-7 {
        display: block;
        max-width: 29.1666666667%;
        flex: 0 0 29.1666666667%
      }

      .el-col-md-offset-7 {
        margin-left: 29.1666666667%
      }

      .el-col-md-pull-7 {
        position: relative;
        right: 29.1666666667%
      }

      .el-col-md-push-7 {
        position: relative;
        left: 29.1666666667%
      }

      .el-col-md-8 {
        display: block;
        max-width: 33.3333333333%;
        flex: 0 0 33.3333333333%
      }

      .el-col-md-offset-8 {
        margin-left: 33.3333333333%
      }

      .el-col-md-pull-8 {
        position: relative;
        right: 33.3333333333%
      }

      .el-col-md-push-8 {
        position: relative;
        left: 33.3333333333%
      }

      .el-col-md-9 {
        display: block;
        max-width: 37.5%;
        flex: 0 0 37.5%
      }

      .el-col-md-offset-9 {
        margin-left: 37.5%
      }

      .el-col-md-pull-9 {
        position: relative;
        right: 37.5%
      }

      .el-col-md-push-9 {
        position: relative;
        left: 37.5%
      }

      .el-col-md-10 {
        display: block;
        max-width: 41.6666666667%;
        flex: 0 0 41.6666666667%
      }

      .el-col-md-offset-10 {
        margin-left: 41.6666666667%
      }

      .el-col-md-pull-10 {
        position: relative;
        right: 41.6666666667%
      }

      .el-col-md-push-10 {
        position: relative;
        left: 41.6666666667%
      }

      .el-col-md-11 {
        display: block;
        max-width: 45.8333333333%;
        flex: 0 0 45.8333333333%
      }

      .el-col-md-offset-11 {
        margin-left: 45.8333333333%
      }

      .el-col-md-pull-11 {
        position: relative;
        right: 45.8333333333%
      }

      .el-col-md-push-11 {
        position: relative;
        left: 45.8333333333%
      }

      .el-col-md-12 {
        display: block;
        max-width: 50%;
        flex: 0 0 50%
      }

      .el-col-md-offset-12 {
        margin-left: 50%
      }

      .el-col-md-pull-12 {
        position: relative;
        right: 50%
      }

      .el-col-md-push-12 {
        position: relative;
        left: 50%
      }

      .el-col-md-13 {
        display: block;
        max-width: 54.1666666667%;
        flex: 0 0 54.1666666667%
      }

      .el-col-md-offset-13 {
        margin-left: 54.1666666667%
      }

      .el-col-md-pull-13 {
        position: relative;
        right: 54.1666666667%
      }

      .el-col-md-push-13 {
        position: relative;
        left: 54.1666666667%
      }

      .el-col-md-14 {
        display: block;
        max-width: 58.3333333333%;
        flex: 0 0 58.3333333333%
      }

      .el-col-md-offset-14 {
        margin-left: 58.3333333333%
      }

      .el-col-md-pull-14 {
        position: relative;
        right: 58.3333333333%
      }

      .el-col-md-push-14 {
        position: relative;
        left: 58.3333333333%
      }

      .el-col-md-15 {
        display: block;
        max-width: 62.5%;
        flex: 0 0 62.5%
      }

      .el-col-md-offset-15 {
        margin-left: 62.5%
      }

      .el-col-md-pull-15 {
        position: relative;
        right: 62.5%
      }

      .el-col-md-push-15 {
        position: relative;
        left: 62.5%
      }

      .el-col-md-16 {
        display: block;
        max-width: 66.6666666667%;
        flex: 0 0 66.6666666667%
      }

      .el-col-md-offset-16 {
        margin-left: 66.6666666667%
      }

      .el-col-md-pull-16 {
        position: relative;
        right: 66.6666666667%
      }

      .el-col-md-push-16 {
        position: relative;
        left: 66.6666666667%
      }

      .el-col-md-17 {
        display: block;
        max-width: 70.8333333333%;
        flex: 0 0 70.8333333333%
      }

      .el-col-md-offset-17 {
        margin-left: 70.8333333333%
      }

      .el-col-md-pull-17 {
        position: relative;
        right: 70.8333333333%
      }

      .el-col-md-push-17 {
        position: relative;
        left: 70.8333333333%
      }

      .el-col-md-18 {
        display: block;
        max-width: 75%;
        flex: 0 0 75%
      }

      .el-col-md-offset-18 {
        margin-left: 75%
      }

      .el-col-md-pull-18 {
        position: relative;
        right: 75%
      }

      .el-col-md-push-18 {
        position: relative;
        left: 75%
      }

      .el-col-md-19 {
        display: block;
        max-width: 79.1666666667%;
        flex: 0 0 79.1666666667%
      }

      .el-col-md-offset-19 {
        margin-left: 79.1666666667%
      }

      .el-col-md-pull-19 {
        position: relative;
        right: 79.1666666667%
      }

      .el-col-md-push-19 {
        position: relative;
        left: 79.1666666667%
      }

      .el-col-md-20 {
        display: block;
        max-width: 83.3333333333%;
        flex: 0 0 83.3333333333%
      }

      .el-col-md-offset-20 {
        margin-left: 83.3333333333%
      }

      .el-col-md-pull-20 {
        position: relative;
        right: 83.3333333333%
      }

      .el-col-md-push-20 {
        position: relative;
        left: 83.3333333333%
      }

      .el-col-md-21 {
        display: block;
        max-width: 87.5%;
        flex: 0 0 87.5%
      }

      .el-col-md-offset-21 {
        margin-left: 87.5%
      }

      .el-col-md-pull-21 {
        position: relative;
        right: 87.5%
      }

      .el-col-md-push-21 {
        position: relative;
        left: 87.5%
      }

      .el-col-md-22 {
        display: block;
        max-width: 91.6666666667%;
        flex: 0 0 91.6666666667%
      }

      .el-col-md-offset-22 {
        margin-left: 91.6666666667%
      }

      .el-col-md-pull-22 {
        position: relative;
        right: 91.6666666667%
      }

      .el-col-md-push-22 {
        position: relative;
        left: 91.6666666667%
      }

      .el-col-md-23 {
        display: block;
        max-width: 95.8333333333%;
        flex: 0 0 95.8333333333%
      }

      .el-col-md-offset-23 {
        margin-left: 95.8333333333%
      }

      .el-col-md-pull-23 {
        position: relative;
        right: 95.8333333333%
      }

      .el-col-md-push-23 {
        position: relative;
        left: 95.8333333333%
      }

      .el-col-md-24 {
        display: block;
        max-width: 100%;
        flex: 0 0 100%
      }

      .el-col-md-offset-24 {
        margin-left: 100%
      }

      .el-col-md-pull-24 {
        position: relative;
        right: 100%
      }

      .el-col-md-push-24 {
        position: relative;
        left: 100%
      }
    }

    @media only screen and (min-width:1200px) {
      .el-col-lg-0 {
        display: none
      }

      .el-col-lg-0.is-guttered {
        display: none
      }

      .el-col-lg-0 {
        max-width: 0%;
        flex: 0 0 0%
      }

      .el-col-lg-offset-0 {
        margin-left: 0
      }

      .el-col-lg-pull-0 {
        position: relative;
        right: 0
      }

      .el-col-lg-push-0 {
        position: relative;
        left: 0
      }

      .el-col-lg-1 {
        display: block;
        max-width: 4.1666666667%;
        flex: 0 0 4.1666666667%
      }

      .el-col-lg-offset-1 {
        margin-left: 4.1666666667%
      }

      .el-col-lg-pull-1 {
        position: relative;
        right: 4.1666666667%
      }

      .el-col-lg-push-1 {
        position: relative;
        left: 4.1666666667%
      }

      .el-col-lg-2 {
        display: block;
        max-width: 8.3333333333%;
        flex: 0 0 8.3333333333%
      }

      .el-col-lg-offset-2 {
        margin-left: 8.3333333333%
      }

      .el-col-lg-pull-2 {
        position: relative;
        right: 8.3333333333%
      }

      .el-col-lg-push-2 {
        position: relative;
        left: 8.3333333333%
      }

      .el-col-lg-3 {
        display: block;
        max-width: 12.5%;
        flex: 0 0 12.5%
      }

      .el-col-lg-offset-3 {
        margin-left: 12.5%
      }

      .el-col-lg-pull-3 {
        position: relative;
        right: 12.5%
      }

      .el-col-lg-push-3 {
        position: relative;
        left: 12.5%
      }

      .el-col-lg-4 {
        display: block;
        max-width: 16.6666666667%;
        flex: 0 0 16.6666666667%
      }

      .el-col-lg-offset-4 {
        margin-left: 16.6666666667%
      }

      .el-col-lg-pull-4 {
        position: relative;
        right: 16.6666666667%
      }

      .el-col-lg-push-4 {
        position: relative;
        left: 16.6666666667%
      }

      .el-col-lg-5 {
        display: block;
        max-width: 20.8333333333%;
        flex: 0 0 20.8333333333%
      }

      .el-col-lg-offset-5 {
        margin-left: 20.8333333333%
      }

      .el-col-lg-pull-5 {
        position: relative;
        right: 20.8333333333%
      }

      .el-col-lg-push-5 {
        position: relative;
        left: 20.8333333333%
      }

      .el-col-lg-6 {
        display: block;
        max-width: 25%;
        flex: 0 0 25%
      }

      .el-col-lg-offset-6 {
        margin-left: 25%
      }

      .el-col-lg-pull-6 {
        position: relative;
        right: 25%
      }

      .el-col-lg-push-6 {
        position: relative;
        left: 25%
      }

      .el-col-lg-7 {
        display: block;
        max-width: 29.1666666667%;
        flex: 0 0 29.1666666667%
      }

      .el-col-lg-offset-7 {
        margin-left: 29.1666666667%
      }

      .el-col-lg-pull-7 {
        position: relative;
        right: 29.1666666667%
      }

      .el-col-lg-push-7 {
        position: relative;
        left: 29.1666666667%
      }

      .el-col-lg-8 {
        display: block;
        max-width: 33.3333333333%;
        flex: 0 0 33.3333333333%
      }

      .el-col-lg-offset-8 {
        margin-left: 33.3333333333%
      }

      .el-col-lg-pull-8 {
        position: relative;
        right: 33.3333333333%
      }

      .el-col-lg-push-8 {
        position: relative;
        left: 33.3333333333%
      }

      .el-col-lg-9 {
        display: block;
        max-width: 37.5%;
        flex: 0 0 37.5%
      }

      .el-col-lg-offset-9 {
        margin-left: 37.5%
      }

      .el-col-lg-pull-9 {
        position: relative;
        right: 37.5%
      }

      .el-col-lg-push-9 {
        position: relative;
        left: 37.5%
      }

      .el-col-lg-10 {
        display: block;
        max-width: 41.6666666667%;
        flex: 0 0 41.6666666667%
      }

      .el-col-lg-offset-10 {
        margin-left: 41.6666666667%
      }

      .el-col-lg-pull-10 {
        position: relative;
        right: 41.6666666667%
      }

      .el-col-lg-push-10 {
        position: relative;
        left: 41.6666666667%
      }

      .el-col-lg-11 {
        display: block;
        max-width: 45.8333333333%;
        flex: 0 0 45.8333333333%
      }

      .el-col-lg-offset-11 {
        margin-left: 45.8333333333%
      }

      .el-col-lg-pull-11 {
        position: relative;
        right: 45.8333333333%
      }

      .el-col-lg-push-11 {
        position: relative;
        left: 45.8333333333%
      }

      .el-col-lg-12 {
        display: block;
        max-width: 50%;
        flex: 0 0 50%
      }

      .el-col-lg-offset-12 {
        margin-left: 50%
      }

      .el-col-lg-pull-12 {
        position: relative;
        right: 50%
      }

      .el-col-lg-push-12 {
        position: relative;
        left: 50%
      }

      .el-col-lg-13 {
        display: block;
        max-width: 54.1666666667%;
        flex: 0 0 54.1666666667%
      }

      .el-col-lg-offset-13 {
        margin-left: 54.1666666667%
      }

      .el-col-lg-pull-13 {
        position: relative;
        right: 54.1666666667%
      }

      .el-col-lg-push-13 {
        position: relative;
        left: 54.1666666667%
      }

      .el-col-lg-14 {
        display: block;
        max-width: 58.3333333333%;
        flex: 0 0 58.3333333333%
      }

      .el-col-lg-offset-14 {
        margin-left: 58.3333333333%
      }

      .el-col-lg-pull-14 {
        position: relative;
        right: 58.3333333333%
      }

      .el-col-lg-push-14 {
        position: relative;
        left: 58.3333333333%
      }

      .el-col-lg-15 {
        display: block;
        max-width: 62.5%;
        flex: 0 0 62.5%
      }

      .el-col-lg-offset-15 {
        margin-left: 62.5%
      }

      .el-col-lg-pull-15 {
        position: relative;
        right: 62.5%
      }

      .el-col-lg-push-15 {
        position: relative;
        left: 62.5%
      }

      .el-col-lg-16 {
        display: block;
        max-width: 66.6666666667%;
        flex: 0 0 66.6666666667%
      }

      .el-col-lg-offset-16 {
        margin-left: 66.6666666667%
      }

      .el-col-lg-pull-16 {
        position: relative;
        right: 66.6666666667%
      }

      .el-col-lg-push-16 {
        position: relative;
        left: 66.6666666667%
      }

      .el-col-lg-17 {
        display: block;
        max-width: 70.8333333333%;
        flex: 0 0 70.8333333333%
      }

      .el-col-lg-offset-17 {
        margin-left: 70.8333333333%
      }

      .el-col-lg-pull-17 {
        position: relative;
        right: 70.8333333333%
      }

      .el-col-lg-push-17 {
        position: relative;
        left: 70.8333333333%
      }

      .el-col-lg-18 {
        display: block;
        max-width: 75%;
        flex: 0 0 75%
      }

      .el-col-lg-offset-18 {
        margin-left: 75%
      }

      .el-col-lg-pull-18 {
        position: relative;
        right: 75%
      }

      .el-col-lg-push-18 {
        position: relative;
        left: 75%
      }

      .el-col-lg-19 {
        display: block;
        max-width: 79.1666666667%;
        flex: 0 0 79.1666666667%
      }

      .el-col-lg-offset-19 {
        margin-left: 79.1666666667%
      }

      .el-col-lg-pull-19 {
        position: relative;
        right: 79.1666666667%
      }

      .el-col-lg-push-19 {
        position: relative;
        left: 79.1666666667%
      }

      .el-col-lg-20 {
        display: block;
        max-width: 83.3333333333%;
        flex: 0 0 83.3333333333%
      }

      .el-col-lg-offset-20 {
        margin-left: 83.3333333333%
      }

      .el-col-lg-pull-20 {
        position: relative;
        right: 83.3333333333%
      }

      .el-col-lg-push-20 {
        position: relative;
        left: 83.3333333333%
      }

      .el-col-lg-21 {
        display: block;
        max-width: 87.5%;
        flex: 0 0 87.5%
      }

      .el-col-lg-offset-21 {
        margin-left: 87.5%
      }

      .el-col-lg-pull-21 {
        position: relative;
        right: 87.5%
      }

      .el-col-lg-push-21 {
        position: relative;
        left: 87.5%
      }

      .el-col-lg-22 {
        display: block;
        max-width: 91.6666666667%;
        flex: 0 0 91.6666666667%
      }

      .el-col-lg-offset-22 {
        margin-left: 91.6666666667%
      }

      .el-col-lg-pull-22 {
        position: relative;
        right: 91.6666666667%
      }

      .el-col-lg-push-22 {
        position: relative;
        left: 91.6666666667%
      }

      .el-col-lg-23 {
        display: block;
        max-width: 95.8333333333%;
        flex: 0 0 95.8333333333%
      }

      .el-col-lg-offset-23 {
        margin-left: 95.8333333333%
      }

      .el-col-lg-pull-23 {
        position: relative;
        right: 95.8333333333%
      }

      .el-col-lg-push-23 {
        position: relative;
        left: 95.8333333333%
      }

      .el-col-lg-24 {
        display: block;
        max-width: 100%;
        flex: 0 0 100%
      }

      .el-col-lg-offset-24 {
        margin-left: 100%
      }

      .el-col-lg-pull-24 {
        position: relative;
        right: 100%
      }

      .el-col-lg-push-24 {
        position: relative;
        left: 100%
      }
    }

    @media only screen and (min-width:1920px) {
      .el-col-xl-0 {
        display: none
      }

      .el-col-xl-0.is-guttered {
        display: none
      }

      .el-col-xl-0 {
        max-width: 0%;
        flex: 0 0 0%
      }

      .el-col-xl-offset-0 {
        margin-left: 0
      }

      .el-col-xl-pull-0 {
        position: relative;
        right: 0
      }

      .el-col-xl-push-0 {
        position: relative;
        left: 0
      }

      .el-col-xl-1 {
        display: block;
        max-width: 4.1666666667%;
        flex: 0 0 4.1666666667%
      }

      .el-col-xl-offset-1 {
        margin-left: 4.1666666667%
      }

      .el-col-xl-pull-1 {
        position: relative;
        right: 4.1666666667%
      }

      .el-col-xl-push-1 {
        position: relative;
        left: 4.1666666667%
      }

      .el-col-xl-2 {
        display: block;
        max-width: 8.3333333333%;
        flex: 0 0 8.3333333333%
      }

      .el-col-xl-offset-2 {
        margin-left: 8.3333333333%
      }

      .el-col-xl-pull-2 {
        position: relative;
        right: 8.3333333333%
      }

      .el-col-xl-push-2 {
        position: relative;
        left: 8.3333333333%
      }

      .el-col-xl-3 {
        display: block;
        max-width: 12.5%;
        flex: 0 0 12.5%
      }

      .el-col-xl-offset-3 {
        margin-left: 12.5%
      }

      .el-col-xl-pull-3 {
        position: relative;
        right: 12.5%
      }

      .el-col-xl-push-3 {
        position: relative;
        left: 12.5%
      }

      .el-col-xl-4 {
        display: block;
        max-width: 16.6666666667%;
        flex: 0 0 16.6666666667%
      }

      .el-col-xl-offset-4 {
        margin-left: 16.6666666667%
      }

      .el-col-xl-pull-4 {
        position: relative;
        right: 16.6666666667%
      }

      .el-col-xl-push-4 {
        position: relative;
        left: 16.6666666667%
      }

      .el-col-xl-5 {
        display: block;
        max-width: 20.8333333333%;
        flex: 0 0 20.8333333333%
      }

      .el-col-xl-offset-5 {
        margin-left: 20.8333333333%
      }

      .el-col-xl-pull-5 {
        position: relative;
        right: 20.8333333333%
      }

      .el-col-xl-push-5 {
        position: relative;
        left: 20.8333333333%
      }

      .el-col-xl-6 {
        display: block;
        max-width: 25%;
        flex: 0 0 25%
      }

      .el-col-xl-offset-6 {
        margin-left: 25%
      }

      .el-col-xl-pull-6 {
        position: relative;
        right: 25%
      }

      .el-col-xl-push-6 {
        position: relative;
        left: 25%
      }

      .el-col-xl-7 {
        display: block;
        max-width: 29.1666666667%;
        flex: 0 0 29.1666666667%
      }

      .el-col-xl-offset-7 {
        margin-left: 29.1666666667%
      }

      .el-col-xl-pull-7 {
        position: relative;
        right: 29.1666666667%
      }

      .el-col-xl-push-7 {
        position: relative;
        left: 29.1666666667%
      }

      .el-col-xl-8 {
        display: block;
        max-width: 33.3333333333%;
        flex: 0 0 33.3333333333%
      }

      .el-col-xl-offset-8 {
        margin-left: 33.3333333333%
      }

      .el-col-xl-pull-8 {
        position: relative;
        right: 33.3333333333%
      }

      .el-col-xl-push-8 {
        position: relative;
        left: 33.3333333333%
      }

      .el-col-xl-9 {
        display: block;
        max-width: 37.5%;
        flex: 0 0 37.5%
      }

      .el-col-xl-offset-9 {
        margin-left: 37.5%
      }

      .el-col-xl-pull-9 {
        position: relative;
        right: 37.5%
      }

      .el-col-xl-push-9 {
        position: relative;
        left: 37.5%
      }

      .el-col-xl-10 {
        display: block;
        max-width: 41.6666666667%;
        flex: 0 0 41.6666666667%
      }

      .el-col-xl-offset-10 {
        margin-left: 41.6666666667%
      }

      .el-col-xl-pull-10 {
        position: relative;
        right: 41.6666666667%
      }

      .el-col-xl-push-10 {
        position: relative;
        left: 41.6666666667%
      }

      .el-col-xl-11 {
        display: block;
        max-width: 45.8333333333%;
        flex: 0 0 45.8333333333%
      }

      .el-col-xl-offset-11 {
        margin-left: 45.8333333333%
      }

      .el-col-xl-pull-11 {
        position: relative;
        right: 45.8333333333%
      }

      .el-col-xl-push-11 {
        position: relative;
        left: 45.8333333333%
      }

      .el-col-xl-12 {
        display: block;
        max-width: 50%;
        flex: 0 0 50%
      }

      .el-col-xl-offset-12 {
        margin-left: 50%
      }

      .el-col-xl-pull-12 {
        position: relative;
        right: 50%
      }

      .el-col-xl-push-12 {
        position: relative;
        left: 50%
      }

      .el-col-xl-13 {
        display: block;
        max-width: 54.1666666667%;
        flex: 0 0 54.1666666667%
      }

      .el-col-xl-offset-13 {
        margin-left: 54.1666666667%
      }

      .el-col-xl-pull-13 {
        position: relative;
        right: 54.1666666667%
      }

      .el-col-xl-push-13 {
        position: relative;
        left: 54.1666666667%
      }

      .el-col-xl-14 {
        display: block;
        max-width: 58.3333333333%;
        flex: 0 0 58.3333333333%
      }

      .el-col-xl-offset-14 {
        margin-left: 58.3333333333%
      }

      .el-col-xl-pull-14 {
        position: relative;
        right: 58.3333333333%
      }

      .el-col-xl-push-14 {
        position: relative;
        left: 58.3333333333%
      }

      .el-col-xl-15 {
        display: block;
        max-width: 62.5%;
        flex: 0 0 62.5%
      }

      .el-col-xl-offset-15 {
        margin-left: 62.5%
      }

      .el-col-xl-pull-15 {
        position: relative;
        right: 62.5%
      }

      .el-col-xl-push-15 {
        position: relative;
        left: 62.5%
      }

      .el-col-xl-16 {
        display: block;
        max-width: 66.6666666667%;
        flex: 0 0 66.6666666667%
      }

      .el-col-xl-offset-16 {
        margin-left: 66.6666666667%
      }

      .el-col-xl-pull-16 {
        position: relative;
        right: 66.6666666667%
      }

      .el-col-xl-push-16 {
        position: relative;
        left: 66.6666666667%
      }

      .el-col-xl-17 {
        display: block;
        max-width: 70.8333333333%;
        flex: 0 0 70.8333333333%
      }

      .el-col-xl-offset-17 {
        margin-left: 70.8333333333%
      }

      .el-col-xl-pull-17 {
        position: relative;
        right: 70.8333333333%
      }

      .el-col-xl-push-17 {
        position: relative;
        left: 70.8333333333%
      }

      .el-col-xl-18 {
        display: block;
        max-width: 75%;
        flex: 0 0 75%
      }

      .el-col-xl-offset-18 {
        margin-left: 75%
      }

      .el-col-xl-pull-18 {
        position: relative;
        right: 75%
      }

      .el-col-xl-push-18 {
        position: relative;
        left: 75%
      }

      .el-col-xl-19 {
        display: block;
        max-width: 79.1666666667%;
        flex: 0 0 79.1666666667%
      }

      .el-col-xl-offset-19 {
        margin-left: 79.1666666667%
      }

      .el-col-xl-pull-19 {
        position: relative;
        right: 79.1666666667%
      }

      .el-col-xl-push-19 {
        position: relative;
        left: 79.1666666667%
      }

      .el-col-xl-20 {
        display: block;
        max-width: 83.3333333333%;
        flex: 0 0 83.3333333333%
      }

      .el-col-xl-offset-20 {
        margin-left: 83.3333333333%
      }

      .el-col-xl-pull-20 {
        position: relative;
        right: 83.3333333333%
      }

      .el-col-xl-push-20 {
        position: relative;
        left: 83.3333333333%
      }

      .el-col-xl-21 {
        display: block;
        max-width: 87.5%;
        flex: 0 0 87.5%
      }

      .el-col-xl-offset-21 {
        margin-left: 87.5%
      }

      .el-col-xl-pull-21 {
        position: relative;
        right: 87.5%
      }

      .el-col-xl-push-21 {
        position: relative;
        left: 87.5%
      }

      .el-col-xl-22 {
        display: block;
        max-width: 91.6666666667%;
        flex: 0 0 91.6666666667%
      }

      .el-col-xl-offset-22 {
        margin-left: 91.6666666667%
      }

      .el-col-xl-pull-22 {
        position: relative;
        right: 91.6666666667%
      }

      .el-col-xl-push-22 {
        position: relative;
        left: 91.6666666667%
      }

      .el-col-xl-23 {
        display: block;
        max-width: 95.8333333333%;
        flex: 0 0 95.8333333333%
      }

      .el-col-xl-offset-23 {
        margin-left: 95.8333333333%
      }

      .el-col-xl-pull-23 {
        position: relative;
        right: 95.8333333333%
      }

      .el-col-xl-push-23 {
        position: relative;
        left: 95.8333333333%
      }

      .el-col-xl-24 {
        display: block;
        max-width: 100%;
        flex: 0 0 100%
      }

      .el-col-xl-offset-24 {
        margin-left: 100%
      }

      .el-col-xl-pull-24 {
        position: relative;
        right: 100%
      }

      .el-col-xl-push-24 {
        position: relative;
        left: 100%
      }
    }

    .el-collapse {
      --el-collapse-border-color: var(--el-border-color-lighter);
      --el-collapse-header-height: 48px;
      --el-collapse-header-bg-color: var(--el-fill-color-blank);
      --el-collapse-header-text-color: var(--el-text-color-primary);
      --el-collapse-header-font-size: 13px;
      --el-collapse-content-bg-color: var(--el-fill-color-blank);
      --el-collapse-content-font-size: 13px;
      --el-collapse-content-text-color: var(--el-text-color-primary);
      border-top: 1px solid var(--el-collapse-border-color);
      border-bottom: 1px solid var(--el-collapse-border-color)
    }

    .el-collapse-item.is-disabled .el-collapse-item__header {
      color: var(--el-text-color-disabled);
      cursor: not-allowed
    }

    .el-collapse-item__header {
      width: 100%;
      padding: 0;
      border: none;
      display: flex;
      align-items: center;
      height: var(--el-collapse-header-height);
      line-height: var(--el-collapse-header-height);
      background-color: var(--el-collapse-header-bg-color);
      color: var(--el-collapse-header-text-color);
      cursor: pointer;
      border-bottom: 1px solid var(--el-collapse-border-color);
      font-size: var(--el-collapse-header-font-size);
      font-weight: 500;
      transition: border-bottom-color var(--el-transition-duration);
      outline: 0
    }

    .el-collapse-item__arrow {
      margin: 0 8px 0 auto;
      transition: transform var(--el-transition-duration);
      font-weight: 300
    }

    .el-collapse-item__arrow.is-active {
      transform: rotate(90deg)
    }

    .el-collapse-item__header.focusing:focus:not(:hover) {
      color: var(--el-color-primary)
    }

    .el-collapse-item__header.is-active {
      border-bottom-color: transparent
    }

    .el-collapse-item__wrap {
      will-change: height;
      background-color: var(--el-collapse-content-bg-color);
      overflow: hidden;
      box-sizing: border-box;
      border-bottom: 1px solid var(--el-collapse-border-color)
    }

    .el-collapse-item__content {
      padding-bottom: 25px;
      font-size: var(--el-collapse-content-font-size);
      color: var(--el-collapse-content-text-color);
      line-height: 1.7692307692
    }

    .el-collapse-item:last-child {
      margin-bottom: -1px
    }

    .el-color-predefine {
      display: flex;
      font-size: 12px;
      margin-top: 8px;
      width: 280px
    }

    .el-color-predefine__colors {
      display: flex;
      flex: 1;
      flex-wrap: wrap
    }

    .el-color-predefine__color-selector {
      margin: 0 0 8px 8px;
      width: 20px;
      height: 20px;
      border-radius: 4px;
      cursor: pointer
    }

    .el-color-predefine__color-selector:nth-child(10n+1) {
      margin-left: 0
    }

    .el-color-predefine__color-selector.selected {
      box-shadow: 0 0 3px 2px var(--el-color-primary)
    }

    .el-color-predefine__color-selector>div {
      display: flex;
      height: 100%;
      border-radius: 3px
    }

    .el-color-predefine__color-selector.is-alpha {
      background-image: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAwAAAAMCAIAAADZF8uwAAAAGUlEQVQYV2M4gwH+YwCGIasIUwhT25BVBADtzYNYrHvv4gAAAABJRU5ErkJggg==)
    }

    .el-color-hue-slider {
      position: relative;
      box-sizing: border-box;
      width: 280px;
      height: 12px;
      background-color: red;
      padding: 0 2px;
      float: right
    }

    .el-color-hue-slider__bar {
      position: relative;
      background: linear-gradient(to right, red 0, #ff0 17%, #0f0 33%, #0ff 50%, #00f 67%, #f0f 83%, red 100%);
      height: 100%
    }

    .el-color-hue-slider__thumb {
      position: absolute;
      cursor: pointer;
      box-sizing: border-box;
      left: 0;
      top: 0;
      width: 4px;
      height: 100%;
      border-radius: 1px;
      background: #fff;
      border: 1px solid var(--el-border-color-lighter);
      box-shadow: 0 0 2px rgba(0, 0, 0, .6);
      z-index: 1
    }

    .el-color-hue-slider.is-vertical {
      width: 12px;
      height: 180px;
      padding: 2px 0
    }

    .el-color-hue-slider.is-vertical .el-color-hue-slider__bar {
      background: linear-gradient(to bottom, red 0, #ff0 17%, #0f0 33%, #0ff 50%, #00f 67%, #f0f 83%, red 100%)
    }

    .el-color-hue-slider.is-vertical .el-color-hue-slider__thumb {
      left: 0;
      top: 0;
      width: 100%;
      height: 4px
    }

    .el-color-svpanel {
      position: relative;
      width: 280px;
      height: 180px
    }

    .el-color-svpanel__black,
    .el-color-svpanel__white {
      position: absolute;
      top: 0;
      left: 0;
      right: 0;
      bottom: 0
    }

    .el-color-svpanel__white {
      background: linear-gradient(to right, #fff, rgba(255, 255, 255, 0))
    }

    .el-color-svpanel__black {
      background: linear-gradient(to top, #000, rgba(0, 0, 0, 0))
    }

    .el-color-svpanel__cursor {
      position: absolute
    }

    .el-color-svpanel__cursor>div {
      cursor: head;
      width: 4px;
      height: 4px;
      box-shadow: 0 0 0 1.5px #fff, inset 0 0 1px 1px rgba(0, 0, 0, .3), 0 0 1px 2px rgba(0, 0, 0, .4);
      border-radius: 50%;
      transform: translate(-2px, -2px)
    }

    .el-color-alpha-slider {
      position: relative;
      box-sizing: border-box;
      width: 280px;
      height: 12px;
      background-image: linear-gradient(45deg, var(--el-color-picker-alpha-bg-a) 25%, var(--el-color-picker-alpha-bg-b) 25%), linear-gradient(135deg, var(--el-color-picker-alpha-bg-a) 25%, var(--el-color-picker-alpha-bg-b) 25%), linear-gradient(45deg, var(--el-color-picker-alpha-bg-b) 75%, var(--el-color-picker-alpha-bg-a) 75%), linear-gradient(135deg, var(--el-color-picker-alpha-bg-b) 75%, var(--el-color-picker-alpha-bg-a) 75%);
      background-size: 12px 12px;
      background-position: 0 0, 6px 0, 6px -6px, 0 6px
    }

    .el-color-alpha-slider__bar {
      position: relative;
      background: linear-gradient(to right, rgba(255, 255, 255, 0) 0, var(--el-bg-color) 100%);
      height: 100%
    }

    .el-color-alpha-slider__thumb {
      position: absolute;
      cursor: pointer;
      box-sizing: border-box;
      left: 0;
      top: 0;
      width: 4px;
      height: 100%;
      border-radius: 1px;
      background: #fff;
      border: 1px solid var(--el-border-color-lighter);
      box-shadow: 0 0 2px rgba(0, 0, 0, .6);
      z-index: 1
    }

    .el-color-alpha-slider.is-vertical {
      width: 20px;
      height: 180px
    }

    .el-color-alpha-slider.is-vertical .el-color-alpha-slider__bar {
      background: linear-gradient(to bottom, rgba(255, 255, 255, 0) 0, #fff 100%)
    }

    .el-color-alpha-slider.is-vertical .el-color-alpha-slider__thumb {
      left: 0;
      top: 0;
      width: 100%;
      height: 4px
    }

    .el-color-dropdown {
      width: 300px
    }

    .el-color-dropdown__main-wrapper {
      margin-bottom: 6px
    }

    .el-color-dropdown__main-wrapper::after {
      content: """";
      display: table;
      clear: both
    }

    .el-color-dropdown__btns {
      margin-top: 12px;
      text-align: right
    }

    .el-color-dropdown__value {
      float: left;
      line-height: 26px;
      font-size: 12px;
      color: #000;
      width: 160px
    }

    .el-color-picker {
      display: inline-block;
      position: relative;
      line-height: normal;
      outline: 0
    }

    .el-color-picker:hover:not(.is-disabled, .is-focused) .el-color-picker__trigger {
      border-color: var(--el-border-color-hover)
    }

    .el-color-picker:focus-visible:not(.is-disabled) .el-color-picker__trigger {
      outline: 2px solid var(--el-color-primary);
      outline-offset: 1px
    }

    .el-color-picker.is-focused .el-color-picker__trigger {
      border-color: var(--el-color-primary)
    }

    .el-color-picker.is-disabled .el-color-picker__trigger {
      cursor: not-allowed
    }

    .el-color-picker--large {
      height: 40px
    }

    .el-color-picker--large .el-color-picker__trigger {
      height: 40px;
      width: 40px
    }

    .el-color-picker--large .el-color-picker__mask {
      height: 38px;
      width: 38px
    }

    .el-color-picker--small {
      height: 24px
    }

    .el-color-picker--small .el-color-picker__trigger {
      height: 24px;
      width: 24px
    }

    .el-color-picker--small .el-color-picker__mask {
      height: 22px;
      width: 22px
    }

    .el-color-picker--small .el-color-picker__empty,
    .el-color-picker--small .el-color-picker__icon {
      transform: scale(.8)
    }

    .el-color-picker__mask {
      height: 30px;
      width: 30px;
      border-radius: 4px;
      position: absolute;
      top: 1px;
      left: 1px;
      z-index: 1;
      cursor: not-allowed;
      background-color: rgba(255, 255, 255, .7)
    }

    .el-color-picker__trigger {
      display: inline-flex;
      justify-content: center;
      align-items: center;
      box-sizing: border-box;
      height: 32px;
      width: 32px;
      padding: 4px;
      border: 1px solid var(--el-border-color);
      border-radius: 4px;
      font-size: 0;
      position: relative;
      cursor: pointer
    }

    .el-color-picker__color {
      position: relative;
      display: block;
      box-sizing: border-box;
      border: 1px solid var(--el-text-color-secondary);
      border-radius: var(--el-border-radius-small);
      width: 100%;
      height: 100%;
      text-align: center
    }

    .el-color-picker__color.is-alpha {
      background-image: linear-gradient(45deg, var(--el-color-picker-alpha-bg-a) 25%, var(--el-color-picker-alpha-bg-b) 25%), linear-gradient(135deg, var(--el-color-picker-alpha-bg-a) 25%, var(--el-color-picker-alpha-bg-b) 25%), linear-gradient(45deg, var(--el-color-picker-alpha-bg-b) 75%, var(--el-color-picker-alpha-bg-a) 75%), linear-gradient(135deg, var(--el-color-picker-alpha-bg-b) 75%, var(--el-color-picker-alpha-bg-a) 75%);
      background-size: 12px 12px;
      background-position: 0 0, 6px 0, 6px -6px, 0 6px
    }

    .el-color-picker__color-inner {
      display: inline-flex;
      justify-content: center;
      align-items: center;
      width: 100%;
      height: 100%
    }

    .el-color-picker .el-color-picker__empty {
      font-size: 12px;
      color: var(--el-text-color-secondary)
    }

    .el-color-picker .el-color-picker__icon {
      display: inline-flex;
      justify-content: center;
      align-items: center;
      color: #fff;
      font-size: 12px
    }

    .el-color-picker__panel {
      position: absolute;
      z-index: 10;
      padding: 6px;
      box-sizing: content-box;
      background-color: #fff;
      border-radius: var(--el-border-radius-base);
      box-shadow: var(--el-box-shadow-light)
    }

    .el-color-picker__panel.el-popper {
      border: 1px solid var(--el-border-color-lighter)
    }

    .el-color-picker,
    .el-color-picker__panel {
      --el-color-picker-alpha-bg-a: #ccc;
      --el-color-picker-alpha-bg-b: transparent
    }

    .dark .el-color-picker,
    .dark .el-color-picker__panel {
      --el-color-picker-alpha-bg-a: #333333
    }

    .el-container {
      display: flex;
      flex-direction: row;
      flex: 1;
      flex-basis: auto;
      box-sizing: border-box;
      min-width: 0
    }

    .el-container.is-vertical {
      flex-direction: column
    }

    .el-date-table {
      font-size: 12px;
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none
    }

    .el-date-table.is-week-mode .el-date-table__row:hover .el-date-table-cell {
      background-color: var(--el-datepicker-inrange-bg-color)
    }

    .el-date-table.is-week-mode .el-date-table__row:hover td.available:hover {
      color: var(--el-datepicker-text-color)
    }

    .el-date-table.is-week-mode .el-date-table__row:hover td:first-child .el-date-table-cell {
      margin-left: 5px;
      border-top-left-radius: 15px;
      border-bottom-left-radius: 15px
    }

    .el-date-table.is-week-mode .el-date-table__row:hover td:last-child .el-date-table-cell {
      margin-right: 5px;
      border-top-right-radius: 15px;
      border-bottom-right-radius: 15px
    }

    .el-date-table.is-week-mode .el-date-table__row.current .el-date-table-cell {
      background-color: var(--el-datepicker-inrange-bg-color)
    }

    .el-date-table td {
      width: 32px;
      height: 30px;
      padding: 4px 0;
      box-sizing: border-box;
      text-align: center;
      cursor: pointer;
      position: relative
    }

    .el-date-table td .el-date-table-cell {
      height: 30px;
      padding: 3px 0;
      box-sizing: border-box
    }

    .el-date-table td .el-date-table-cell .el-date-table-cell__text {
      width: 24px;
      height: 24px;
      display: block;
      margin: 0 auto;
      line-height: 24px;
      position: absolute;
      left: 50%;
      transform: translateX(-50%);
      border-radius: 50%
    }

    .el-date-table td.next-month,
    .el-date-table td.prev-month {
      color: var(--el-datepicker-off-text-color)
    }

    .el-date-table td.today {
      position: relative
    }

    .el-date-table td.today .el-date-table-cell__text {
      color: var(--el-color-primary);
      font-weight: 700
    }

    .el-date-table td.today.end-date .el-date-table-cell__text,
    .el-date-table td.today.start-date .el-date-table-cell__text {
      color: #fff
    }

    .el-date-table td.available:hover {
      color: var(--el-datepicker-hover-text-color)
    }

    .el-date-table td.in-range .el-date-table-cell {
      background-color: var(--el-datepicker-inrange-bg-color)
    }

    .el-date-table td.in-range .el-date-table-cell:hover {
      background-color: var(--el-datepicker-inrange-hover-bg-color)
    }

    .el-date-table td.current:not(.disabled) .el-date-table-cell__text {
      color: #fff;
      background-color: var(--el-datepicker-active-color)
    }

    .el-date-table td.current:not(.disabled):focus-visible .el-date-table-cell__text {
      outline: 2px solid var(--el-datepicker-active-color);
      outline-offset: 1px
    }

    .el-date-table td.end-date .el-date-table-cell,
    .el-date-table td.start-date .el-date-table-cell {
      color: #fff
    }

    .el-date-table td.end-date .el-date-table-cell__text,
    .el-date-table td.start-date .el-date-table-cell__text {
      background-color: var(--el-datepicker-active-color)
    }

    .el-date-table td.start-date .el-date-table-cell {
      margin-left: 5px;
      border-top-left-radius: 15px;
      border-bottom-left-radius: 15px
    }

    .el-date-table td.end-date .el-date-table-cell {
      margin-right: 5px;
      border-top-right-radius: 15px;
      border-bottom-right-radius: 15px
    }

    .el-date-table td.disabled .el-date-table-cell {
      background-color: var(--el-fill-color-light);
      opacity: 1;
      cursor: not-allowed;
      color: var(--el-text-color-placeholder)
    }

    .el-date-table td.selected .el-date-table-cell {
      margin-left: 5px;
      margin-right: 5px;
      background-color: var(--el-datepicker-inrange-bg-color);
      border-radius: 15px
    }

    .el-date-table td.selected .el-date-table-cell:hover {
      background-color: var(--el-datepicker-inrange-hover-bg-color)
    }

    .el-date-table td.selected .el-date-table-cell__text {
      background-color: var(--el-datepicker-active-color);
      color: #fff;
      border-radius: 15px
    }

    .el-date-table td.week {
      font-size: 80%;
      color: var(--el-datepicker-header-text-color)
    }

    .el-date-table td:focus {
      outline: 0
    }

    .el-date-table th {
      padding: 5px;
      color: var(--el-datepicker-header-text-color);
      font-weight: 400;
      border-bottom: solid 1px var(--el-border-color-lighter)
    }

    .el-month-table {
      font-size: 12px;
      margin: -1px;
      border-collapse: collapse
    }

    .el-month-table td {
      text-align: center;
      padding: 8px 0;
      cursor: pointer
    }

    .el-month-table td div {
      height: 48px;
      padding: 6px 0;
      box-sizing: border-box
    }

    .el-month-table td.today .cell {
      color: var(--el-color-primary);
      font-weight: 700
    }

    .el-month-table td.today.end-date .cell,
    .el-month-table td.today.start-date .cell {
      color: #fff
    }

    .el-month-table td.disabled .cell {
      background-color: var(--el-fill-color-light);
      cursor: not-allowed;
      color: var(--el-text-color-placeholder)
    }

    .el-month-table td.disabled .cell:hover {
      color: var(--el-text-color-placeholder)
    }

    .el-month-table td .cell {
      width: 60px;
      height: 36px;
      display: block;
      line-height: 36px;
      color: var(--el-datepicker-text-color);
      margin: 0 auto;
      border-radius: 18px
    }

    .el-month-table td .cell:hover {
      color: var(--el-datepicker-hover-text-color)
    }

    .el-month-table td.in-range div {
      background-color: var(--el-datepicker-inrange-bg-color)
    }

    .el-month-table td.in-range div:hover {
      background-color: var(--el-datepicker-inrange-hover-bg-color)
    }

    .el-month-table td.end-date div,
    .el-month-table td.start-date div {
      color: #fff
    }

    .el-month-table td.end-date .cell,
    .el-month-table td.start-date .cell {
      color: #fff;
      background-color: var(--el-datepicker-active-color)
    }

    .el-month-table td.start-date div {
      border-top-left-radius: 24px;
      border-bottom-left-radius: 24px
    }

    .el-month-table td.end-date div {
      border-top-right-radius: 24px;
      border-bottom-right-radius: 24px
    }

    .el-month-table td.current:not(.disabled) .cell {
      color: var(--el-datepicker-active-color)
    }

    .el-month-table td:focus-visible {
      outline: 0
    }

    .el-month-table td:focus-visible .cell {
      outline: 2px solid var(--el-datepicker-active-color)
    }

    .el-year-table {
      font-size: 12px;
      margin: -1px;
      border-collapse: collapse
    }

    .el-year-table .el-icon {
      color: var(--el-datepicker-icon-color)
    }

    .el-year-table td {
      text-align: center;
      padding: 20px 3px;
      cursor: pointer
    }

    .el-year-table td.today .cell {
      color: var(--el-color-primary);
      font-weight: 700
    }

    .el-year-table td.disabled .cell {
      background-color: var(--el-fill-color-light);
      cursor: not-allowed;
      color: var(--el-text-color-placeholder)
    }

    .el-year-table td.disabled .cell:hover {
      color: var(--el-text-color-placeholder)
    }

    .el-year-table td .cell {
      width: 48px;
      height: 36px;
      display: block;
      line-height: 36px;
      color: var(--el-datepicker-text-color);
      border-radius: 18px;
      margin: 0 auto
    }

    .el-year-table td .cell:hover {
      color: var(--el-datepicker-hover-text-color)
    }

    .el-year-table td.current:not(.disabled) .cell {
      color: var(--el-datepicker-active-color)
    }

    .el-year-table td:focus-visible {
      outline: 0
    }

    .el-year-table td:focus-visible .cell {
      outline: 2px solid var(--el-datepicker-active-color)
    }

    .el-time-spinner.has-seconds .el-time-spinner__wrapper {
      width: 33.3%
    }

    .el-time-spinner__wrapper {
      max-height: 192px;
      overflow: auto;
      display: inline-block;
      width: 50%;
      vertical-align: top;
      position: relative
    }

    .el-time-spinner__wrapper.el-scrollbar__wrap:not(.el-scrollbar__wrap--hidden-default) {
      padding-bottom: 15px
    }

    .el-time-spinner__wrapper.is-arrow {
      box-sizing: border-box;
      text-align: center;
      overflow: hidden
    }

    .el-time-spinner__wrapper.is-arrow .el-time-spinner__list {
      transform: translateY(-32px)
    }

    .el-time-spinner__wrapper.is-arrow .el-time-spinner__item:hover:not(.is-disabled):not(.is-active) {
      background: var(--el-fill-color-light);
      cursor: default
    }

    .el-time-spinner__arrow {
      font-size: 12px;
      color: var(--el-text-color-secondary);
      position: absolute;
      left: 0;
      width: 100%;
      z-index: var(--el-index-normal);
      text-align: center;
      height: 30px;
      line-height: 30px;
      cursor: pointer
    }

    .el-time-spinner__arrow:hover {
      color: var(--el-color-primary)
    }

    .el-time-spinner__arrow.arrow-up {
      top: 10px
    }

    .el-time-spinner__arrow.arrow-down {
      bottom: 10px
    }

    .el-time-spinner__input.el-input {
      width: 70%
    }

    .el-time-spinner__input.el-input .el-input__inner {
      padding: 0;
      text-align: center
    }

    .el-time-spinner__list {
      padding: 0;
      margin: 0;
      list-style: none;
      text-align: center
    }

    .el-time-spinner__list::after,
    .el-time-spinner__list::before {
      content: """";
      display: block;
      width: 100%;
      height: 80px
    }

    .el-time-spinner__item {
      height: 32px;
      line-height: 32px;
      font-size: 12px;
      color: var(--el-text-color-regular)
    }

    .el-time-spinner__item:hover:not(.is-disabled):not(.is-active) {
      background: var(--el-fill-color-light);
      cursor: pointer
    }

    .el-time-spinner__item.is-active:not(.is-disabled) {
      color: var(--el-text-color-primary);
      font-weight: 700
    }

    .el-time-spinner__item.is-disabled {
      color: var(--el-text-color-placeholder);
      cursor: not-allowed
    }

    .el-picker__popper {
      --el-datepicker-border-color: var(--el-disabled-border-color)
    }

    .el-picker__popper.el-popper {
      background: var(--el-bg-color-overlay);
      border: 1px solid var(--el-datepicker-border-color);
      box-shadow: var(--el-box-shadow-light)
    }

    .el-picker__popper.el-popper .el-popper__arrow::before {
      border: 1px solid var(--el-datepicker-border-color)
    }

    .el-picker__popper.el-popper[data-popper-placement^=top] .el-popper__arrow::before {
      border-top-color: transparent;
      border-left-color: transparent
    }

    .el-picker__popper.el-popper[data-popper-placement^=bottom] .el-popper__arrow::before {
      border-bottom-color: transparent;
      border-right-color: transparent
    }

    .el-picker__popper.el-popper[data-popper-placement^=left] .el-popper__arrow::before {
      border-left-color: transparent;
      border-bottom-color: transparent
    }

    .el-picker__popper.el-popper[data-popper-placement^=right] .el-popper__arrow::before {
      border-right-color: transparent;
      border-top-color: transparent
    }

    .el-date-editor {
      --el-date-editor-width: 220px;
      --el-date-editor-monthrange-width: 300px;
      --el-date-editor-daterange-width: 350px;
      --el-date-editor-datetimerange-width: 400px;
      --el-input-text-color: var(--el-text-color-regular);
      --el-input-border: var(--el-border);
      --el-input-hover-border: var(--el-border-color-hover);
      --el-input-focus-border: var(--el-color-primary);
      --el-input-transparent-border: 0 0 0 1px transparent inset;
      --el-input-border-color: var(--el-border-color);
      --el-input-border-radius: var(--el-border-radius-base);
      --el-input-bg-color: var(--el-fill-color-blank);
      --el-input-icon-color: var(--el-text-color-placeholder);
      --el-input-placeholder-color: var(--el-text-color-placeholder);
      --el-input-hover-border-color: var(--el-border-color-hover);
      --el-input-clear-hover-color: var(--el-text-color-secondary);
      --el-input-focus-border-color: var(--el-color-primary);
      --el-input-width: 100%;
      position: relative;
      text-align: left;
      vertical-align: middle
    }

    .el-date-editor.el-input__wrapper {
      box-shadow: 0 0 0 1px var(--el-input-border-color, var(--el-border-color)) inset
    }

    .el-date-editor.el-input__wrapper:hover {
      box-shadow: 0 0 0 1px var(--el-input-hover-border-color) inset
    }

    .el-date-editor.el-input,
    .el-date-editor.el-input__wrapper {
      width: var(--el-date-editor-width);
      height: var(--el-input-height, var(--el-component-size))
    }

    .el-date-editor--monthrange {
      --el-date-editor-width: var(--el-date-editor-monthrange-width)
    }

    .el-date-editor--daterange,
    .el-date-editor--timerange {
      --el-date-editor-width: var(--el-date-editor-daterange-width)
    }

    .el-date-editor--datetimerange {
      --el-date-editor-width: var(--el-date-editor-datetimerange-width)
    }

    .el-date-editor--dates .el-input__wrapper {
      text-overflow: ellipsis;
      white-space: nowrap
    }

    .el-date-editor .close-icon {
      cursor: pointer
    }

    .el-date-editor .clear-icon {
      cursor: pointer
    }

    .el-date-editor .clear-icon:hover {
      color: var(--el-text-color-secondary)
    }

    .el-date-editor .el-range__icon {
      height: inherit;
      font-size: 14px;
      color: var(--el-text-color-placeholder);
      float: left
    }

    .el-date-editor .el-range__icon svg {
      vertical-align: middle
    }

    .el-date-editor .el-range-input {
      -webkit-appearance: none;
      -moz-appearance: none;
      appearance: none;
      border: none;
      outline: 0;
      display: inline-block;
      height: 30px;
      line-height: 30px;
      margin: 0;
      padding: 0;
      width: 39%;
      text-align: center;
      font-size: var(--el-font-size-base);
      color: var(--el-text-color-regular);
      background-color: transparent
    }

    .el-date-editor .el-range-input::-moz-placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-date-editor .el-range-input:-ms-input-placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-date-editor .el-range-input::placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-date-editor .el-range-separator {
      flex: 1;
      display: inline-flex;
      justify-content: center;
      align-items: center;
      height: 100%;
      padding: 0 5px;
      margin: 0;
      font-size: 14px;
      overflow-wrap: break-word;
      color: var(--el-text-color-primary)
    }

    .el-date-editor .el-range__close-icon {
      font-size: 14px;
      color: var(--el-text-color-placeholder);
      height: inherit;
      width: unset;
      cursor: pointer
    }

    .el-date-editor .el-range__close-icon:hover {
      color: var(--el-text-color-secondary)
    }

    .el-date-editor .el-range__close-icon svg {
      vertical-align: middle
    }

    .el-date-editor .el-range__close-icon--hidden {
      opacity: 0;
      visibility: hidden
    }

    .el-range-editor.el-input__wrapper {
      display: inline-flex;
      align-items: center;
      padding: 0 10px
    }

    .el-range-editor.is-active {
      box-shadow: 0 0 0 1px var(--el-input-focus-border-color) inset
    }

    .el-range-editor.is-active:hover {
      box-shadow: 0 0 0 1px var(--el-input-focus-border-color) inset
    }

    .el-range-editor--large {
      line-height: var(--el-component-size-large)
    }

    .el-range-editor--large.el-input__wrapper {
      height: var(--el-component-size-large)
    }

    .el-range-editor--large .el-range-separator {
      line-height: 40px;
      font-size: 14px
    }

    .el-range-editor--large .el-range-input {
      height: 38px;
      line-height: 38px;
      font-size: 14px
    }

    .el-range-editor--small {
      line-height: var(--el-component-size-small)
    }

    .el-range-editor--small.el-input__wrapper {
      height: var(--el-component-size-small)
    }

    .el-range-editor--small .el-range-separator {
      line-height: 24px;
      font-size: 12px
    }

    .el-range-editor--small .el-range-input {
      height: 22px;
      line-height: 22px;
      font-size: 12px
    }

    .el-range-editor.is-disabled {
      background-color: var(--el-disabled-bg-color);
      border-color: var(--el-disabled-border-color);
      color: var(--el-disabled-text-color);
      cursor: not-allowed
    }

    .el-range-editor.is-disabled:focus,
    .el-range-editor.is-disabled:hover {
      border-color: var(--el-disabled-border-color)
    }

    .el-range-editor.is-disabled input {
      background-color: var(--el-disabled-bg-color);
      color: var(--el-disabled-text-color);
      cursor: not-allowed
    }

    .el-range-editor.is-disabled input::-moz-placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-range-editor.is-disabled input:-ms-input-placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-range-editor.is-disabled input::placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-range-editor.is-disabled .el-range-separator {
      color: var(--el-disabled-text-color)
    }

    .el-picker-panel {
      color: var(--el-text-color-regular);
      background: var(--el-bg-color-overlay);
      border-radius: var(--el-border-radius-base);
      line-height: 30px
    }

    .el-picker-panel .el-time-panel {
      margin: 5px 0;
      border: solid 1px var(--el-datepicker-border-color);
      background-color: var(--el-bg-color-overlay);
      box-shadow: var(--el-box-shadow-light)
    }

    .el-picker-panel__body-wrapper::after,
    .el-picker-panel__body::after {
      content: """";
      display: table;
      clear: both
    }

    .el-picker-panel__content {
      position: relative;
      margin: 15px
    }

    .el-picker-panel__footer {
      border-top: 1px solid var(--el-datepicker-inner-border-color);
      padding: 4px 12px;
      text-align: right;
      background-color: var(--el-bg-color-overlay);
      position: relative;
      font-size: 0
    }

    .el-picker-panel__shortcut {
      display: block;
      width: 100%;
      border: 0;
      background-color: transparent;
      line-height: 28px;
      font-size: 14px;
      color: var(--el-datepicker-text-color);
      padding-left: 12px;
      text-align: left;
      outline: 0;
      cursor: pointer
    }

    .el-picker-panel__shortcut:hover {
      color: var(--el-datepicker-hover-text-color)
    }

    .el-picker-panel__shortcut.active {
      background-color: #e6f1fe;
      color: var(--el-datepicker-active-color)
    }

    .el-picker-panel__btn {
      border: 1px solid var(--el-fill-color-darker);
      color: var(--el-text-color-primary);
      line-height: 24px;
      border-radius: 2px;
      padding: 0 20px;
      cursor: pointer;
      background-color: transparent;
      outline: 0;
      font-size: 12px
    }

    .el-picker-panel__btn[disabled] {
      color: var(--el-text-color-disabled);
      cursor: not-allowed
    }

    .el-picker-panel__icon-btn {
      font-size: 12px;
      color: var(--el-datepicker-icon-color);
      border: 0;
      background: 0 0;
      cursor: pointer;
      outline: 0;
      margin-top: 8px
    }

    .el-picker-panel__icon-btn:hover {
      color: var(--el-datepicker-hover-text-color)
    }

    .el-picker-panel__icon-btn:focus-visible {
      color: var(--el-datepicker-hover-text-color)
    }

    .el-picker-panel__icon-btn.is-disabled {
      color: var(--el-text-color-disabled)
    }

    .el-picker-panel__icon-btn.is-disabled:hover {
      cursor: not-allowed
    }

    .el-picker-panel__icon-btn .el-icon {
      cursor: pointer;
      font-size: inherit
    }

    .el-picker-panel__link-btn {
      vertical-align: middle
    }

    .el-picker-panel [slot=sidebar],
    .el-picker-panel__sidebar {
      position: absolute;
      top: 0;
      bottom: 0;
      width: 110px;
      border-right: 1px solid var(--el-datepicker-inner-border-color);
      box-sizing: border-box;
      padding-top: 6px;
      background-color: var(--el-bg-color-overlay);
      overflow: auto
    }

    .el-picker-panel [slot=sidebar]+.el-picker-panel__body,
    .el-picker-panel__sidebar+.el-picker-panel__body {
      margin-left: 110px
    }

    .el-date-picker {
      --el-datepicker-text-color: var(--el-text-color-regular);
      --el-datepicker-off-text-color: var(--el-text-color-placeholder);
      --el-datepicker-header-text-color: var(--el-text-color-regular);
      --el-datepicker-icon-color: var(--el-text-color-primary);
      --el-datepicker-border-color: var(--el-disabled-border-color);
      --el-datepicker-inner-border-color: var(--el-border-color-light);
      --el-datepicker-inrange-bg-color: var(--el-border-color-extra-light);
      --el-datepicker-inrange-hover-bg-color: var(--el-border-color-extra-light);
      --el-datepicker-active-color: var(--el-color-primary);
      --el-datepicker-hover-text-color: var(--el-color-primary)
    }

    .el-date-picker {
      width: 322px
    }

    .el-date-picker.has-sidebar.has-time {
      width: 434px
    }

    .el-date-picker.has-sidebar {
      width: 438px
    }

    .el-date-picker.has-time .el-picker-panel__body-wrapper {
      position: relative
    }

    .el-date-picker .el-picker-panel__content {
      width: 292px
    }

    .el-date-picker table {
      table-layout: fixed;
      width: 100%
    }

    .el-date-picker__editor-wrap {
      position: relative;
      display: table-cell;
      padding: 0 5px
    }

    .el-date-picker__time-header {
      position: relative;
      border-bottom: 1px solid var(--el-datepicker-inner-border-color);
      font-size: 12px;
      padding: 8px 5px 5px;
      display: table;
      width: 100%;
      box-sizing: border-box
    }

    .el-date-picker__header {
      margin: 12px;
      text-align: center
    }

    .el-date-picker__header--bordered {
      margin-bottom: 0;
      padding-bottom: 12px;
      border-bottom: solid 1px var(--el-border-color-lighter)
    }

    .el-date-picker__header--bordered+.el-picker-panel__content {
      margin-top: 0
    }

    .el-date-picker__header-label {
      font-size: 16px;
      font-weight: 500;
      padding: 0 5px;
      line-height: 22px;
      text-align: center;
      cursor: pointer;
      color: var(--el-text-color-regular)
    }

    .el-date-picker__header-label:hover {
      color: var(--el-datepicker-hover-text-color)
    }

    .el-date-picker__header-label:focus-visible {
      outline: 0;
      color: var(--el-datepicker-hover-text-color)
    }

    .el-date-picker__header-label.active {
      color: var(--el-datepicker-active-color)
    }

    .el-date-picker__prev-btn {
      float: left
    }

    .el-date-picker__next-btn {
      float: right
    }

    .el-date-picker__time-wrap {
      padding: 10px;
      text-align: center
    }

    .el-date-picker__time-label {
      float: left;
      cursor: pointer;
      line-height: 30px;
      margin-left: 10px
    }

    .el-date-picker .el-time-panel {
      position: absolute
    }

    .el-date-range-picker {
      --el-datepicker-text-color: var(--el-text-color-regular);
      --el-datepicker-off-text-color: var(--el-text-color-placeholder);
      --el-datepicker-header-text-color: var(--el-text-color-regular);
      --el-datepicker-icon-color: var(--el-text-color-primary);
      --el-datepicker-border-color: var(--el-disabled-border-color);
      --el-datepicker-inner-border-color: var(--el-border-color-light);
      --el-datepicker-inrange-bg-color: var(--el-border-color-extra-light);
      --el-datepicker-inrange-hover-bg-color: var(--el-border-color-extra-light);
      --el-datepicker-active-color: var(--el-color-primary);
      --el-datepicker-hover-text-color: var(--el-color-primary)
    }

    .el-date-range-picker {
      width: 646px
    }

    .el-date-range-picker.has-sidebar {
      width: 756px
    }

    .el-date-range-picker.has-time .el-picker-panel__body-wrapper {
      position: relative
    }

    .el-date-range-picker table {
      table-layout: fixed;
      width: 100%
    }

    .el-date-range-picker .el-picker-panel__body {
      min-width: 513px
    }

    .el-date-range-picker .el-picker-panel__content {
      margin: 0
    }

    .el-date-range-picker__header {
      position: relative;
      text-align: center;
      height: 28px
    }

    .el-date-range-picker__header [class*=arrow-left] {
      float: left
    }

    .el-date-range-picker__header [class*=arrow-right] {
      float: right
    }

    .el-date-range-picker__header div {
      font-size: 16px;
      font-weight: 500;
      margin-right: 50px
    }

    .el-date-range-picker__content {
      float: left;
      width: 50%;
      box-sizing: border-box;
      margin: 0;
      padding: 16px
    }

    .el-date-range-picker__content.is-left {
      border-right: 1px solid var(--el-datepicker-inner-border-color)
    }

    .el-date-range-picker__content .el-date-range-picker__header div {
      margin-left: 50px;
      margin-right: 50px
    }

    .el-date-range-picker__editors-wrap {
      box-sizing: border-box;
      display: table-cell
    }

    .el-date-range-picker__editors-wrap.is-right {
      text-align: right
    }

    .el-date-range-picker__time-header {
      position: relative;
      border-bottom: 1px solid var(--el-datepicker-inner-border-color);
      font-size: 12px;
      padding: 8px 5px 5px 5px;
      display: table;
      width: 100%;
      box-sizing: border-box
    }

    .el-date-range-picker__time-header>.el-icon-arrow-right {
      font-size: 20px;
      vertical-align: middle;
      display: table-cell;
      color: var(--el-datepicker-icon-color)
    }

    .el-date-range-picker__time-picker-wrap {
      position: relative;
      display: table-cell;
      padding: 0 5px
    }

    .el-date-range-picker__time-picker-wrap .el-picker-panel {
      position: absolute;
      top: 13px;
      right: 0;
      z-index: 1;
      background: #fff
    }

    .el-date-range-picker__time-picker-wrap .el-time-panel {
      position: absolute
    }

    .el-time-range-picker {
      width: 354px;
      overflow: visible
    }

    .el-time-range-picker__content {
      position: relative;
      text-align: center;
      padding: 10px;
      z-index: 1
    }

    .el-time-range-picker__cell {
      box-sizing: border-box;
      margin: 0;
      padding: 4px 7px 7px;
      width: 50%;
      display: inline-block
    }

    .el-time-range-picker__header {
      margin-bottom: 5px;
      text-align: center;
      font-size: 14px
    }

    .el-time-range-picker__body {
      border-radius: 2px;
      border: 1px solid var(--el-datepicker-border-color)
    }

    .el-time-panel {
      border-radius: 2px;
      position: relative;
      width: 180px;
      left: 0;
      z-index: var(--el-index-top);
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      box-sizing: content-box
    }

    .el-time-panel__content {
      font-size: 0;
      position: relative;
      overflow: hidden
    }

    .el-time-panel__content::after,
    .el-time-panel__content::before {
      content: """";
      top: 50%;
      position: absolute;
      margin-top: -16px;
      height: 32px;
      z-index: -1;
      left: 0;
      right: 0;
      box-sizing: border-box;
      padding-top: 6px;
      text-align: left
    }

    .el-time-panel__content::after {
      left: 50%;
      margin-left: 12%;
      margin-right: 12%
    }

    .el-time-panel__content::before {
      padding-left: 50%;
      margin-right: 12%;
      margin-left: 12%;
      border-top: 1px solid var(--el-border-color-light);
      border-bottom: 1px solid var(--el-border-color-light)
    }

    .el-time-panel__content.has-seconds::after {
      left: 66.6666666667%
    }

    .el-time-panel__content.has-seconds::before {
      padding-left: 33.3333333333%
    }

    .el-time-panel__footer {
      border-top: 1px solid var(--el-timepicker-inner-border-color, var(--el-border-color-light));
      padding: 4px;
      height: 36px;
      line-height: 25px;
      text-align: right;
      box-sizing: border-box
    }

    .el-time-panel__btn {
      border: none;
      line-height: 28px;
      padding: 0 5px;
      margin: 0 5px;
      cursor: pointer;
      background-color: transparent;
      outline: 0;
      font-size: 12px;
      color: var(--el-text-color-primary)
    }

    .el-time-panel__btn.confirm {
      font-weight: 800;
      color: var(--el-timepicker-active-color, var(--el-color-primary))
    }

    .el-descriptions {
      --el-descriptions-table-border: 1px solid var(--el-border-color-lighter);
      --el-descriptions-item-bordered-label-background: var(--el-fill-color-light);
      box-sizing: border-box;
      font-size: var(--el-font-size-base);
      color: var(--el-text-color-primary)
    }

    .el-descriptions__header {
      display: flex;
      justify-content: space-between;
      align-items: center;
      margin-bottom: 16px
    }

    .el-descriptions__title {
      color: var(--el-text-color-primary);
      font-size: 16px;
      font-weight: 700
    }

    .el-descriptions__body {
      background-color: var(--el-fill-color-blank)
    }

    .el-descriptions__body .el-descriptions__table {
      border-collapse: collapse;
      width: 100%
    }

    .el-descriptions__body .el-descriptions__table .el-descriptions__cell {
      box-sizing: border-box;
      text-align: left;
      font-weight: 400;
      line-height: 23px;
      font-size: 14px
    }

    .el-descriptions__body .el-descriptions__table .el-descriptions__cell.is-left {
      text-align: left
    }

    .el-descriptions__body .el-descriptions__table .el-descriptions__cell.is-center {
      text-align: center
    }

    .el-descriptions__body .el-descriptions__table .el-descriptions__cell.is-right {
      text-align: right
    }

    .el-descriptions__body .el-descriptions__table.is-bordered .el-descriptions__cell {
      border: var(--el-descriptions-table-border);
      padding: 8px 11px
    }

    .el-descriptions__body .el-descriptions__table:not(.is-bordered) .el-descriptions__cell {
      padding-bottom: 12px
    }

    .el-descriptions--large {
      font-size: 14px
    }

    .el-descriptions--large .el-descriptions__header {
      margin-bottom: 20px
    }

    .el-descriptions--large .el-descriptions__header .el-descriptions__title {
      font-size: 16px
    }

    .el-descriptions--large .el-descriptions__body .el-descriptions__table .el-descriptions__cell {
      font-size: 14px
    }

    .el-descriptions--large .el-descriptions__body .el-descriptions__table.is-bordered .el-descriptions__cell {
      padding: 12px 15px
    }

    .el-descriptions--large .el-descriptions__body .el-descriptions__table:not(.is-bordered) .el-descriptions__cell {
      padding-bottom: 16px
    }

    .el-descriptions--small {
      font-size: 12px
    }

    .el-descriptions--small .el-descriptions__header {
      margin-bottom: 12px
    }

    .el-descriptions--small .el-descriptions__header .el-descriptions__title {
      font-size: 14px
    }

    .el-descriptions--small .el-descriptions__body .el-descriptions__table .el-descriptions__cell {
      font-size: 12px
    }

    .el-descriptions--small .el-descriptions__body .el-descriptions__table.is-bordered .el-descriptions__cell {
      padding: 4px 7px
    }

    .el-descriptions--small .el-descriptions__body .el-descriptions__table:not(.is-bordered) .el-descriptions__cell {
      padding-bottom: 8px
    }

    .el-descriptions__label.el-descriptions__cell.is-bordered-label {
      font-weight: 700;
      color: var(--el-text-color-regular);
      background: var(--el-descriptions-item-bordered-label-background)
    }

    .el-descriptions__label:not(.is-bordered-label) {
      color: var(--el-text-color-primary);
      margin-right: 16px
    }

    .el-descriptions__label.el-descriptions__cell:not(.is-bordered-label).is-vertical-label {
      padding-bottom: 6px
    }

    .el-descriptions__content.el-descriptions__cell.is-bordered-content {
      color: var(--el-text-color-primary)
    }

    .el-descriptions__content:not(.is-bordered-label) {
      color: var(--el-text-color-regular)
    }

    .el-descriptions--large .el-descriptions__label:not(.is-bordered-label) {
      margin-right: 16px
    }

    .el-descriptions--large .el-descriptions__label.el-descriptions__cell:not(.is-bordered-label).is-vertical-label {
      padding-bottom: 8px
    }

    .el-descriptions--small .el-descriptions__label:not(.is-bordered-label) {
      margin-right: 12px
    }

    .el-descriptions--small .el-descriptions__label.el-descriptions__cell:not(.is-bordered-label).is-vertical-label {
      padding-bottom: 4px
    }

    :root {
      --el-popup-modal-bg-color: var(--el-color-black);
      --el-popup-modal-opacity: 0.5
    }

    .v-modal-enter {
      -webkit-animation: v-modal-in var(--el-transition-duration-fast) ease;
      animation: v-modal-in var(--el-transition-duration-fast) ease
    }

    .v-modal-leave {
      -webkit-animation: v-modal-out var(--el-transition-duration-fast) ease forwards;
      animation: v-modal-out var(--el-transition-duration-fast) ease forwards
    }

    @-webkit-keyframes v-modal-in {
      0% {
        opacity: 0
      }
    }

    @keyframes v-modal-in {
      0% {
        opacity: 0
      }
    }

    @-webkit-keyframes v-modal-out {
      100% {
        opacity: 0
      }
    }

    @keyframes v-modal-out {
      100% {
        opacity: 0
      }
    }

    .v-modal {
      position: fixed;
      left: 0;
      top: 0;
      width: 100%;
      height: 100%;
      opacity: var(--el-popup-modal-opacity);
      background: var(--el-popup-modal-bg-color)
    }

    .el-popup-parent--hidden {
      overflow: hidden
    }

    .el-dialog {
      --el-dialog-width: 50%;
      --el-dialog-margin-top: 15vh;
      --el-dialog-bg-color: var(--el-bg-color);
      --el-dialog-box-shadow: var(--el-box-shadow);
      --el-dialog-title-font-size: var(--el-font-size-large);
      --el-dialog-content-font-size: 14px;
      --el-dialog-font-line-height: var(--el-font-line-height-primary);
      --el-dialog-padding-primary: 16px;
      --el-dialog-border-radius: var(--el-border-radius-small);
      position: relative;
      margin: var(--el-dialog-margin-top, 15vh) auto 50px;
      background: var(--el-dialog-bg-color);
      border-radius: var(--el-dialog-border-radius);
      box-shadow: var(--el-dialog-box-shadow);
      box-sizing: border-box;
      padding: var(--el-dialog-padding-primary);
      width: var(--el-dialog-width, 50%);
      overflow-wrap: break-word
    }

    .el-dialog:focus {
      outline: 0 !important
    }

    .el-dialog.is-align-center {
      margin: auto
    }

    .el-dialog.is-fullscreen {
      --el-dialog-width: 100%;
      --el-dialog-margin-top: 0;
      margin-bottom: 0;
      height: 100%;
      overflow: auto
    }

    .el-dialog__wrapper {
      position: fixed;
      top: 0;
      right: 0;
      bottom: 0;
      left: 0;
      overflow: auto;
      margin: 0
    }

    .el-dialog.is-draggable .el-dialog__header {
      cursor: move;
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none
    }

    .el-dialog__header {
      padding-bottom: var(--el-dialog-padding-primary)
    }

    .el-dialog__header.show-close {
      padding-right: calc(var(--el-dialog-padding-primary) + var(--el-message-close-size, 16px))
    }

    .el-dialog__headerbtn {
      position: absolute;
      top: 0;
      right: 0;
      padding: 0;
      width: 48px;
      height: 48px;
      background: 0 0;
      border: none;
      outline: 0;
      cursor: pointer;
      font-size: var(--el-message-close-size, 16px)
    }

    .el-dialog__headerbtn .el-dialog__close {
      color: var(--el-color-info);
      font-size: inherit
    }

    .el-dialog__headerbtn:focus .el-dialog__close,
    .el-dialog__headerbtn:hover .el-dialog__close {
      color: var(--el-color-primary)
    }

    .el-dialog__title {
      line-height: var(--el-dialog-font-line-height);
      font-size: var(--el-dialog-title-font-size);
      color: var(--el-text-color-primary)
    }

    .el-dialog__body {
      color: var(--el-text-color-regular);
      font-size: var(--el-dialog-content-font-size)
    }

    .el-dialog__footer {
      padding-top: var(--el-dialog-padding-primary);
      text-align: right;
      box-sizing: border-box
    }

    .el-dialog--center {
      text-align: center
    }

    .el-dialog--center .el-dialog__body {
      text-align: initial
    }

    .el-dialog--center .el-dialog__footer {
      text-align: inherit
    }

    .el-overlay-dialog {
      position: fixed;
      top: 0;
      right: 0;
      bottom: 0;
      left: 0;
      overflow: auto
    }

    .dialog-fade-enter-active {
      -webkit-animation: modal-fade-in var(--el-transition-duration);
      animation: modal-fade-in var(--el-transition-duration)
    }

    .dialog-fade-enter-active .el-overlay-dialog {
      -webkit-animation: dialog-fade-in var(--el-transition-duration);
      animation: dialog-fade-in var(--el-transition-duration)
    }

    .dialog-fade-leave-active {
      -webkit-animation: modal-fade-out var(--el-transition-duration);
      animation: modal-fade-out var(--el-transition-duration)
    }

    .dialog-fade-leave-active .el-overlay-dialog {
      -webkit-animation: dialog-fade-out var(--el-transition-duration);
      animation: dialog-fade-out var(--el-transition-duration)
    }

    @-webkit-keyframes dialog-fade-in {
      0% {
        transform: translate3d(0, -20px, 0);
        opacity: 0
      }

      100% {
        transform: translate3d(0, 0, 0);
        opacity: 1
      }
    }

    @keyframes dialog-fade-in {
      0% {
        transform: translate3d(0, -20px, 0);
        opacity: 0
      }

      100% {
        transform: translate3d(0, 0, 0);
        opacity: 1
      }
    }

    @-webkit-keyframes dialog-fade-out {
      0% {
        transform: translate3d(0, 0, 0);
        opacity: 1
      }

      100% {
        transform: translate3d(0, -20px, 0);
        opacity: 0
      }
    }

    @keyframes dialog-fade-out {
      0% {
        transform: translate3d(0, 0, 0);
        opacity: 1
      }

      100% {
        transform: translate3d(0, -20px, 0);
        opacity: 0
      }
    }

    @-webkit-keyframes modal-fade-in {
      0% {
        opacity: 0
      }

      100% {
        opacity: 1
      }
    }

    @keyframes modal-fade-in {
      0% {
        opacity: 0
      }

      100% {
        opacity: 1
      }
    }

    @-webkit-keyframes modal-fade-out {
      0% {
        opacity: 1
      }

      100% {
        opacity: 0
      }
    }

    @keyframes modal-fade-out {
      0% {
        opacity: 1
      }

      100% {
        opacity: 0
      }
    }

    .el-divider {
      position: relative
    }

    .el-divider--horizontal {
      display: block;
      height: 1px;
      width: 100%;
      margin: 24px 0;
      border-top: 1px var(--el-border-color) var(--el-border-style)
    }

    .el-divider--vertical {
      display: inline-block;
      width: 1px;
      height: 1em;
      margin: 0 8px;
      vertical-align: middle;
      position: relative;
      border-left: 1px var(--el-border-color) var(--el-border-style)
    }

    .el-divider__text {
      position: absolute;
      background-color: var(--el-bg-color);
      padding: 0 20px;
      font-weight: 500;
      color: var(--el-text-color-primary);
      font-size: 14px
    }

    .el-divider__text.is-left {
      left: 20px;
      transform: translateY(-50%)
    }

    .el-divider__text.is-center {
      left: 50%;
      transform: translateX(-50%) translateY(-50%)
    }

    .el-divider__text.is-right {
      right: 20px;
      transform: translateY(-50%)
    }

    .el-drawer {
      --el-drawer-bg-color: var(--el-dialog-bg-color, var(--el-bg-color));
      --el-drawer-padding-primary: var(--el-dialog-padding-primary, 20px)
    }

    .el-drawer {
      position: absolute;
      box-sizing: border-box;
      background-color: var(--el-drawer-bg-color);
      display: flex;
      flex-direction: column;
      box-shadow: var(--el-box-shadow-dark);
      overflow: hidden;
      transition: all var(--el-transition-duration)
    }

    .el-drawer .rtl {
      transform: translate(0, 0)
    }

    .el-drawer .ltr {
      transform: translate(0, 0)
    }

    .el-drawer .ttb {
      transform: translate(0, 0)
    }

    .el-drawer .btt {
      transform: translate(0, 0)
    }

    .el-drawer__sr-focus:focus {
      outline: 0 !important
    }

    .el-drawer__header {
      align-items: center;
      color: #72767b;
      display: flex;
      margin-bottom: 32px;
      padding: var(--el-drawer-padding-primary);
      padding-bottom: 0
    }

    .el-drawer__header>:first-child {
      flex: 1
    }

    .el-drawer__title {
      margin: 0;
      flex: 1;
      line-height: inherit;
      font-size: 1rem
    }

    .el-drawer__footer {
      padding: var(--el-drawer-padding-primary);
      padding-top: 10px;
      text-align: right
    }

    .el-drawer__close-btn {
      display: inline-flex;
      border: none;
      cursor: pointer;
      font-size: var(--el-font-size-extra-large);
      color: inherit;
      background-color: transparent;
      outline: 0
    }

    .el-drawer__close-btn:focus i,
    .el-drawer__close-btn:hover i {
      color: var(--el-color-primary)
    }

    .el-drawer__body {
      flex: 1;
      padding: var(--el-drawer-padding-primary);
      overflow: auto
    }

    .el-drawer__body>* {
      box-sizing: border-box
    }

    .el-drawer.ltr,
    .el-drawer.rtl {
      height: 100%;
      top: 0;
      bottom: 0
    }

    .el-drawer.btt,
    .el-drawer.ttb {
      width: 100%;
      left: 0;
      right: 0
    }

    .el-drawer.ltr {
      left: 0
    }

    .el-drawer.rtl {
      right: 0
    }

    .el-drawer.ttb {
      top: 0
    }

    .el-drawer.btt {
      bottom: 0
    }

    .el-drawer-fade-enter-active,
    .el-drawer-fade-leave-active {
      transition: all var(--el-transition-duration)
    }

    .el-drawer-fade-enter-active,
    .el-drawer-fade-enter-from,
    .el-drawer-fade-enter-to,
    .el-drawer-fade-leave-active,
    .el-drawer-fade-leave-from,
    .el-drawer-fade-leave-to {
      overflow: hidden !important
    }

    .el-drawer-fade-enter-from,
    .el-drawer-fade-leave-to {
      opacity: 0
    }

    .el-drawer-fade-enter-to,
    .el-drawer-fade-leave-from {
      opacity: 1
    }

    .el-drawer-fade-enter-from .rtl,
    .el-drawer-fade-leave-to .rtl {
      transform: translateX(100%)
    }

    .el-drawer-fade-enter-from .ltr,
    .el-drawer-fade-leave-to .ltr {
      transform: translateX(-100%)
    }

    .el-drawer-fade-enter-from .ttb,
    .el-drawer-fade-leave-to .ttb {
      transform: translateY(-100%)
    }

    .el-drawer-fade-enter-from .btt,
    .el-drawer-fade-leave-to .btt {
      transform: translateY(100%)
    }

    .el-dropdown {
      --el-dropdown-menu-box-shadow: var(--el-box-shadow-light);
      --el-dropdown-menuItem-hover-fill: var(--el-color-primary-light-9);
      --el-dropdown-menuItem-hover-color: var(--el-color-primary);
      --el-dropdown-menu-index: 10;
      display: inline-flex;
      position: relative;
      color: var(--el-text-color-regular);
      font-size: var(--el-font-size-base);
      line-height: 1;
      vertical-align: top
    }

    .el-dropdown.is-disabled {
      color: var(--el-text-color-placeholder);
      cursor: not-allowed
    }

    .el-dropdown__popper {
      --el-dropdown-menu-box-shadow: var(--el-box-shadow-light);
      --el-dropdown-menuItem-hover-fill: var(--el-color-primary-light-9);
      --el-dropdown-menuItem-hover-color: var(--el-color-primary);
      --el-dropdown-menu-index: 10
    }

    .el-dropdown__popper.el-popper {
      background: var(--el-bg-color-overlay);
      border: 1px solid var(--el-border-color-light);
      box-shadow: var(--el-dropdown-menu-box-shadow)
    }

    .el-dropdown__popper.el-popper .el-popper__arrow::before {
      border: 1px solid var(--el-border-color-light)
    }

    .el-dropdown__popper.el-popper[data-popper-placement^=top] .el-popper__arrow::before {
      border-top-color: transparent;
      border-left-color: transparent
    }

    .el-dropdown__popper.el-popper[data-popper-placement^=bottom] .el-popper__arrow::before {
      border-bottom-color: transparent;
      border-right-color: transparent
    }

    .el-dropdown__popper.el-popper[data-popper-placement^=left] .el-popper__arrow::before {
      border-left-color: transparent;
      border-bottom-color: transparent
    }

    .el-dropdown__popper.el-popper[data-popper-placement^=right] .el-popper__arrow::before {
      border-right-color: transparent;
      border-top-color: transparent
    }

    .el-dropdown__popper .el-dropdown-menu {
      border: none
    }

    .el-dropdown__popper .el-dropdown__popper-selfdefine {
      outline: 0
    }

    .el-dropdown__popper .el-scrollbar__bar {
      z-index: calc(var(--el-dropdown-menu-index) + 1)
    }

    .el-dropdown__popper .el-dropdown__list {
      list-style: none;
      padding: 0;
      margin: 0;
      box-sizing: border-box
    }

    .el-dropdown .el-dropdown__caret-button {
      padding-left: 0;
      padding-right: 0;
      display: inline-flex;
      justify-content: center;
      align-items: center;
      width: 32px;
      border-left: none
    }

    .el-dropdown .el-dropdown__caret-button>span {
      display: inline-flex
    }

    .el-dropdown .el-dropdown__caret-button::before {
      content: """";
      position: absolute;
      display: block;
      width: 1px;
      top: -1px;
      bottom: -1px;
      left: 0;
      background: var(--el-overlay-color-lighter)
    }

    .el-dropdown .el-dropdown__caret-button.el-button::before {
      background: var(--el-border-color);
      opacity: .5
    }

    .el-dropdown .el-dropdown__caret-button .el-dropdown__icon {
      font-size: inherit;
      padding-left: 0
    }

    .el-dropdown .el-dropdown-selfdefine {
      outline: 0
    }

    .el-dropdown--large .el-dropdown__caret-button {
      width: 40px
    }

    .el-dropdown--small .el-dropdown__caret-button {
      width: 24px
    }

    .el-dropdown-menu {
      position: relative;
      top: 0;
      left: 0;
      z-index: var(--el-dropdown-menu-index);
      padding: 5px 0;
      margin: 0;
      background-color: var(--el-bg-color-overlay);
      border: none;
      border-radius: var(--el-border-radius-base);
      box-shadow: none;
      list-style: none
    }

    .el-dropdown-menu__item {
      display: flex;
      align-items: center;
      white-space: nowrap;
      list-style: none;
      line-height: 22px;
      padding: 5px 16px;
      margin: 0;
      font-size: var(--el-font-size-base);
      color: var(--el-text-color-regular);
      cursor: pointer;
      outline: 0
    }

    .el-dropdown-menu__item:not(.is-disabled):focus {
      background-color: var(--el-dropdown-menuItem-hover-fill);
      color: var(--el-dropdown-menuItem-hover-color)
    }

    .el-dropdown-menu__item i {
      margin-right: 5px
    }

    .el-dropdown-menu__item--divided {
      margin: 6px 0;
      border-top: 1px solid var(--el-border-color-lighter)
    }

    .el-dropdown-menu__item.is-disabled {
      cursor: not-allowed;
      color: var(--el-text-color-disabled)
    }

    .el-dropdown-menu--large {
      padding: 7px 0
    }

    .el-dropdown-menu--large .el-dropdown-menu__item {
      padding: 7px 20px;
      line-height: 22px;
      font-size: 14px
    }

    .el-dropdown-menu--large .el-dropdown-menu__item--divided {
      margin: 8px 0
    }

    .el-dropdown-menu--small {
      padding: 3px 0
    }

    .el-dropdown-menu--small .el-dropdown-menu__item {
      padding: 2px 12px;
      line-height: 20px;
      font-size: 12px
    }

    .el-dropdown-menu--small .el-dropdown-menu__item--divided {
      margin: 4px 0
    }

    .el-empty {
      --el-empty-padding: 40px 0;
      --el-empty-image-width: 160px;
      --el-empty-description-margin-top: 20px;
      --el-empty-bottom-margin-top: 20px;
      --el-empty-fill-color-0: var(--el-color-white);
      --el-empty-fill-color-1: #fcfcfd;
      --el-empty-fill-color-2: #f8f9fb;
      --el-empty-fill-color-3: #f7f8fc;
      --el-empty-fill-color-4: #eeeff3;
      --el-empty-fill-color-5: #edeef2;
      --el-empty-fill-color-6: #e9ebef;
      --el-empty-fill-color-7: #e5e7e9;
      --el-empty-fill-color-8: #e0e3e9;
      --el-empty-fill-color-9: #d5d7de;
      display: flex;
      justify-content: center;
      align-items: center;
      flex-direction: column;
      text-align: center;
      box-sizing: border-box;
      padding: var(--el-empty-padding)
    }

    .el-empty__image {
      width: var(--el-empty-image-width)
    }

    .el-empty__image img {
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      width: 100%;
      height: 100%;
      vertical-align: top;
      -o-object-fit: contain;
      object-fit: contain
    }

    .el-empty__image svg {
      color: var(--el-svg-monochrome-grey);
      fill: currentColor;
      width: 100%;
      height: 100%;
      vertical-align: top
    }

    .el-empty__description {
      margin-top: var(--el-empty-description-margin-top)
    }

    .el-empty__description p {
      margin: 0;
      font-size: var(--el-font-size-base);
      color: var(--el-text-color-secondary)
    }

    .el-empty__bottom {
      margin-top: var(--el-empty-bottom-margin-top)
    }

    .el-footer {
      --el-footer-padding: 0 20px;
      --el-footer-height: 60px;
      padding: var(--el-footer-padding);
      box-sizing: border-box;
      flex-shrink: 0;
      height: var(--el-footer-height)
    }

    .el-form {
      --el-form-label-font-size: var(--el-font-size-base);
      --el-form-inline-content-width: 220px
    }

    .el-form--label-left .el-form-item__label {
      justify-content: flex-start
    }

    .el-form--label-top .el-form-item {
      display: block
    }

    .el-form--label-top .el-form-item .el-form-item__label {
      display: block;
      height: auto;
      text-align: left;
      margin-bottom: 8px;
      line-height: 22px
    }

    .el-form--inline .el-form-item {
      display: inline-flex;
      vertical-align: middle;
      margin-right: 32px
    }

    .el-form--inline.el-form--label-top {
      display: flex;
      flex-wrap: wrap
    }

    .el-form--inline.el-form--label-top .el-form-item {
      display: block
    }

    .el-form--large.el-form--label-top .el-form-item .el-form-item__label {
      margin-bottom: 12px;
      line-height: 22px
    }

    .el-form--default.el-form--label-top .el-form-item .el-form-item__label {
      margin-bottom: 8px;
      line-height: 22px
    }

    .el-form--small.el-form--label-top .el-form-item .el-form-item__label {
      margin-bottom: 4px;
      line-height: 20px
    }

    .el-form-item {
      display: flex;
      --font-size: 14px;
      margin-bottom: 18px
    }

    .el-form-item .el-form-item {
      margin-bottom: 0
    }

    .el-form-item .el-input__validateIcon {
      display: none
    }

    .el-form-item--large {
      --font-size: 14px;
      --el-form-label-font-size: var(--font-size);
      margin-bottom: 22px
    }

    .el-form-item--large .el-form-item__label {
      height: 40px;
      line-height: 40px
    }

    .el-form-item--large .el-form-item__content {
      line-height: 40px
    }

    .el-form-item--large .el-form-item__error {
      padding-top: 4px
    }

    .el-form-item--default {
      --font-size: 14px;
      --el-form-label-font-size: var(--font-size);
      margin-bottom: 18px
    }

    .el-form-item--default .el-form-item__label {
      height: 32px;
      line-height: 32px
    }

    .el-form-item--default .el-form-item__content {
      line-height: 32px
    }

    .el-form-item--default .el-form-item__error {
      padding-top: 2px
    }

    .el-form-item--small {
      --font-size: 12px;
      --el-form-label-font-size: var(--font-size);
      margin-bottom: 18px
    }

    .el-form-item--small .el-form-item__label {
      height: 24px;
      line-height: 24px
    }

    .el-form-item--small .el-form-item__content {
      line-height: 24px
    }

    .el-form-item--small .el-form-item__error {
      padding-top: 2px
    }

    .el-form-item__label-wrap {
      display: flex
    }

    .el-form-item__label {
      display: inline-flex;
      justify-content: flex-end;
      align-items: flex-start;
      flex: 0 0 auto;
      font-size: var(--el-form-label-font-size);
      color: var(--el-text-color-regular);
      height: 32px;
      line-height: 32px;
      padding: 0 12px 0 0;
      box-sizing: border-box
    }

    .el-form-item__content {
      display: flex;
      flex-wrap: wrap;
      align-items: center;
      flex: 1;
      line-height: 32px;
      position: relative;
      font-size: var(--font-size);
      min-width: 0
    }

    .el-form-item__content .el-input-group {
      vertical-align: top
    }

    .el-form-item__error {
      color: var(--el-color-danger);
      font-size: 12px;
      line-height: 1;
      padding-top: 2px;
      position: absolute;
      top: 100%;
      left: 0
    }

    .el-form-item__error--inline {
      position: relative;
      top: auto;
      left: auto;
      display: inline-block;
      margin-left: 10px
    }

    .el-form-item.is-required:not(.is-no-asterisk).asterisk-left>.el-form-item__label-wrap>.el-form-item__label:before,
    .el-form-item.is-required:not(.is-no-asterisk).asterisk-left>.el-form-item__label:before {
      content: ""*"";
      color: var(--el-color-danger);
      margin-right: 4px
    }

    .el-form-item.is-required:not(.is-no-asterisk).asterisk-right>.el-form-item__label-wrap>.el-form-item__label:after,
    .el-form-item.is-required:not(.is-no-asterisk).asterisk-right>.el-form-item__label:after {
      content: ""*"";
      color: var(--el-color-danger);
      margin-left: 4px
    }

    .el-form-item.is-error .el-input__wrapper,
    .el-form-item.is-error .el-input__wrapper.is-focus,
    .el-form-item.is-error .el-input__wrapper:focus,
    .el-form-item.is-error .el-input__wrapper:hover,
    .el-form-item.is-error .el-select__wrapper,
    .el-form-item.is-error .el-select__wrapper.is-focus,
    .el-form-item.is-error .el-select__wrapper:focus,
    .el-form-item.is-error .el-select__wrapper:hover,
    .el-form-item.is-error .el-textarea__inner,
    .el-form-item.is-error .el-textarea__inner.is-focus,
    .el-form-item.is-error .el-textarea__inner:focus,
    .el-form-item.is-error .el-textarea__inner:hover {
      box-shadow: 0 0 0 1px var(--el-color-danger) inset
    }

    .el-form-item.is-error .el-input-group__append .el-input__wrapper,
    .el-form-item.is-error .el-input-group__prepend .el-input__wrapper {
      box-shadow: 0 0 0 1px transparent inset
    }

    .el-form-item.is-error .el-input__validateIcon {
      color: var(--el-color-danger)
    }

    .el-form-item--feedback .el-input__validateIcon {
      display: inline-flex
    }

    .el-header {
      --el-header-padding: 0 20px;
      --el-header-height: 60px;
      padding: var(--el-header-padding);
      box-sizing: border-box;
      flex-shrink: 0;
      height: var(--el-header-height)
    }

    .el-image-viewer__wrapper {
      position: fixed;
      top: 0;
      right: 0;
      bottom: 0;
      left: 0
    }

    .el-image-viewer__btn {
      position: absolute;
      z-index: 1;
      display: flex;
      align-items: center;
      justify-content: center;
      border-radius: 50%;
      opacity: .8;
      cursor: pointer;
      box-sizing: border-box;
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none
    }

    .el-image-viewer__btn .el-icon {
      font-size: inherit;
      cursor: pointer
    }

    .el-image-viewer__close {
      top: 40px;
      right: 40px;
      width: 40px;
      height: 40px;
      font-size: 40px
    }

    .el-image-viewer__canvas {
      position: static;
      width: 100%;
      height: 100%;
      display: flex;
      justify-content: center;
      align-items: center;
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none
    }

    .el-image-viewer__actions {
      left: 50%;
      bottom: 30px;
      transform: translateX(-50%);
      width: 282px;
      height: 44px;
      padding: 0 23px;
      background-color: var(--el-text-color-regular);
      border-color: #fff;
      border-radius: 22px
    }

    .el-image-viewer__actions__inner {
      width: 100%;
      height: 100%;
      cursor: default;
      font-size: 23px;
      color: #fff;
      display: flex;
      align-items: center;
      justify-content: space-around
    }

    .el-image-viewer__prev {
      top: 50%;
      transform: translateY(-50%);
      left: 40px;
      width: 44px;
      height: 44px;
      font-size: 24px;
      color: #fff;
      background-color: var(--el-text-color-regular);
      border-color: #fff
    }

    .el-image-viewer__next {
      top: 50%;
      transform: translateY(-50%);
      right: 40px;
      text-indent: 2px;
      width: 44px;
      height: 44px;
      font-size: 24px;
      color: #fff;
      background-color: var(--el-text-color-regular);
      border-color: #fff
    }

    .el-image-viewer__close {
      width: 44px;
      height: 44px;
      font-size: 24px;
      color: #fff;
      background-color: var(--el-text-color-regular);
      border-color: #fff
    }

    .el-image-viewer__mask {
      position: absolute;
      width: 100%;
      height: 100%;
      top: 0;
      left: 0;
      opacity: .5;
      background: #000
    }

    .viewer-fade-enter-active {
      -webkit-animation: viewer-fade-in var(--el-transition-duration);
      animation: viewer-fade-in var(--el-transition-duration)
    }

    .viewer-fade-leave-active {
      -webkit-animation: viewer-fade-out var(--el-transition-duration);
      animation: viewer-fade-out var(--el-transition-duration)
    }

    @-webkit-keyframes viewer-fade-in {
      0% {
        transform: translate3d(0, -20px, 0);
        opacity: 0
      }

      100% {
        transform: translate3d(0, 0, 0);
        opacity: 1
      }
    }

    @keyframes viewer-fade-in {
      0% {
        transform: translate3d(0, -20px, 0);
        opacity: 0
      }

      100% {
        transform: translate3d(0, 0, 0);
        opacity: 1
      }
    }

    @-webkit-keyframes viewer-fade-out {
      0% {
        transform: translate3d(0, 0, 0);
        opacity: 1
      }

      100% {
        transform: translate3d(0, -20px, 0);
        opacity: 0
      }
    }

    @keyframes viewer-fade-out {
      0% {
        transform: translate3d(0, 0, 0);
        opacity: 1
      }

      100% {
        transform: translate3d(0, -20px, 0);
        opacity: 0
      }
    }

    .el-image__error,
    .el-image__inner,
    .el-image__placeholder,
    .el-image__wrapper {
      width: 100%;
      height: 100%
    }

    .el-image {
      position: relative;
      display: inline-block;
      overflow: hidden
    }

    .el-image__inner {
      vertical-align: top;
      opacity: 1
    }

    .el-image__inner.is-loading {
      opacity: 0
    }

    .el-image__wrapper {
      position: absolute;
      top: 0;
      left: 0
    }

    .el-image__placeholder {
      background: var(--el-fill-color-light)
    }

    .el-image__error {
      display: flex;
      justify-content: center;
      align-items: center;
      font-size: 14px;
      background: var(--el-fill-color-light);
      color: var(--el-text-color-placeholder);
      vertical-align: middle
    }

    .el-image__preview {
      cursor: pointer
    }

    .el-input-number {
      position: relative;
      display: inline-flex;
      width: 150px;
      line-height: 30px
    }

    .el-input-number .el-input__wrapper {
      padding-left: 42px;
      padding-right: 42px
    }

    .el-input-number .el-input__inner {
      -webkit-appearance: none;
      -moz-appearance: textfield;
      text-align: center;
      line-height: 1
    }

    .el-input-number .el-input__inner::-webkit-inner-spin-button,
    .el-input-number .el-input__inner::-webkit-outer-spin-button {
      margin: 0;
      -webkit-appearance: none
    }

    .el-input-number__decrease,
    .el-input-number__increase {
      display: flex;
      justify-content: center;
      align-items: center;
      height: auto;
      position: absolute;
      z-index: 1;
      top: 1px;
      bottom: 1px;
      width: 32px;
      background: var(--el-fill-color-light);
      color: var(--el-text-color-regular);
      cursor: pointer;
      font-size: 13px;
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none
    }

    .el-input-number__decrease:hover,
    .el-input-number__increase:hover {
      color: var(--el-color-primary)
    }

    .el-input-number__decrease:hover~.el-input:not(.is-disabled) .el-input__wrapper,
    .el-input-number__increase:hover~.el-input:not(.is-disabled) .el-input__wrapper {
      box-shadow: 0 0 0 1px var(--el-input-focus-border-color, var(--el-color-primary)) inset
    }

    .el-input-number__decrease.is-disabled,
    .el-input-number__increase.is-disabled {
      color: var(--el-disabled-text-color);
      cursor: not-allowed
    }

    .el-input-number__increase {
      right: 1px;
      border-radius: 0 var(--el-border-radius-base) var(--el-border-radius-base) 0;
      border-left: var(--el-border)
    }

    .el-input-number__decrease {
      left: 1px;
      border-radius: var(--el-border-radius-base) 0 0 var(--el-border-radius-base);
      border-right: var(--el-border)
    }

    .el-input-number.is-disabled .el-input-number__decrease,
    .el-input-number.is-disabled .el-input-number__increase {
      border-color: var(--el-disabled-border-color);
      color: var(--el-disabled-border-color)
    }

    .el-input-number.is-disabled .el-input-number__decrease:hover,
    .el-input-number.is-disabled .el-input-number__increase:hover {
      color: var(--el-disabled-border-color);
      cursor: not-allowed
    }

    .el-input-number--large {
      width: 180px;
      line-height: 38px
    }

    .el-input-number--large .el-input-number__decrease,
    .el-input-number--large .el-input-number__increase {
      width: 40px;
      font-size: 14px
    }

    .el-input-number--large .el-input__wrapper {
      padding-left: 47px;
      padding-right: 47px
    }

    .el-input-number--small {
      width: 120px;
      line-height: 22px
    }

    .el-input-number--small .el-input-number__decrease,
    .el-input-number--small .el-input-number__increase {
      width: 24px;
      font-size: 12px
    }

    .el-input-number--small .el-input__wrapper {
      padding-left: 31px;
      padding-right: 31px
    }

    .el-input-number--small .el-input-number__decrease [class*=el-icon],
    .el-input-number--small .el-input-number__increase [class*=el-icon] {
      transform: scale(.9)
    }

    .el-input-number.is-without-controls .el-input__wrapper {
      padding-left: 15px;
      padding-right: 15px
    }

    .el-input-number.is-controls-right .el-input__wrapper {
      padding-left: 15px;
      padding-right: 42px
    }

    .el-input-number.is-controls-right .el-input-number__decrease,
    .el-input-number.is-controls-right .el-input-number__increase {
      --el-input-number-controls-height: 15px;
      height: var(--el-input-number-controls-height);
      line-height: var(--el-input-number-controls-height)
    }

    .el-input-number.is-controls-right .el-input-number__decrease [class*=el-icon],
    .el-input-number.is-controls-right .el-input-number__increase [class*=el-icon] {
      transform: scale(.8)
    }

    .el-input-number.is-controls-right .el-input-number__increase {
      bottom: auto;
      left: auto;
      border-radius: 0 var(--el-border-radius-base) 0 0;
      border-bottom: var(--el-border)
    }

    .el-input-number.is-controls-right .el-input-number__decrease {
      right: 1px;
      top: auto;
      left: auto;
      border-right: none;
      border-left: var(--el-border);
      border-radius: 0 0 var(--el-border-radius-base) 0
    }

    .el-input-number.is-controls-right[class*=large] [class*=decrease],
    .el-input-number.is-controls-right[class*=large] [class*=increase] {
      --el-input-number-controls-height: 19px
    }

    .el-input-number.is-controls-right[class*=small] [class*=decrease],
    .el-input-number.is-controls-right[class*=small] [class*=increase] {
      --el-input-number-controls-height: 11px
    }

    .el-textarea {
      --el-input-text-color: var(--el-text-color-regular);
      --el-input-border: var(--el-border);
      --el-input-hover-border: var(--el-border-color-hover);
      --el-input-focus-border: var(--el-color-primary);
      --el-input-transparent-border: 0 0 0 1px transparent inset;
      --el-input-border-color: var(--el-border-color);
      --el-input-border-radius: var(--el-border-radius-base);
      --el-input-bg-color: var(--el-fill-color-blank);
      --el-input-icon-color: var(--el-text-color-placeholder);
      --el-input-placeholder-color: var(--el-text-color-placeholder);
      --el-input-hover-border-color: var(--el-border-color-hover);
      --el-input-clear-hover-color: var(--el-text-color-secondary);
      --el-input-focus-border-color: var(--el-color-primary);
      --el-input-width: 100%
    }

    .el-textarea {
      position: relative;
      display: inline-block;
      width: 100%;
      vertical-align: bottom;
      font-size: var(--el-font-size-base)
    }

    .el-textarea__inner {
      position: relative;
      display: block;
      resize: vertical;
      padding: 5px 11px;
      line-height: 1.5;
      box-sizing: border-box;
      width: 100%;
      font-size: inherit;
      font-family: inherit;
      color: var(--el-input-text-color, var(--el-text-color-regular));
      background-color: var(--el-input-bg-color, var(--el-fill-color-blank));
      background-image: none;
      -webkit-appearance: none;
      box-shadow: 0 0 0 1px var(--el-input-border-color, var(--el-border-color)) inset;
      border-radius: var(--el-input-border-radius, var(--el-border-radius-base));
      transition: var(--el-transition-box-shadow);
      border: none
    }

    .el-textarea__inner::-moz-placeholder {
      color: var(--el-input-placeholder-color, var(--el-text-color-placeholder))
    }

    .el-textarea__inner:-ms-input-placeholder {
      color: var(--el-input-placeholder-color, var(--el-text-color-placeholder))
    }

    .el-textarea__inner::placeholder {
      color: var(--el-input-placeholder-color, var(--el-text-color-placeholder))
    }

    .el-textarea__inner:hover {
      box-shadow: 0 0 0 1px var(--el-input-hover-border-color) inset
    }

    .el-textarea__inner:focus {
      outline: 0;
      box-shadow: 0 0 0 1px var(--el-input-focus-border-color) inset
    }

    .el-textarea .el-input__count {
      color: var(--el-color-info);
      background: var(--el-fill-color-blank);
      position: absolute;
      font-size: 12px;
      line-height: 14px;
      bottom: 5px;
      right: 10px
    }

    .el-textarea.is-disabled .el-textarea__inner {
      box-shadow: 0 0 0 1px var(--el-disabled-border-color) inset;
      background-color: var(--el-disabled-bg-color);
      color: var(--el-disabled-text-color);
      cursor: not-allowed
    }

    .el-textarea.is-disabled .el-textarea__inner::-moz-placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-textarea.is-disabled .el-textarea__inner:-ms-input-placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-textarea.is-disabled .el-textarea__inner::placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-textarea.is-exceed .el-textarea__inner {
      box-shadow: 0 0 0 1px var(--el-color-danger) inset
    }

    .el-textarea.is-exceed .el-input__count {
      color: var(--el-color-danger)
    }

    .el-input {
      --el-input-text-color: var(--el-text-color-regular);
      --el-input-border: var(--el-border);
      --el-input-hover-border: var(--el-border-color-hover);
      --el-input-focus-border: var(--el-color-primary);
      --el-input-transparent-border: 0 0 0 1px transparent inset;
      --el-input-border-color: var(--el-border-color);
      --el-input-border-radius: var(--el-border-radius-base);
      --el-input-bg-color: var(--el-fill-color-blank);
      --el-input-icon-color: var(--el-text-color-placeholder);
      --el-input-placeholder-color: var(--el-text-color-placeholder);
      --el-input-hover-border-color: var(--el-border-color-hover);
      --el-input-clear-hover-color: var(--el-text-color-secondary);
      --el-input-focus-border-color: var(--el-color-primary);
      --el-input-width: 100%
    }

    .el-input {
      --el-input-height: var(--el-component-size);
      position: relative;
      font-size: var(--el-font-size-base);
      display: inline-flex;
      width: var(--el-input-width);
      line-height: var(--el-input-height);
      box-sizing: border-box;
      vertical-align: middle
    }

    .el-input::-webkit-scrollbar {
      z-index: 11;
      width: 6px
    }

    .el-input::-webkit-scrollbar:horizontal {
      height: 6px
    }

    .el-input::-webkit-scrollbar-thumb {
      border-radius: 5px;
      width: 6px;
      background: var(--el-text-color-disabled)
    }

    .el-input::-webkit-scrollbar-corner {
      background: var(--el-fill-color-blank)
    }

    .el-input::-webkit-scrollbar-track {
      background: var(--el-fill-color-blank)
    }

    .el-input::-webkit-scrollbar-track-piece {
      background: var(--el-fill-color-blank);
      width: 6px
    }

    .el-input .el-input__clear,
    .el-input .el-input__password {
      color: var(--el-input-icon-color);
      font-size: 14px;
      cursor: pointer
    }

    .el-input .el-input__clear:hover,
    .el-input .el-input__password:hover {
      color: var(--el-input-clear-hover-color)
    }

    .el-input .el-input__count {
      height: 100%;
      display: inline-flex;
      align-items: center;
      color: var(--el-color-info);
      font-size: 12px
    }

    .el-input .el-input__count .el-input__count-inner {
      background: var(--el-fill-color-blank);
      line-height: initial;
      display: inline-block;
      padding-left: 8px
    }

    .el-input__wrapper {
      display: inline-flex;
      flex-grow: 1;
      align-items: center;
      justify-content: center;
      padding: 1px 11px;
      background-color: var(--el-input-bg-color, var(--el-fill-color-blank));
      background-image: none;
      border-radius: var(--el-input-border-radius, var(--el-border-radius-base));
      cursor: text;
      transition: var(--el-transition-box-shadow);
      transform: translate3d(0, 0, 0);
      box-shadow: 0 0 0 1px var(--el-input-border-color, var(--el-border-color)) inset
    }

    .el-input__wrapper:hover {
      box-shadow: 0 0 0 1px var(--el-input-hover-border-color) inset
    }

    .el-input__wrapper.is-focus {
      box-shadow: 0 0 0 1px var(--el-input-focus-border-color) inset
    }

    .el-input__inner {
      --el-input-inner-height: calc(var(--el-input-height, 32px) - 2px);
      width: 100%;
      flex-grow: 1;
      -webkit-appearance: none;
      color: var(--el-input-text-color, var(--el-text-color-regular));
      font-size: inherit;
      height: var(--el-input-inner-height);
      line-height: var(--el-input-inner-height);
      padding: 0;
      outline: 0;
      border: none;
      background: 0 0;
      box-sizing: border-box
    }

    .el-input__inner:focus {
      outline: 0
    }

    .el-input__inner::-moz-placeholder {
      color: var(--el-input-placeholder-color, var(--el-text-color-placeholder))
    }

    .el-input__inner:-ms-input-placeholder {
      color: var(--el-input-placeholder-color, var(--el-text-color-placeholder))
    }

    .el-input__inner::placeholder {
      color: var(--el-input-placeholder-color, var(--el-text-color-placeholder))
    }

    .el-input__inner[type=password]::-ms-reveal {
      display: none
    }

    .el-input__inner[type=number] {
      line-height: 1
    }

    .el-input__prefix {
      display: inline-flex;
      white-space: nowrap;
      flex-shrink: 0;
      flex-wrap: nowrap;
      height: 100%;
      text-align: center;
      color: var(--el-input-icon-color, var(--el-text-color-placeholder));
      transition: all var(--el-transition-duration);
      pointer-events: none
    }

    .el-input__prefix-inner {
      pointer-events: all;
      display: inline-flex;
      align-items: center;
      justify-content: center
    }

    .el-input__prefix-inner>:last-child {
      margin-right: 8px
    }

    .el-input__prefix-inner>:first-child,
    .el-input__prefix-inner>:first-child.el-input__icon {
      margin-left: 0
    }

    .el-input__suffix {
      display: inline-flex;
      white-space: nowrap;
      flex-shrink: 0;
      flex-wrap: nowrap;
      height: 100%;
      text-align: center;
      color: var(--el-input-icon-color, var(--el-text-color-placeholder));
      transition: all var(--el-transition-duration);
      pointer-events: none
    }

    .el-input__suffix-inner {
      pointer-events: all;
      display: inline-flex;
      align-items: center;
      justify-content: center
    }

    .el-input__suffix-inner>:first-child {
      margin-left: 8px
    }

    .el-input .el-input__icon {
      height: inherit;
      line-height: inherit;
      display: flex;
      justify-content: center;
      align-items: center;
      transition: all var(--el-transition-duration);
      margin-left: 8px
    }

    .el-input__validateIcon {
      pointer-events: none
    }

    .el-input.is-active .el-input__wrapper {
      box-shadow: 0 0 0 1px var(--el-input-focus-color, ) inset
    }

    .el-input.is-disabled {
      cursor: not-allowed
    }

    .el-input.is-disabled .el-input__wrapper {
      background-color: var(--el-disabled-bg-color);
      box-shadow: 0 0 0 1px var(--el-disabled-border-color) inset
    }

    .el-input.is-disabled .el-input__inner {
      color: var(--el-disabled-text-color);
      -webkit-text-fill-color: var(--el-disabled-text-color);
      cursor: not-allowed
    }

    .el-input.is-disabled .el-input__inner::-moz-placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-input.is-disabled .el-input__inner:-ms-input-placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-input.is-disabled .el-input__inner::placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-input.is-disabled .el-input__icon {
      cursor: not-allowed
    }

    .el-input.is-exceed .el-input__wrapper {
      box-shadow: 0 0 0 1px var(--el-color-danger) inset
    }

    .el-input.is-exceed .el-input__suffix .el-input__count {
      color: var(--el-color-danger)
    }

    .el-input--large {
      --el-input-height: var(--el-component-size-large);
      font-size: 14px
    }

    .el-input--large .el-input__wrapper {
      padding: 1px 15px
    }

    .el-input--large .el-input__inner {
      --el-input-inner-height: calc(var(--el-input-height, 40px) - 2px)
    }

    .el-input--small {
      --el-input-height: var(--el-component-size-small);
      font-size: 12px
    }

    .el-input--small .el-input__wrapper {
      padding: 1px 7px
    }

    .el-input--small .el-input__inner {
      --el-input-inner-height: calc(var(--el-input-height, 24px) - 2px)
    }

    .el-input-group {
      display: inline-flex;
      width: 100%;
      align-items: stretch
    }

    .el-input-group__append,
    .el-input-group__prepend {
      background-color: var(--el-fill-color-light);
      color: var(--el-color-info);
      position: relative;
      display: inline-flex;
      align-items: center;
      justify-content: center;
      min-height: 100%;
      border-radius: var(--el-input-border-radius);
      padding: 0 20px;
      white-space: nowrap
    }

    .el-input-group__append:focus,
    .el-input-group__prepend:focus {
      outline: 0
    }

    .el-input-group__append .el-button,
    .el-input-group__append .el-select,
    .el-input-group__prepend .el-button,
    .el-input-group__prepend .el-select {
      display: inline-block;
      margin: 0 -20px
    }

    .el-input-group__append button.el-button,
    .el-input-group__append button.el-button:hover,
    .el-input-group__append div.el-select .el-select__wrapper,
    .el-input-group__append div.el-select:hover .el-select__wrapper,
    .el-input-group__prepend button.el-button,
    .el-input-group__prepend button.el-button:hover,
    .el-input-group__prepend div.el-select .el-select__wrapper,
    .el-input-group__prepend div.el-select:hover .el-select__wrapper {
      border-color: transparent;
      background-color: transparent;
      color: inherit
    }

    .el-input-group__append .el-button,
    .el-input-group__append .el-input,
    .el-input-group__prepend .el-button,
    .el-input-group__prepend .el-input {
      font-size: inherit
    }

    .el-input-group__prepend {
      border-right: 0;
      border-top-right-radius: 0;
      border-bottom-right-radius: 0;
      box-shadow: 1px 0 0 0 var(--el-input-border-color) inset, 0 1px 0 0 var(--el-input-border-color) inset, 0 -1px 0 0 var(--el-input-border-color) inset
    }

    .el-input-group__append {
      border-left: 0;
      border-top-left-radius: 0;
      border-bottom-left-radius: 0;
      box-shadow: 0 1px 0 0 var(--el-input-border-color) inset, 0 -1px 0 0 var(--el-input-border-color) inset, -1px 0 0 0 var(--el-input-border-color) inset
    }

    .el-input-group--prepend>.el-input__wrapper {
      border-top-left-radius: 0;
      border-bottom-left-radius: 0
    }

    .el-input-group--prepend .el-input-group__prepend .el-select .el-select__wrapper {
      border-top-right-radius: 0;
      border-bottom-right-radius: 0;
      box-shadow: 1px 0 0 0 var(--el-input-border-color) inset, 0 1px 0 0 var(--el-input-border-color) inset, 0 -1px 0 0 var(--el-input-border-color) inset
    }

    .el-input-group--append>.el-input__wrapper {
      border-top-right-radius: 0;
      border-bottom-right-radius: 0
    }

    .el-input-group--append .el-input-group__append .el-select .el-select__wrapper {
      border-top-left-radius: 0;
      border-bottom-left-radius: 0;
      box-shadow: 0 1px 0 0 var(--el-input-border-color) inset, 0 -1px 0 0 var(--el-input-border-color) inset, -1px 0 0 0 var(--el-input-border-color) inset
    }

    .el-link {
      --el-link-font-size: var(--el-font-size-base);
      --el-link-font-weight: var(--el-font-weight-primary);
      --el-link-text-color: var(--el-text-color-regular);
      --el-link-hover-text-color: var(--el-color-primary);
      --el-link-disabled-text-color: var(--el-text-color-placeholder)
    }

    .el-link {
      display: inline-flex;
      flex-direction: row;
      align-items: center;
      justify-content: center;
      vertical-align: middle;
      position: relative;
      text-decoration: none;
      outline: 0;
      cursor: pointer;
      padding: 0;
      font-size: var(--el-link-font-size);
      font-weight: var(--el-link-font-weight);
      color: var(--el-link-text-color)
    }

    .el-link:hover {
      color: var(--el-link-hover-text-color)
    }

    .el-link.is-underline:hover:after {
      content: """";
      position: absolute;
      left: 0;
      right: 0;
      height: 0;
      bottom: 0;
      border-bottom: 1px solid var(--el-link-hover-text-color)
    }

    .el-link.is-disabled {
      color: var(--el-link-disabled-text-color);
      cursor: not-allowed
    }

    .el-link [class*=el-icon-]+span {
      margin-left: 5px
    }

    .el-link.el-link--default:after {
      border-color: var(--el-link-hover-text-color)
    }

    .el-link__inner {
      display: inline-flex;
      justify-content: center;
      align-items: center
    }

    .el-link.el-link--primary {
      --el-link-text-color: var(--el-color-primary);
      --el-link-hover-text-color: var(--el-color-primary-light-3);
      --el-link-disabled-text-color: var(--el-color-primary-light-5)
    }

    .el-link.el-link--primary:after {
      border-color: var(--el-link-text-color)
    }

    .el-link.el-link--primary.is-underline:hover:after {
      border-color: var(--el-link-text-color)
    }

    .el-link.el-link--success {
      --el-link-text-color: var(--el-color-success);
      --el-link-hover-text-color: var(--el-color-success-light-3);
      --el-link-disabled-text-color: var(--el-color-success-light-5)
    }

    .el-link.el-link--success:after {
      border-color: var(--el-link-text-color)
    }

    .el-link.el-link--success.is-underline:hover:after {
      border-color: var(--el-link-text-color)
    }

    .el-link.el-link--warning {
      --el-link-text-color: var(--el-color-warning);
      --el-link-hover-text-color: var(--el-color-warning-light-3);
      --el-link-disabled-text-color: var(--el-color-warning-light-5)
    }

    .el-link.el-link--warning:after {
      border-color: var(--el-link-text-color)
    }

    .el-link.el-link--warning.is-underline:hover:after {
      border-color: var(--el-link-text-color)
    }

    .el-link.el-link--danger {
      --el-link-text-color: var(--el-color-danger);
      --el-link-hover-text-color: var(--el-color-danger-light-3);
      --el-link-disabled-text-color: var(--el-color-danger-light-5)
    }

    .el-link.el-link--danger:after {
      border-color: var(--el-link-text-color)
    }

    .el-link.el-link--danger.is-underline:hover:after {
      border-color: var(--el-link-text-color)
    }

    .el-link.el-link--error {
      --el-link-text-color: var(--el-color-error);
      --el-link-hover-text-color: var(--el-color-error-light-3);
      --el-link-disabled-text-color: var(--el-color-error-light-5)
    }

    .el-link.el-link--error:after {
      border-color: var(--el-link-text-color)
    }

    .el-link.el-link--error.is-underline:hover:after {
      border-color: var(--el-link-text-color)
    }

    .el-link.el-link--info {
      --el-link-text-color: var(--el-color-info);
      --el-link-hover-text-color: var(--el-color-info-light-3);
      --el-link-disabled-text-color: var(--el-color-info-light-5)
    }

    .el-link.el-link--info:after {
      border-color: var(--el-link-text-color)
    }

    .el-link.el-link--info.is-underline:hover:after {
      border-color: var(--el-link-text-color)
    }

    :root {
      --el-loading-spinner-size: 42px;
      --el-loading-fullscreen-spinner-size: 50px
    }

    .el-loading-parent--relative {
      position: relative !important
    }

    .el-loading-parent--hidden {
      overflow: hidden !important
    }

    .el-loading-mask {
      position: absolute;
      z-index: 2000;
      background-color: var(--el-mask-color);
      margin: 0;
      top: 0;
      right: 0;
      bottom: 0;
      left: 0;
      transition: opacity var(--el-transition-duration)
    }

    .el-loading-mask.is-fullscreen {
      position: fixed
    }

    .el-loading-mask.is-fullscreen .el-loading-spinner {
      margin-top: calc((0px - var(--el-loading-fullscreen-spinner-size))/ 2)
    }

    .el-loading-mask.is-fullscreen .el-loading-spinner .circular {
      height: var(--el-loading-fullscreen-spinner-size);
      width: var(--el-loading-fullscreen-spinner-size)
    }

    .el-loading-spinner {
      top: 50%;
      margin-top: calc((0px - var(--el-loading-spinner-size))/ 2);
      width: 100%;
      text-align: center;
      position: absolute
    }

    .el-loading-spinner .el-loading-text {
      color: var(--el-color-primary);
      margin: 3px 0;
      font-size: 14px
    }

    .el-loading-spinner .circular {
      display: inline;
      height: var(--el-loading-spinner-size);
      width: var(--el-loading-spinner-size);
      -webkit-animation: loading-rotate 2s linear infinite;
      animation: loading-rotate 2s linear infinite
    }

    .el-loading-spinner .path {
      -webkit-animation: loading-dash 1.5s ease-in-out infinite;
      animation: loading-dash 1.5s ease-in-out infinite;
      stroke-dasharray: 90, 150;
      stroke-dashoffset: 0;
      stroke-width: 2;
      stroke: var(--el-color-primary);
      stroke-linecap: round
    }

    .el-loading-spinner i {
      color: var(--el-color-primary)
    }

    .el-loading-fade-enter-from,
    .el-loading-fade-leave-to {
      opacity: 0
    }

    @-webkit-keyframes loading-rotate {
      100% {
        transform: rotate(360deg)
      }
    }

    @keyframes loading-rotate {
      100% {
        transform: rotate(360deg)
      }
    }

    @-webkit-keyframes loading-dash {
      0% {
        stroke-dasharray: 1, 200;
        stroke-dashoffset: 0
      }

      50% {
        stroke-dasharray: 90, 150;
        stroke-dashoffset: -40px
      }

      100% {
        stroke-dasharray: 90, 150;
        stroke-dashoffset: -120px
      }
    }

    @keyframes loading-dash {
      0% {
        stroke-dasharray: 1, 200;
        stroke-dashoffset: 0
      }

      50% {
        stroke-dasharray: 90, 150;
        stroke-dashoffset: -40px
      }

      100% {
        stroke-dasharray: 90, 150;
        stroke-dashoffset: -120px
      }
    }

    .el-main {
      --el-main-padding: 20px;
      display: block;
      flex: 1;
      flex-basis: auto;
      overflow: auto;
      box-sizing: border-box;
      padding: var(--el-main-padding)
    }

    :root {
      --el-menu-active-color: var(--el-color-primary);
      --el-menu-text-color: var(--el-text-color-primary);
      --el-menu-hover-text-color: var(--el-color-primary);
      --el-menu-bg-color: var(--el-fill-color-blank);
      --el-menu-hover-bg-color: var(--el-color-primary-light-9);
      --el-menu-item-height: 56px;
      --el-menu-sub-item-height: calc(var(--el-menu-item-height) - 6px);
      --el-menu-horizontal-height: 60px;
      --el-menu-horizontal-sub-item-height: 36px;
      --el-menu-item-font-size: var(--el-font-size-base);
      --el-menu-item-hover-fill: var(--el-color-primary-light-9);
      --el-menu-border-color: var(--el-border-color);
      --el-menu-base-level-padding: 20px;
      --el-menu-level-padding: 20px;
      --el-menu-icon-width: 24px
    }

    .el-menu {
      border-right: solid 1px var(--el-menu-border-color);
      list-style: none;
      position: relative;
      margin: 0;
      padding-left: 0;
      background-color: var(--el-menu-bg-color);
      box-sizing: border-box
    }

    .el-menu--vertical:not(.el-menu--collapse):not(.el-menu--popup-container) .el-menu-item,
    .el-menu--vertical:not(.el-menu--collapse):not(.el-menu--popup-container) .el-menu-item-group__title,
    .el-menu--vertical:not(.el-menu--collapse):not(.el-menu--popup-container) .el-sub-menu__title {
      white-space: nowrap;
      padding-left: calc(var(--el-menu-base-level-padding) + var(--el-menu-level) * var(--el-menu-level-padding))
    }

    .el-menu:not(.el-menu--collapse) .el-sub-menu__title {
      padding-right: calc(var(--el-menu-base-level-padding) + var(--el-menu-icon-width))
    }

    .el-menu--horizontal {
      display: flex;
      flex-wrap: nowrap;
      border-right: none;
      height: var(--el-menu-horizontal-height)
    }

    .el-menu--horizontal.el-menu--popup-container {
      height: unset
    }

    .el-menu--horizontal.el-menu {
      border-bottom: solid 1px var(--el-menu-border-color)
    }

    .el-menu--horizontal>.el-menu-item {
      display: inline-flex;
      justify-content: center;
      align-items: center;
      height: 100%;
      margin: 0;
      border-bottom: 2px solid transparent;
      color: var(--el-menu-text-color)
    }

    .el-menu--horizontal>.el-menu-item a,
    .el-menu--horizontal>.el-menu-item a:hover {
      color: inherit
    }

    .el-menu--horizontal>.el-sub-menu:focus,
    .el-menu--horizontal>.el-sub-menu:hover {
      outline: 0
    }

    .el-menu--horizontal>.el-sub-menu:hover .el-sub-menu__title {
      color: var(--el-menu-hover-text-color)
    }

    .el-menu--horizontal>.el-sub-menu.is-active .el-sub-menu__title {
      border-bottom: 2px solid var(--el-menu-active-color);
      color: var(--el-menu-active-color)
    }

    .el-menu--horizontal>.el-sub-menu .el-sub-menu__title {
      height: 100%;
      border-bottom: 2px solid transparent;
      color: var(--el-menu-text-color)
    }

    .el-menu--horizontal>.el-sub-menu .el-sub-menu__title:hover {
      background-color: var(--el-menu-bg-color)
    }

    .el-menu--horizontal .el-menu .el-menu-item,
    .el-menu--horizontal .el-menu .el-sub-menu__title {
      background-color: var(--el-menu-bg-color);
      display: flex;
      align-items: center;
      height: var(--el-menu-horizontal-sub-item-height);
      line-height: var(--el-menu-horizontal-sub-item-height);
      padding: 0 10px;
      color: var(--el-menu-text-color)
    }

    .el-menu--horizontal .el-menu .el-sub-menu__title {
      padding-right: 40px
    }

    .el-menu--horizontal .el-menu .el-menu-item.is-active,
    .el-menu--horizontal .el-menu .el-sub-menu.is-active>.el-sub-menu__title {
      color: var(--el-menu-active-color)
    }

    .el-menu--horizontal .el-menu-item:not(.is-disabled):focus,
    .el-menu--horizontal .el-menu-item:not(.is-disabled):hover {
      outline: 0;
      color: var(--el-menu-hover-text-color);
      background-color: var(--el-menu-hover-bg-color)
    }

    .el-menu--horizontal>.el-menu-item.is-active {
      border-bottom: 2px solid var(--el-menu-active-color);
      color: var(--el-menu-active-color) !important
    }

    .el-menu--collapse {
      width: calc(var(--el-menu-icon-width) + var(--el-menu-base-level-padding) * 2)
    }

    .el-menu--collapse>.el-menu-item [class^=el-icon],
    .el-menu--collapse>.el-menu-item-group>ul>.el-sub-menu>.el-sub-menu__title [class^=el-icon],
    .el-menu--collapse>.el-sub-menu>.el-sub-menu__title [class^=el-icon] {
      margin: 0;
      vertical-align: middle;
      width: var(--el-menu-icon-width);
      text-align: center
    }

    .el-menu--collapse>.el-menu-item .el-sub-menu__icon-arrow,
    .el-menu--collapse>.el-menu-item-group>ul>.el-sub-menu>.el-sub-menu__title .el-sub-menu__icon-arrow,
    .el-menu--collapse>.el-sub-menu>.el-sub-menu__title .el-sub-menu__icon-arrow {
      display: none
    }

    .el-menu--collapse>.el-menu-item-group>ul>.el-sub-menu>.el-sub-menu__title>span,
    .el-menu--collapse>.el-menu-item>span,
    .el-menu--collapse>.el-sub-menu>.el-sub-menu__title>span {
      height: 0;
      width: 0;
      overflow: hidden;
      visibility: hidden;
      display: inline-block
    }

    .el-menu--collapse>.el-menu-item.is-active i {
      color: inherit
    }

    .el-menu--collapse .el-menu .el-sub-menu {
      min-width: 200px
    }

    .el-menu--collapse .el-sub-menu.is-active .el-sub-menu__title {
      color: var(--el-menu-active-color)
    }

    .el-menu--popup {
      z-index: 100;
      min-width: 200px;
      border: none;
      padding: 5px 0;
      border-radius: var(--el-border-radius-small);
      box-shadow: var(--el-box-shadow-light)
    }

    .el-menu .el-icon {
      flex-shrink: 0
    }

    .el-menu-item {
      display: flex;
      align-items: center;
      height: var(--el-menu-item-height);
      line-height: var(--el-menu-item-height);
      font-size: var(--el-menu-item-font-size);
      color: var(--el-menu-text-color);
      padding: 0 var(--el-menu-base-level-padding);
      list-style: none;
      cursor: pointer;
      position: relative;
      transition: border-color var(--el-transition-duration), background-color var(--el-transition-duration), color var(--el-transition-duration);
      box-sizing: border-box;
      white-space: nowrap
    }

    .el-menu-item * {
      vertical-align: bottom
    }

    .el-menu-item i {
      color: inherit
    }

    .el-menu-item:focus,
    .el-menu-item:hover {
      outline: 0
    }

    .el-menu-item:hover {
      background-color: var(--el-menu-hover-bg-color)
    }

    .el-menu-item.is-disabled {
      opacity: .25;
      cursor: not-allowed;
      background: 0 0 !important
    }

    .el-menu-item [class^=el-icon] {
      margin-right: 5px;
      width: var(--el-menu-icon-width);
      text-align: center;
      font-size: 18px;
      vertical-align: middle
    }

    .el-menu-item.is-active {
      color: var(--el-menu-active-color)
    }

    .el-menu-item.is-active i {
      color: inherit
    }

    .el-menu-item .el-menu-tooltip__trigger {
      position: absolute;
      left: 0;
      top: 0;
      height: 100%;
      width: 100%;
      display: inline-flex;
      align-items: center;
      box-sizing: border-box;
      padding: 0 var(--el-menu-base-level-padding)
    }

    .el-sub-menu {
      list-style: none;
      margin: 0;
      padding-left: 0
    }

    .el-sub-menu__title {
      display: flex;
      align-items: center;
      height: var(--el-menu-item-height);
      line-height: var(--el-menu-item-height);
      font-size: var(--el-menu-item-font-size);
      color: var(--el-menu-text-color);
      padding: 0 var(--el-menu-base-level-padding);
      list-style: none;
      cursor: pointer;
      position: relative;
      transition: border-color var(--el-transition-duration), background-color var(--el-transition-duration), color var(--el-transition-duration);
      box-sizing: border-box;
      white-space: nowrap
    }

    .el-sub-menu__title * {
      vertical-align: bottom
    }

    .el-sub-menu__title i {
      color: inherit
    }

    .el-sub-menu__title:focus,
    .el-sub-menu__title:hover {
      outline: 0
    }

    .el-sub-menu__title:hover {
      background-color: var(--el-menu-hover-bg-color)
    }

    .el-sub-menu__title.is-disabled {
      opacity: .25;
      cursor: not-allowed;
      background: 0 0 !important
    }

    .el-sub-menu__title:hover {
      background-color: var(--el-menu-hover-bg-color)
    }

    .el-sub-menu .el-menu {
      border: none
    }

    .el-sub-menu .el-menu-item {
      height: var(--el-menu-sub-item-height);
      line-height: var(--el-menu-sub-item-height)
    }

    .el-sub-menu__hide-arrow .el-sub-menu__icon-arrow {
      display: none !important
    }

    .el-sub-menu.is-active .el-sub-menu__title {
      border-bottom-color: var(--el-menu-active-color)
    }

    .el-sub-menu.is-disabled .el-menu-item,
    .el-sub-menu.is-disabled .el-sub-menu__title {
      opacity: .25;
      cursor: not-allowed;
      background: 0 0 !important
    }

    .el-sub-menu .el-icon {
      vertical-align: middle;
      margin-right: 5px;
      width: var(--el-menu-icon-width);
      text-align: center;
      font-size: 18px
    }

    .el-sub-menu .el-icon.el-sub-menu__icon-more {
      margin-right: 0 !important
    }

    .el-sub-menu .el-sub-menu__icon-arrow {
      position: absolute;
      top: 50%;
      right: var(--el-menu-base-level-padding);
      margin-top: -6px;
      transition: transform var(--el-transition-duration);
      font-size: 12px;
      margin-right: 0;
      width: inherit
    }

    .el-menu-item-group>ul {
      padding: 0
    }

    .el-menu-item-group__title {
      padding: 7px 0 7px var(--el-menu-base-level-padding);
      line-height: normal;
      font-size: 12px;
      color: var(--el-text-color-secondary)
    }

    .horizontal-collapse-transition .el-sub-menu__title .el-sub-menu__icon-arrow {
      transition: var(--el-transition-duration-fast);
      opacity: 0
    }

    .el-message-box {
      --el-messagebox-title-color: var(--el-text-color-primary);
      --el-messagebox-width: 420px;
      --el-messagebox-border-radius: 4px;
      --el-messagebox-box-shadow: var(--el-box-shadow);
      --el-messagebox-font-size: var(--el-font-size-large);
      --el-messagebox-content-font-size: var(--el-font-size-base);
      --el-messagebox-content-color: var(--el-text-color-regular);
      --el-messagebox-error-font-size: 12px;
      --el-messagebox-padding-primary: 12px;
      --el-messagebox-font-line-height: var(--el-font-line-height-primary)
    }

    .el-message-box {
      display: inline-block;
      position: relative;
      max-width: var(--el-messagebox-width);
      width: 100%;
      padding: var(--el-messagebox-padding-primary);
      vertical-align: middle;
      background-color: var(--el-bg-color);
      border-radius: var(--el-messagebox-border-radius);
      font-size: var(--el-messagebox-font-size);
      box-shadow: var(--el-messagebox-box-shadow);
      text-align: left;
      overflow: hidden;
      -webkit-backface-visibility: hidden;
      backface-visibility: hidden;
      box-sizing: border-box;
      overflow-wrap: break-word
    }

    .el-message-box:focus {
      outline: 0 !important
    }

    .el-overlay.is-message-box .el-overlay-message-box {
      text-align: center;
      position: fixed;
      top: 0;
      right: 0;
      bottom: 0;
      left: 0;
      padding: 16px;
      overflow: auto
    }

    .el-overlay.is-message-box .el-overlay-message-box::after {
      content: """";
      display: inline-block;
      height: 100%;
      width: 0;
      vertical-align: middle
    }

    .el-message-box.is-draggable .el-message-box__header {
      cursor: move;
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none
    }

    .el-message-box__header {
      padding-bottom: var(--el-messagebox-padding-primary)
    }

    .el-message-box__header.show-close {
      padding-right: calc(var(--el-messagebox-padding-primary) + var(--el-message-close-size, 16px))
    }

    .el-message-box__title {
      font-size: var(--el-messagebox-font-size);
      line-height: var(--el-messagebox-font-line-height);
      color: var(--el-messagebox-title-color)
    }

    .el-message-box__headerbtn {
      position: absolute;
      top: 0;
      right: 0;
      padding: 0;
      width: 40px;
      height: 40px;
      border: none;
      outline: 0;
      background: 0 0;
      font-size: var(--el-message-close-size, 16px);
      cursor: pointer
    }

    .el-message-box__headerbtn .el-message-box__close {
      color: var(--el-color-info);
      font-size: inherit
    }

    .el-message-box__headerbtn:focus .el-message-box__close,
    .el-message-box__headerbtn:hover .el-message-box__close {
      color: var(--el-color-primary)
    }

    .el-message-box__content {
      color: var(--el-messagebox-content-color);
      font-size: var(--el-messagebox-content-font-size)
    }

    .el-message-box__container {
      display: flex;
      align-items: center;
      gap: 12px
    }

    .el-message-box__input {
      padding-top: 12px
    }

    .el-message-box__input div.invalid>input {
      border-color: var(--el-color-error)
    }

    .el-message-box__input div.invalid>input:focus {
      border-color: var(--el-color-error)
    }

    .el-message-box__status {
      font-size: 24px
    }

    .el-message-box__status.el-message-box-icon--success {
      --el-messagebox-color: var(--el-color-success);
      color: var(--el-messagebox-color)
    }

    .el-message-box__status.el-message-box-icon--info {
      --el-messagebox-color: var(--el-color-info);
      color: var(--el-messagebox-color)
    }

    .el-message-box__status.el-message-box-icon--warning {
      --el-messagebox-color: var(--el-color-warning);
      color: var(--el-messagebox-color)
    }

    .el-message-box__status.el-message-box-icon--error {
      --el-messagebox-color: var(--el-color-error);
      color: var(--el-messagebox-color)
    }

    .el-message-box__message {
      margin: 0
    }

    .el-message-box__message p {
      margin: 0;
      line-height: var(--el-messagebox-font-line-height)
    }

    .el-message-box__errormsg {
      color: var(--el-color-error);
      font-size: var(--el-messagebox-error-font-size);
      line-height: var(--el-messagebox-font-line-height)
    }

    .el-message-box__btns {
      display: flex;
      flex-wrap: wrap;
      justify-content: flex-end;
      align-items: center;
      padding-top: var(--el-messagebox-padding-primary)
    }

    .el-message-box--center .el-message-box__title {
      display: flex;
      align-items: center;
      justify-content: center;
      gap: 6px
    }

    .el-message-box--center .el-message-box__status {
      font-size: inherit
    }

    .el-message-box--center .el-message-box__btns {
      justify-content: center
    }

    .el-message-box--center .el-message-box__container {
      justify-content: center
    }

    .fade-in-linear-enter-active .el-overlay-message-box {
      -webkit-animation: msgbox-fade-in var(--el-transition-duration);
      animation: msgbox-fade-in var(--el-transition-duration)
    }

    .fade-in-linear-leave-active .el-overlay-message-box {
      animation: msgbox-fade-in var(--el-transition-duration) reverse
    }

    @-webkit-keyframes msgbox-fade-in {
      0% {
        transform: translate3d(0, -20px, 0);
        opacity: 0
      }

      100% {
        transform: translate3d(0, 0, 0);
        opacity: 1
      }
    }

    @keyframes msgbox-fade-in {
      0% {
        transform: translate3d(0, -20px, 0);
        opacity: 0
      }

      100% {
        transform: translate3d(0, 0, 0);
        opacity: 1
      }
    }

    .el-message {
      --el-message-bg-color: var(--el-color-info-light-9);
      --el-message-border-color: var(--el-border-color-lighter);
      --el-message-padding: 15px 19px;
      --el-message-close-size: 16px;
      --el-message-close-icon-color: var(--el-text-color-placeholder);
      --el-message-close-hover-color: var(--el-text-color-secondary)
    }

    .el-message {
      width: -webkit-fit-content;
      width: -moz-fit-content;
      width: fit-content;
      max-width: calc(100% - 32px);
      box-sizing: border-box;
      border-radius: var(--el-border-radius-base);
      border-width: var(--el-border-width);
      border-style: var(--el-border-style);
      border-color: var(--el-message-border-color);
      position: fixed;
      left: 50%;
      top: 20px;
      transform: translateX(-50%);
      background-color: var(--el-message-bg-color);
      transition: opacity var(--el-transition-duration), transform .4s, top .4s;
      padding: var(--el-message-padding);
      display: flex;
      align-items: center
    }

    .el-message.is-center {
      justify-content: center
    }

    .el-message.is-closable .el-message__content {
      padding-right: 31px
    }

    .el-message p {
      margin: 0
    }

    .el-message--success {
      --el-message-bg-color: var(--el-color-success-light-9);
      --el-message-border-color: var(--el-color-success-light-8);
      --el-message-text-color: var(--el-color-success)
    }

    .el-message--success .el-message__content {
      color: var(--el-message-text-color);
      overflow-wrap: break-word
    }

    .el-message .el-message-icon--success {
      color: var(--el-message-text-color)
    }

    .el-message--info {
      --el-message-bg-color: var(--el-color-info-light-9);
      --el-message-border-color: var(--el-color-info-light-8);
      --el-message-text-color: var(--el-color-info)
    }

    .el-message--info .el-message__content {
      color: var(--el-message-text-color);
      overflow-wrap: break-word
    }

    .el-message .el-message-icon--info {
      color: var(--el-message-text-color)
    }

    .el-message--warning {
      --el-message-bg-color: var(--el-color-warning-light-9);
      --el-message-border-color: var(--el-color-warning-light-8);
      --el-message-text-color: var(--el-color-warning)
    }

    .el-message--warning .el-message__content {
      color: var(--el-message-text-color);
      overflow-wrap: break-word
    }

    .el-message .el-message-icon--warning {
      color: var(--el-message-text-color)
    }

    .el-message--error {
      --el-message-bg-color: var(--el-color-error-light-9);
      --el-message-border-color: var(--el-color-error-light-8);
      --el-message-text-color: var(--el-color-error)
    }

    .el-message--error .el-message__content {
      color: var(--el-message-text-color);
      overflow-wrap: break-word
    }

    .el-message .el-message-icon--error {
      color: var(--el-message-text-color)
    }

    .el-message__icon {
      margin-right: 10px
    }

    .el-message .el-message__badge {
      position: absolute;
      top: -8px;
      right: -8px
    }

    .el-message__content {
      padding: 0;
      font-size: 14px;
      line-height: 1
    }

    .el-message__content:focus {
      outline-width: 0
    }

    .el-message .el-message__closeBtn {
      position: absolute;
      top: 50%;
      right: 19px;
      transform: translateY(-50%);
      cursor: pointer;
      color: var(--el-message-close-icon-color);
      font-size: var(--el-message-close-size)
    }

    .el-message .el-message__closeBtn:focus {
      outline-width: 0
    }

    .el-message .el-message__closeBtn:hover {
      color: var(--el-message-close-hover-color)
    }

    .el-message-fade-enter-from,
    .el-message-fade-leave-to {
      opacity: 0;
      transform: translate(-50%, -100%)
    }

    .el-notification {
      --el-notification-width: 330px;
      --el-notification-padding: 14px 26px 14px 13px;
      --el-notification-radius: 8px;
      --el-notification-shadow: var(--el-box-shadow-light);
      --el-notification-border-color: var(--el-border-color-lighter);
      --el-notification-icon-size: 24px;
      --el-notification-close-font-size: var(--el-message-close-size, 16px);
      --el-notification-group-margin-left: 13px;
      --el-notification-group-margin-right: 8px;
      --el-notification-content-font-size: var(--el-font-size-base);
      --el-notification-content-color: var(--el-text-color-regular);
      --el-notification-title-font-size: 16px;
      --el-notification-title-color: var(--el-text-color-primary);
      --el-notification-close-color: var(--el-text-color-secondary);
      --el-notification-close-hover-color: var(--el-text-color-regular)
    }

    .el-notification {
      display: flex;
      width: var(--el-notification-width);
      padding: var(--el-notification-padding);
      border-radius: var(--el-notification-radius);
      box-sizing: border-box;
      border: 1px solid var(--el-notification-border-color);
      position: fixed;
      background-color: var(--el-bg-color-overlay);
      box-shadow: var(--el-notification-shadow);
      transition: opacity var(--el-transition-duration), transform var(--el-transition-duration), left var(--el-transition-duration), right var(--el-transition-duration), top .4s, bottom var(--el-transition-duration);
      overflow-wrap: break-word;
      overflow: hidden;
      z-index: 9999
    }

    .el-notification.right {
      right: 16px
    }

    .el-notification.left {
      left: 16px
    }

    .el-notification__group {
      margin-left: var(--el-notification-group-margin-left);
      margin-right: var(--el-notification-group-margin-right)
    }

    .el-notification__title {
      font-weight: 700;
      font-size: var(--el-notification-title-font-size);
      line-height: var(--el-notification-icon-size);
      color: var(--el-notification-title-color);
      margin: 0
    }

    .el-notification__content {
      font-size: var(--el-notification-content-font-size);
      line-height: 24px;
      margin: 6px 0 0;
      color: var(--el-notification-content-color)
    }

    .el-notification__content p {
      margin: 0
    }

    .el-notification .el-notification__icon {
      height: var(--el-notification-icon-size);
      width: var(--el-notification-icon-size);
      font-size: var(--el-notification-icon-size)
    }

    .el-notification .el-notification__closeBtn {
      position: absolute;
      top: 18px;
      right: 15px;
      cursor: pointer;
      color: var(--el-notification-close-color);
      font-size: var(--el-notification-close-font-size)
    }

    .el-notification .el-notification__closeBtn:hover {
      color: var(--el-notification-close-hover-color)
    }

    .el-notification .el-notification--success {
      --el-notification-icon-color: var(--el-color-success);
      color: var(--el-notification-icon-color)
    }

    .el-notification .el-notification--info {
      --el-notification-icon-color: var(--el-color-info);
      color: var(--el-notification-icon-color)
    }

    .el-notification .el-notification--warning {
      --el-notification-icon-color: var(--el-color-warning);
      color: var(--el-notification-icon-color)
    }

    .el-notification .el-notification--error {
      --el-notification-icon-color: var(--el-color-error);
      color: var(--el-notification-icon-color)
    }

    .el-notification-fade-enter-from.right {
      right: 0;
      transform: translateX(100%)
    }

    .el-notification-fade-enter-from.left {
      left: 0;
      transform: translateX(-100%)
    }

    .el-notification-fade-leave-to {
      opacity: 0
    }

    .el-overlay {
      position: fixed;
      top: 0;
      right: 0;
      bottom: 0;
      left: 0;
      z-index: 2000;
      height: 100%;
      background-color: var(--el-overlay-color-lighter);
      overflow: auto
    }

    .el-overlay .el-overlay-root {
      height: 0
    }

    .el-page-header.is-contentful .el-page-header__main {
      border-top: 1px solid var(--el-border-color-light);
      margin-top: 16px
    }

    .el-page-header__header {
      display: flex;
      align-items: center;
      justify-content: space-between;
      line-height: 24px
    }

    .el-page-header__left {
      display: flex;
      align-items: center;
      margin-right: 40px;
      position: relative
    }

    .el-page-header__back {
      display: flex;
      align-items: center;
      cursor: pointer
    }

    .el-page-header__left .el-divider--vertical {
      margin: 0 16px
    }

    .el-page-header__icon {
      font-size: 16px;
      margin-right: 10px;
      display: flex;
      align-items: center
    }

    .el-page-header__icon .el-icon {
      font-size: inherit
    }

    .el-page-header__title {
      font-size: 14px;
      font-weight: 500
    }

    .el-page-header__content {
      font-size: 18px;
      color: var(--el-text-color-primary)
    }

    .el-page-header__breadcrumb {
      margin-bottom: 16px
    }

    .el-pagination {
      --el-pagination-font-size: 14px;
      --el-pagination-bg-color: var(--el-fill-color-blank);
      --el-pagination-text-color: var(--el-text-color-primary);
      --el-pagination-border-radius: 2px;
      --el-pagination-button-color: var(--el-text-color-primary);
      --el-pagination-button-width: 32px;
      --el-pagination-button-height: 32px;
      --el-pagination-button-disabled-color: var(--el-text-color-placeholder);
      --el-pagination-button-disabled-bg-color: var(--el-fill-color-blank);
      --el-pagination-button-bg-color: var(--el-fill-color);
      --el-pagination-hover-color: var(--el-color-primary);
      --el-pagination-font-size-small: 12px;
      --el-pagination-button-width-small: 24px;
      --el-pagination-button-height-small: 24px;
      --el-pagination-item-gap: 16px;
      white-space: nowrap;
      color: var(--el-pagination-text-color);
      font-size: var(--el-pagination-font-size);
      font-weight: 400;
      display: flex;
      align-items: center
    }

    .el-pagination .el-input__inner {
      text-align: center;
      -moz-appearance: textfield
    }

    .el-pagination .el-select {
      width: 128px
    }

    .el-pagination button {
      display: flex;
      justify-content: center;
      align-items: center;
      font-size: var(--el-pagination-font-size);
      min-width: var(--el-pagination-button-width);
      height: var(--el-pagination-button-height);
      line-height: var(--el-pagination-button-height);
      color: var(--el-pagination-button-color);
      background: var(--el-pagination-bg-color);
      padding: 0 4px;
      border: none;
      border-radius: var(--el-pagination-border-radius);
      cursor: pointer;
      text-align: center;
      box-sizing: border-box
    }

    .el-pagination button * {
      pointer-events: none
    }

    .el-pagination button:focus {
      outline: 0
    }

    .el-pagination button:hover {
      color: var(--el-pagination-hover-color)
    }

    .el-pagination button.is-active {
      color: var(--el-pagination-hover-color);
      cursor: default;
      font-weight: 700
    }

    .el-pagination button.is-active.is-disabled {
      font-weight: 700;
      color: var(--el-text-color-secondary)
    }

    .el-pagination button.is-disabled,
    .el-pagination button:disabled {
      color: var(--el-pagination-button-disabled-color);
      background-color: var(--el-pagination-button-disabled-bg-color);
      cursor: not-allowed
    }

    .el-pagination button:focus-visible {
      outline: 1px solid var(--el-pagination-hover-color);
      outline-offset: -1px
    }

    .el-pagination .btn-next .el-icon,
    .el-pagination .btn-prev .el-icon {
      display: block;
      font-size: 12px;
      font-weight: 700;
      width: inherit
    }

    .el-pagination>.is-first {
      margin-left: 0 !important
    }

    .el-pagination>.is-last {
      margin-right: 0 !important
    }

    .el-pagination .btn-prev {
      margin-left: var(--el-pagination-item-gap)
    }

    .el-pagination__sizes {
      margin-left: var(--el-pagination-item-gap);
      font-weight: 400;
      color: var(--el-text-color-regular)
    }

    .el-pagination__total {
      margin-left: var(--el-pagination-item-gap);
      font-weight: 400;
      color: var(--el-text-color-regular)
    }

    .el-pagination__total[disabled=true] {
      color: var(--el-text-color-placeholder)
    }

    .el-pagination__jump {
      display: flex;
      align-items: center;
      margin-left: var(--el-pagination-item-gap);
      font-weight: 400;
      color: var(--el-text-color-regular)
    }

    .el-pagination__jump[disabled=true] {
      color: var(--el-text-color-placeholder)
    }

    .el-pagination__goto {
      margin-right: 8px
    }

    .el-pagination__editor {
      text-align: center;
      box-sizing: border-box
    }

    .el-pagination__editor.el-input {
      width: 56px
    }

    .el-pagination__editor .el-input__inner::-webkit-inner-spin-button,
    .el-pagination__editor .el-input__inner::-webkit-outer-spin-button {
      -webkit-appearance: none;
      margin: 0
    }

    .el-pagination__classifier {
      margin-left: 8px
    }

    .el-pagination__rightwrapper {
      flex: 1;
      display: flex;
      align-items: center;
      justify-content: flex-end
    }

    .el-pagination.is-background .btn-next,
    .el-pagination.is-background .btn-prev,
    .el-pagination.is-background .el-pager li {
      margin: 0 4px;
      background-color: var(--el-pagination-button-bg-color)
    }

    .el-pagination.is-background .btn-next.is-active,
    .el-pagination.is-background .btn-prev.is-active,
    .el-pagination.is-background .el-pager li.is-active {
      background-color: var(--el-color-primary);
      color: var(--el-color-white)
    }

    .el-pagination.is-background .btn-next.is-disabled,
    .el-pagination.is-background .btn-next:disabled,
    .el-pagination.is-background .btn-prev.is-disabled,
    .el-pagination.is-background .btn-prev:disabled,
    .el-pagination.is-background .el-pager li.is-disabled,
    .el-pagination.is-background .el-pager li:disabled {
      color: var(--el-text-color-placeholder);
      background-color: var(--el-disabled-bg-color)
    }

    .el-pagination.is-background .btn-next.is-disabled.is-active,
    .el-pagination.is-background .btn-next:disabled.is-active,
    .el-pagination.is-background .btn-prev.is-disabled.is-active,
    .el-pagination.is-background .btn-prev:disabled.is-active,
    .el-pagination.is-background .el-pager li.is-disabled.is-active,
    .el-pagination.is-background .el-pager li:disabled.is-active {
      color: var(--el-text-color-secondary);
      background-color: var(--el-fill-color-dark)
    }

    .el-pagination.is-background .btn-prev {
      margin-left: var(--el-pagination-item-gap)
    }

    .el-pagination--small .btn-next,
    .el-pagination--small .btn-prev,
    .el-pagination--small .el-pager li {
      height: var(--el-pagination-button-height-small);
      line-height: var(--el-pagination-button-height-small);
      font-size: var(--el-pagination-font-size-small);
      min-width: var(--el-pagination-button-width-small)
    }

    .el-pagination--small button,
    .el-pagination--small span:not([class*=suffix]) {
      font-size: var(--el-pagination-font-size-small)
    }

    .el-pagination--small .el-select {
      width: 100px
    }

    .el-pager {
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      list-style: none;
      font-size: 0;
      padding: 0;
      margin: 0;
      display: flex;
      align-items: center
    }

    .el-pager li {
      display: flex;
      justify-content: center;
      align-items: center;
      font-size: var(--el-pagination-font-size);
      min-width: var(--el-pagination-button-width);
      height: var(--el-pagination-button-height);
      line-height: var(--el-pagination-button-height);
      color: var(--el-pagination-button-color);
      background: var(--el-pagination-bg-color);
      padding: 0 4px;
      border: none;
      border-radius: var(--el-pagination-border-radius);
      cursor: pointer;
      text-align: center;
      box-sizing: border-box
    }

    .el-pager li * {
      pointer-events: none
    }

    .el-pager li:focus {
      outline: 0
    }

    .el-pager li:hover {
      color: var(--el-pagination-hover-color)
    }

    .el-pager li.is-active {
      color: var(--el-pagination-hover-color);
      cursor: default;
      font-weight: 700
    }

    .el-pager li.is-active.is-disabled {
      font-weight: 700;
      color: var(--el-text-color-secondary)
    }

    .el-pager li.is-disabled,
    .el-pager li:disabled {
      color: var(--el-pagination-button-disabled-color);
      background-color: var(--el-pagination-button-disabled-bg-color);
      cursor: not-allowed
    }

    .el-pager li:focus-visible {
      outline: 1px solid var(--el-pagination-hover-color);
      outline-offset: -1px
    }

    .el-popconfirm__main {
      display: flex;
      align-items: center
    }

    .el-popconfirm__icon {
      margin-right: 5px
    }

    .el-popconfirm__action {
      text-align: right;
      margin-top: 8px
    }

    .el-popover {
      --el-popover-bg-color: var(--el-bg-color-overlay);
      --el-popover-font-size: var(--el-font-size-base);
      --el-popover-border-color: var(--el-border-color-lighter);
      --el-popover-padding: 12px;
      --el-popover-padding-large: 18px 20px;
      --el-popover-title-font-size: 16px;
      --el-popover-title-text-color: var(--el-text-color-primary);
      --el-popover-border-radius: 4px
    }

    .el-popover.el-popper {
      background: var(--el-popover-bg-color);
      min-width: 150px;
      border-radius: var(--el-popover-border-radius);
      border: 1px solid var(--el-popover-border-color);
      padding: var(--el-popover-padding);
      z-index: var(--el-index-popper);
      color: var(--el-text-color-regular);
      line-height: 1.4;
      font-size: var(--el-popover-font-size);
      box-shadow: var(--el-box-shadow-light);
      overflow-wrap: break-word;
      box-sizing: border-box
    }

    .el-popover.el-popper--plain {
      padding: var(--el-popover-padding-large)
    }

    .el-popover__title {
      color: var(--el-popover-title-text-color);
      font-size: var(--el-popover-title-font-size);
      line-height: 1;
      margin-bottom: 12px
    }

    .el-popover__reference:focus:hover,
    .el-popover__reference:focus:not(.focusing) {
      outline-width: 0
    }

    .el-popover.el-popper.is-dark {
      --el-popover-bg-color: var(--el-text-color-primary);
      --el-popover-border-color: var(--el-text-color-primary);
      --el-popover-title-text-color: var(--el-bg-color);
      color: var(--el-bg-color)
    }

    .el-popover.el-popper:focus,
    .el-popover.el-popper:focus:active {
      outline-width: 0
    }

    .el-progress {
      position: relative;
      line-height: 1;
      display: flex;
      align-items: center
    }

    .el-progress__text {
      font-size: 14px;
      color: var(--el-text-color-regular);
      margin-left: 5px;
      min-width: 50px;
      line-height: 1
    }

    .el-progress__text i {
      vertical-align: middle;
      display: block
    }

    .el-progress--circle,
    .el-progress--dashboard {
      display: inline-block
    }

    .el-progress--circle .el-progress__text,
    .el-progress--dashboard .el-progress__text {
      position: absolute;
      top: 50%;
      left: 0;
      width: 100%;
      text-align: center;
      margin: 0;
      transform: translate(0, -50%)
    }

    .el-progress--circle .el-progress__text i,
    .el-progress--dashboard .el-progress__text i {
      vertical-align: middle;
      display: inline-block
    }

    .el-progress--without-text .el-progress__text {
      display: none
    }

    .el-progress--without-text .el-progress-bar {
      padding-right: 0;
      margin-right: 0;
      display: block
    }

    .el-progress--text-inside .el-progress-bar {
      padding-right: 0;
      margin-right: 0
    }

    .el-progress.is-success .el-progress-bar__inner {
      background-color: var(--el-color-success)
    }

    .el-progress.is-success .el-progress__text {
      color: var(--el-color-success)
    }

    .el-progress.is-warning .el-progress-bar__inner {
      background-color: var(--el-color-warning)
    }

    .el-progress.is-warning .el-progress__text {
      color: var(--el-color-warning)
    }

    .el-progress.is-exception .el-progress-bar__inner {
      background-color: var(--el-color-danger)
    }

    .el-progress.is-exception .el-progress__text {
      color: var(--el-color-danger)
    }

    .el-progress-bar {
      flex-grow: 1;
      box-sizing: border-box
    }

    .el-progress-bar__outer {
      height: 6px;
      border-radius: 100px;
      background-color: var(--el-border-color-lighter);
      overflow: hidden;
      position: relative;
      vertical-align: middle
    }

    .el-progress-bar__inner {
      position: absolute;
      left: 0;
      top: 0;
      height: 100%;
      background-color: var(--el-color-primary);
      text-align: right;
      border-radius: 100px;
      line-height: 1;
      white-space: nowrap;
      transition: width .6s ease
    }

    .el-progress-bar__inner::after {
      display: inline-block;
      content: """";
      height: 100%;
      vertical-align: middle
    }

    .el-progress-bar__inner--indeterminate {
      transform: translateZ(0);
      -webkit-animation: indeterminate 3s infinite;
      animation: indeterminate 3s infinite
    }

    .el-progress-bar__inner--striped {
      background-image: linear-gradient(45deg, rgba(0, 0, 0, .1) 25%, transparent 25%, transparent 50%, rgba(0, 0, 0, .1) 50%, rgba(0, 0, 0, .1) 75%, transparent 75%, transparent);
      background-size: 1.25em 1.25em
    }

    .el-progress-bar__inner--striped.el-progress-bar__inner--striped-flow {
      -webkit-animation: striped-flow 3s linear infinite;
      animation: striped-flow 3s linear infinite
    }

    .el-progress-bar__innerText {
      display: inline-block;
      vertical-align: middle;
      color: #fff;
      font-size: 12px;
      margin: 0 5px
    }

    @-webkit-keyframes progress {
      0% {
        background-position: 0 0
      }

      100% {
        background-position: 32px 0
      }
    }

    @keyframes progress {
      0% {
        background-position: 0 0
      }

      100% {
        background-position: 32px 0
      }
    }

    @-webkit-keyframes indeterminate {
      0% {
        left: -100%
      }

      100% {
        left: 100%
      }
    }

    @keyframes indeterminate {
      0% {
        left: -100%
      }

      100% {
        left: 100%
      }
    }

    @-webkit-keyframes striped-flow {
      0% {
        background-position: -100%
      }

      100% {
        background-position: 100%
      }
    }

    @keyframes striped-flow {
      0% {
        background-position: -100%
      }

      100% {
        background-position: 100%
      }
    }

    .el-radio-button {
      --el-radio-button-checked-bg-color: var(--el-color-primary);
      --el-radio-button-checked-text-color: var(--el-color-white);
      --el-radio-button-checked-border-color: var(--el-color-primary);
      --el-radio-button-disabled-checked-fill: var(--el-border-color-extra-light)
    }

    .el-radio-button {
      position: relative;
      display: inline-block;
      outline: 0
    }

    .el-radio-button__inner {
      display: inline-block;
      line-height: 1;
      white-space: nowrap;
      vertical-align: middle;
      background: var(--el-button-bg-color, var(--el-fill-color-blank));
      border: var(--el-border);
      font-weight: var(--el-button-font-weight, var(--el-font-weight-primary));
      border-left: 0;
      color: var(--el-button-text-color, var(--el-text-color-regular));
      -webkit-appearance: none;
      text-align: center;
      box-sizing: border-box;
      outline: 0;
      margin: 0;
      position: relative;
      cursor: pointer;
      transition: var(--el-transition-all);
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      padding: 8px 15px;
      font-size: var(--el-font-size-base);
      border-radius: 0
    }

    .el-radio-button__inner.is-round {
      padding: 8px 15px
    }

    .el-radio-button__inner:hover {
      color: var(--el-color-primary)
    }

    .el-radio-button__inner [class*=el-icon-] {
      line-height: .9
    }

    .el-radio-button__inner [class*=el-icon-]+span {
      margin-left: 5px
    }

    .el-radio-button:first-child .el-radio-button__inner {
      border-left: var(--el-border);
      border-radius: var(--el-border-radius-base) 0 0 var(--el-border-radius-base);
      box-shadow: none !important
    }

    .el-radio-button__original-radio {
      opacity: 0;
      outline: 0;
      position: absolute;
      z-index: -1
    }

    .el-radio-button__original-radio:checked+.el-radio-button__inner {
      color: var(--el-radio-button-checked-text-color, var(--el-color-white));
      background-color: var(--el-radio-button-checked-bg-color, var(--el-color-primary));
      border-color: var(--el-radio-button-checked-border-color, var(--el-color-primary));
      box-shadow: -1px 0 0 0 var(--el-radio-button-checked-border-color, var(--el-color-primary))
    }

    .el-radio-button__original-radio:focus-visible+.el-radio-button__inner {
      border-left: var(--el-border);
      border-left-color: var(--el-radio-button-checked-border-color, var(--el-color-primary));
      outline: 2px solid var(--el-radio-button-checked-border-color);
      outline-offset: 1px;
      z-index: 2;
      border-radius: var(--el-border-radius-base);
      box-shadow: none
    }

    .el-radio-button__original-radio:disabled+.el-radio-button__inner {
      color: var(--el-disabled-text-color);
      cursor: not-allowed;
      background-image: none;
      background-color: var(--el-button-disabled-bg-color, var(--el-fill-color-blank));
      border-color: var(--el-button-disabled-border-color, var(--el-border-color-light));
      box-shadow: none
    }

    .el-radio-button__original-radio:disabled:checked+.el-radio-button__inner {
      background-color: var(--el-radio-button-disabled-checked-fill)
    }

    .el-radio-button:last-child .el-radio-button__inner {
      border-radius: 0 var(--el-border-radius-base) var(--el-border-radius-base) 0
    }

    .el-radio-button:first-child:last-child .el-radio-button__inner {
      border-radius: var(--el-border-radius-base)
    }

    .el-radio-button--large .el-radio-button__inner {
      padding: 12px 19px;
      font-size: var(--el-font-size-base);
      border-radius: 0
    }

    .el-radio-button--large .el-radio-button__inner.is-round {
      padding: 12px 19px
    }

    .el-radio-button--small .el-radio-button__inner {
      padding: 5px 11px;
      font-size: 12px;
      border-radius: 0
    }

    .el-radio-button--small .el-radio-button__inner.is-round {
      padding: 5px 11px
    }

    .el-radio-group {
      display: inline-flex;
      align-items: center;
      flex-wrap: wrap;
      font-size: 0
    }

    .el-radio {
      --el-radio-font-size: var(--el-font-size-base);
      --el-radio-text-color: var(--el-text-color-regular);
      --el-radio-font-weight: var(--el-font-weight-primary);
      --el-radio-input-height: 14px;
      --el-radio-input-width: 14px;
      --el-radio-input-border-radius: var(--el-border-radius-circle);
      --el-radio-input-bg-color: var(--el-fill-color-blank);
      --el-radio-input-border: var(--el-border);
      --el-radio-input-border-color: var(--el-border-color);
      --el-radio-input-border-color-hover: var(--el-color-primary)
    }

    .el-radio {
      color: var(--el-radio-text-color);
      font-weight: var(--el-radio-font-weight);
      position: relative;
      cursor: pointer;
      display: inline-flex;
      align-items: center;
      white-space: nowrap;
      outline: 0;
      font-size: var(--el-font-size-base);
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      margin-right: 32px;
      height: 32px
    }

    .el-radio.el-radio--large {
      height: 40px
    }

    .el-radio.el-radio--small {
      height: 24px
    }

    .el-radio.is-bordered {
      padding: 0 15px 0 9px;
      border-radius: var(--el-border-radius-base);
      border: var(--el-border);
      box-sizing: border-box
    }

    .el-radio.is-bordered.is-checked {
      border-color: var(--el-color-primary)
    }

    .el-radio.is-bordered.is-disabled {
      cursor: not-allowed;
      border-color: var(--el-border-color-lighter)
    }

    .el-radio.is-bordered.el-radio--large {
      padding: 0 19px 0 11px;
      border-radius: var(--el-border-radius-base)
    }

    .el-radio.is-bordered.el-radio--large .el-radio__label {
      font-size: var(--el-font-size-base)
    }

    .el-radio.is-bordered.el-radio--large .el-radio__inner {
      height: 14px;
      width: 14px
    }

    .el-radio.is-bordered.el-radio--small {
      padding: 0 11px 0 7px;
      border-radius: var(--el-border-radius-base)
    }

    .el-radio.is-bordered.el-radio--small .el-radio__label {
      font-size: 12px
    }

    .el-radio.is-bordered.el-radio--small .el-radio__inner {
      height: 12px;
      width: 12px
    }

    .el-radio:last-child {
      margin-right: 0
    }

    .el-radio__input {
      white-space: nowrap;
      cursor: pointer;
      outline: 0;
      display: inline-flex;
      position: relative;
      vertical-align: middle
    }

    .el-radio__input.is-disabled .el-radio__inner {
      background-color: var(--el-disabled-bg-color);
      border-color: var(--el-disabled-border-color);
      cursor: not-allowed
    }

    .el-radio__input.is-disabled .el-radio__inner::after {
      cursor: not-allowed;
      background-color: var(--el-disabled-bg-color)
    }

    .el-radio__input.is-disabled .el-radio__inner+.el-radio__label {
      cursor: not-allowed
    }

    .el-radio__input.is-disabled.is-checked .el-radio__inner {
      background-color: var(--el-disabled-bg-color);
      border-color: var(--el-disabled-border-color)
    }

    .el-radio__input.is-disabled.is-checked .el-radio__inner::after {
      background-color: var(--el-text-color-placeholder)
    }

    .el-radio__input.is-disabled+span.el-radio__label {
      color: var(--el-text-color-placeholder);
      cursor: not-allowed
    }

    .el-radio__input.is-checked .el-radio__inner {
      border-color: var(--el-color-primary);
      background: var(--el-color-primary)
    }

    .el-radio__input.is-checked .el-radio__inner::after {
      transform: translate(-50%, -50%) scale(1)
    }

    .el-radio__input.is-checked+.el-radio__label {
      color: var(--el-color-primary)
    }

    .el-radio__input.is-focus .el-radio__inner {
      border-color: var(--el-radio-input-border-color-hover)
    }

    .el-radio__inner {
      border: var(--el-radio-input-border);
      border-radius: var(--el-radio-input-border-radius);
      width: var(--el-radio-input-width);
      height: var(--el-radio-input-height);
      background-color: var(--el-radio-input-bg-color);
      position: relative;
      cursor: pointer;
      display: inline-block;
      box-sizing: border-box
    }

    .el-radio__inner:hover {
      border-color: var(--el-radio-input-border-color-hover)
    }

    .el-radio__inner::after {
      width: 4px;
      height: 4px;
      border-radius: var(--el-radio-input-border-radius);
      background-color: var(--el-color-white);
      content: """";
      position: absolute;
      left: 50%;
      top: 50%;
      transform: translate(-50%, -50%) scale(0);
      transition: transform .15s ease-in
    }

    .el-radio__original {
      opacity: 0;
      outline: 0;
      position: absolute;
      z-index: -1;
      top: 0;
      left: 0;
      right: 0;
      bottom: 0;
      margin: 0
    }

    .el-radio__original:focus-visible+.el-radio__inner {
      outline: 2px solid var(--el-radio-input-border-color-hover);
      outline-offset: 1px;
      border-radius: var(--el-radio-input-border-radius)
    }

    .el-radio:focus:not(:focus-visible):not(.is-focus):not(:active):not(.is-disabled) .el-radio__inner {
      box-shadow: 0 0 2px 2px var(--el-radio-input-border-color-hover)
    }

    .el-radio__label {
      font-size: var(--el-radio-font-size);
      padding-left: 8px
    }

    .el-radio.el-radio--large .el-radio__label {
      font-size: 14px
    }

    .el-radio.el-radio--large .el-radio__inner {
      width: 14px;
      height: 14px
    }

    .el-radio.el-radio--small .el-radio__label {
      font-size: 12px
    }

    .el-radio.el-radio--small .el-radio__inner {
      width: 12px;
      height: 12px
    }

    .el-rate {
      --el-rate-height: 20px;
      --el-rate-font-size: var(--el-font-size-base);
      --el-rate-icon-size: 18px;
      --el-rate-icon-margin: 6px;
      --el-rate-void-color: var(--el-border-color-darker);
      --el-rate-fill-color: #f7ba2a;
      --el-rate-disabled-void-color: var(--el-fill-color);
      --el-rate-text-color: var(--el-text-color-primary)
    }

    .el-rate {
      display: inline-flex;
      align-items: center;
      height: 32px
    }

    .el-rate:active,
    .el-rate:focus {
      outline: 0
    }

    .el-rate__item {
      cursor: pointer;
      display: inline-block;
      position: relative;
      font-size: 0;
      vertical-align: middle;
      color: var(--el-rate-void-color);
      line-height: normal
    }

    .el-rate .el-rate__icon {
      position: relative;
      display: inline-block;
      font-size: var(--el-rate-icon-size);
      margin-right: var(--el-rate-icon-margin);
      transition: var(--el-transition-duration)
    }

    .el-rate .el-rate__icon.hover {
      transform: scale(1.15)
    }

    .el-rate .el-rate__icon .path2 {
      position: absolute;
      left: 0;
      top: 0
    }

    .el-rate .el-rate__icon.is-active {
      color: var(--el-rate-fill-color)
    }

    .el-rate__decimal {
      position: absolute;
      top: 0;
      left: 0;
      display: inline-block;
      overflow: hidden;
      color: var(--el-rate-fill-color)
    }

    .el-rate__decimal--box {
      position: absolute;
      top: 0;
      left: 0
    }

    .el-rate__text {
      font-size: var(--el-rate-font-size);
      vertical-align: middle;
      color: var(--el-rate-text-color)
    }

    .el-rate--large {
      height: 40px
    }

    .el-rate--small {
      height: 24px
    }

    .el-rate--small .el-rate__icon {
      font-size: 14px
    }

    .el-rate.is-disabled .el-rate__item {
      cursor: auto;
      color: var(--el-rate-disabled-void-color)
    }

    .el-result {
      --el-result-padding: 40px 30px;
      --el-result-icon-font-size: 64px;
      --el-result-title-font-size: 20px;
      --el-result-title-margin-top: 20px;
      --el-result-subtitle-margin-top: 10px;
      --el-result-extra-margin-top: 30px
    }

    .el-result {
      display: flex;
      justify-content: center;
      align-items: center;
      flex-direction: column;
      text-align: center;
      box-sizing: border-box;
      padding: var(--el-result-padding)
    }

    .el-result__icon svg {
      width: var(--el-result-icon-font-size);
      height: var(--el-result-icon-font-size)
    }

    .el-result__title {
      margin-top: var(--el-result-title-margin-top)
    }

    .el-result__title p {
      margin: 0;
      font-size: var(--el-result-title-font-size);
      color: var(--el-text-color-primary);
      line-height: 1.3
    }

    .el-result__subtitle {
      margin-top: var(--el-result-subtitle-margin-top)
    }

    .el-result__subtitle p {
      margin: 0;
      font-size: var(--el-font-size-base);
      color: var(--el-text-color-regular);
      line-height: 1.3
    }

    .el-result__extra {
      margin-top: var(--el-result-extra-margin-top)
    }

    .el-result .icon-primary {
      --el-result-color: var(--el-color-primary);
      color: var(--el-result-color)
    }

    .el-result .icon-success {
      --el-result-color: var(--el-color-success);
      color: var(--el-result-color)
    }

    .el-result .icon-warning {
      --el-result-color: var(--el-color-warning);
      color: var(--el-result-color)
    }

    .el-result .icon-danger {
      --el-result-color: var(--el-color-danger);
      color: var(--el-result-color)
    }

    .el-result .icon-error {
      --el-result-color: var(--el-color-error);
      color: var(--el-result-color)
    }

    .el-result .icon-info {
      --el-result-color: var(--el-color-info);
      color: var(--el-result-color)
    }

    .el-row {
      display: flex;
      flex-wrap: wrap;
      position: relative;
      box-sizing: border-box
    }

    .el-row.is-justify-center {
      justify-content: center
    }

    .el-row.is-justify-end {
      justify-content: flex-end
    }

    .el-row.is-justify-space-between {
      justify-content: space-between
    }

    .el-row.is-justify-space-around {
      justify-content: space-around
    }

    .el-row.is-justify-space-evenly {
      justify-content: space-evenly
    }

    .el-row.is-align-top {
      align-items: flex-start
    }

    .el-row.is-align-middle {
      align-items: center
    }

    .el-row.is-align-bottom {
      align-items: flex-end
    }

    .el-scrollbar {
      --el-scrollbar-opacity: 0.3;
      --el-scrollbar-bg-color: var(--el-text-color-secondary);
      --el-scrollbar-hover-opacity: 0.5;
      --el-scrollbar-hover-bg-color: var(--el-text-color-secondary)
    }

    .el-scrollbar {
      overflow: hidden;
      position: relative;
      height: 100%
    }

    .el-scrollbar__wrap {
      overflow: auto;
      height: 100%
    }

    .el-scrollbar__wrap--hidden-default {
      scrollbar-width: none
    }

    .el-scrollbar__wrap--hidden-default::-webkit-scrollbar {
      display: none
    }

    .el-scrollbar__thumb {
      position: relative;
      display: block;
      width: 0;
      height: 0;
      cursor: pointer;
      border-radius: inherit;
      background-color: var(--el-scrollbar-bg-color, var(--el-text-color-secondary));
      transition: var(--el-transition-duration) background-color;
      opacity: var(--el-scrollbar-opacity, .3)
    }

    .el-scrollbar__thumb:hover {
      background-color: var(--el-scrollbar-hover-bg-color, var(--el-text-color-secondary));
      opacity: var(--el-scrollbar-hover-opacity, .5)
    }

    .el-scrollbar__bar {
      position: absolute;
      right: 2px;
      bottom: 2px;
      z-index: 1;
      border-radius: 4px
    }

    .el-scrollbar__bar.is-vertical {
      width: 6px;
      top: 2px
    }

    .el-scrollbar__bar.is-vertical>div {
      width: 100%
    }

    .el-scrollbar__bar.is-horizontal {
      height: 6px;
      left: 2px
    }

    .el-scrollbar__bar.is-horizontal>div {
      height: 100%
    }

    .el-scrollbar-fade-enter-active {
      transition: opacity 340ms ease-out
    }

    .el-scrollbar-fade-leave-active {
      transition: opacity 120ms ease-out
    }

    .el-scrollbar-fade-enter-from,
    .el-scrollbar-fade-leave-active {
      opacity: 0
    }

    .el-select-dropdown {
      z-index: calc(var(--el-index-top) + 1);
      border-radius: var(--el-border-radius-base);
      box-sizing: border-box
    }

    .el-select-dropdown .el-scrollbar.is-empty .el-select-dropdown__list {
      padding: 0
    }

    .el-select-dropdown__loading {
      padding: 10px 0;
      margin: 0;
      text-align: center;
      color: var(--el-text-color-secondary);
      font-size: var(--el-select-font-size)
    }

    .el-select-dropdown__empty {
      padding: 10px 0;
      margin: 0;
      text-align: center;
      color: var(--el-text-color-secondary);
      font-size: var(--el-select-font-size)
    }

    .el-select-dropdown__wrap {
      max-height: 274px
    }

    .el-select-dropdown__list {
      list-style: none;
      padding: 6px 0;
      margin: 0;
      box-sizing: border-box
    }

    .el-select-dropdown__list.el-vl__window {
      margin: 6px 0;
      padding: 0
    }

    .el-select-dropdown__header {
      padding: 10px;
      border-bottom: 1px solid var(--el-border-color-light)
    }

    .el-select-dropdown__footer {
      padding: 10px;
      border-top: 1px solid var(--el-border-color-light)
    }

    .el-select-dropdown__item {
      font-size: var(--el-font-size-base);
      padding: 0 32px 0 20px;
      position: relative;
      white-space: nowrap;
      overflow: hidden;
      text-overflow: ellipsis;
      color: var(--el-text-color-regular);
      height: 34px;
      line-height: 34px;
      box-sizing: border-box;
      cursor: pointer
    }

    .el-select-dropdown__item.is-hovering {
      background-color: var(--el-fill-color-light)
    }

    .el-select-dropdown__item.is-selected {
      color: var(--el-color-primary);
      font-weight: 700
    }

    .el-select-dropdown__item.is-disabled {
      color: var(--el-text-color-placeholder);
      cursor: not-allowed;
      background-color: unset
    }

    .el-select-dropdown.is-multiple .el-select-dropdown__item.is-selected::after {
      content: """";
      position: absolute;
      top: 50%;
      right: 20px;
      border-top: none;
      border-right: none;
      background-repeat: no-repeat;
      background-position: center;
      background-color: var(--el-color-primary);
      -webkit-mask: url(""data:image/svg+xml;utf8,%3Csvg class='icon' width='200' height='200' viewBox='0 0 1024 1024' xmlns='http://www.w3.org/2000/svg'%3E%3Cpath fill='currentColor' d='M406.656 706.944L195.84 496.256a32 32 0 10-45.248 45.248l256 256 512-512a32 32 0 00-45.248-45.248L406.592 706.944z'%3E%3C/path%3E%3C/svg%3E"") no-repeat;
      mask: url(""data:image/svg+xml;utf8,%3Csvg class='icon' width='200' height='200' viewBox='0 0 1024 1024' xmlns='http://www.w3.org/2000/svg'%3E%3Cpath fill='currentColor' d='M406.656 706.944L195.84 496.256a32 32 0 10-45.248 45.248l256 256 512-512a32 32 0 00-45.248-45.248L406.592 706.944z'%3E%3C/path%3E%3C/svg%3E"") no-repeat;
      mask-size: 100% 100%;
      -webkit-mask: url(""data:image/svg+xml;utf8,%3Csvg class='icon' width='200' height='200' viewBox='0 0 1024 1024' xmlns='http://www.w3.org/2000/svg'%3E%3Cpath fill='currentColor' d='M406.656 706.944L195.84 496.256a32 32 0 10-45.248 45.248l256 256 512-512a32 32 0 00-45.248-45.248L406.592 706.944z'%3E%3C/path%3E%3C/svg%3E"") no-repeat;
      -webkit-mask-size: 100% 100%;
      transform: translateY(-50%);
      width: 12px;
      height: 12px
    }

    .el-select-dropdown.is-multiple .el-select-dropdown__item.is-disabled::after {
      background-color: var(--el-text-color-placeholder)
    }

    .el-select-group {
      margin: 0;
      padding: 0
    }

    .el-select-group__wrap {
      position: relative;
      list-style: none;
      margin: 0;
      padding: 0
    }

    .el-select-group__wrap:not(:last-of-type) {
      padding-bottom: 24px
    }

    .el-select-group__wrap:not(:last-of-type)::after {
      content: """";
      position: absolute;
      display: block;
      left: 20px;
      right: 20px;
      bottom: 12px;
      height: 1px;
      background: var(--el-border-color-light)
    }

    .el-select-group__split-dash {
      position: absolute;
      left: 20px;
      right: 20px;
      height: 1px;
      background: var(--el-border-color-light)
    }

    .el-select-group__title {
      padding-left: 20px;
      font-size: 12px;
      color: var(--el-color-info);
      line-height: 30px
    }

    .el-select-group .el-select-dropdown__item {
      padding-left: 20px
    }

    .el-select {
      --el-select-border-color-hover: var(--el-border-color-hover);
      --el-select-disabled-border: var(--el-disabled-border-color);
      --el-select-font-size: var(--el-font-size-base);
      --el-select-close-hover-color: var(--el-text-color-secondary);
      --el-select-input-color: var(--el-text-color-placeholder);
      --el-select-multiple-input-color: var(--el-text-color-regular);
      --el-select-input-focus-border-color: var(--el-color-primary);
      --el-select-input-font-size: 14px;
      --el-select-width: 100%
    }

    .el-select {
      display: inline-block;
      position: relative;
      vertical-align: middle;
      width: var(--el-select-width)
    }

    .el-select__wrapper {
      display: flex;
      align-items: center;
      position: relative;
      box-sizing: border-box;
      cursor: pointer;
      text-align: left;
      font-size: 14px;
      padding: 4px 12px;
      gap: 6px;
      min-height: 32px;
      line-height: 24px;
      border-radius: var(--el-border-radius-base);
      background-color: var(--el-fill-color-blank);
      transition: var(--el-transition-duration);
      box-shadow: 0 0 0 1px var(--el-border-color) inset
    }

    .el-select__wrapper:hover {
      box-shadow: 0 0 0 1px var(--el-text-color) inset
    }

    .el-select__wrapper.is-filterable {
      cursor: text
    }

    .el-select__wrapper.is-focused {
      box-shadow: 0 0 0 1px var(--el-color-primary) inset
    }

    .el-select__wrapper.is-hovering:not(.is-focused) {
      box-shadow: 0 0 0 1px var(--el-border-color-hover) inset
    }

    .el-select__wrapper.is-disabled {
      cursor: not-allowed;
      background-color: var(--el-fill-color-light);
      color: var(--el-text-color-placeholder);
      box-shadow: 0 0 0 1px var(--el-select-disabled-border) inset
    }

    .el-select__wrapper.is-disabled:hover {
      box-shadow: 0 0 0 1px var(--el-select-disabled-border) inset
    }

    .el-select__wrapper.is-disabled.is-focus {
      box-shadow: 0 0 0 1px var(--el-input-focus-border-color) inset
    }

    .el-select__wrapper.is-disabled .el-select__caret {
      cursor: not-allowed
    }

    .el-select__wrapper.is-disabled .el-tag {
      cursor: not-allowed
    }

    .el-select__prefix {
      display: flex;
      align-items: center;
      flex-shrink: 0;
      gap: 6px;
      color: var(--el-input-icon-color, var(--el-text-color-placeholder))
    }

    .el-select__suffix {
      display: flex;
      align-items: center;
      flex-shrink: 0;
      gap: 6px;
      color: var(--el-input-icon-color, var(--el-text-color-placeholder))
    }

    .el-select__caret {
      color: var(--el-select-input-color);
      font-size: var(--el-select-input-font-size);
      transition: var(--el-transition-duration);
      transform: rotateZ(0);
      cursor: pointer
    }

    .el-select__caret.is-reverse {
      transform: rotateZ(180deg)
    }

    .el-select__selection {
      position: relative;
      display: flex;
      flex-wrap: wrap;
      align-items: center;
      flex: 1;
      min-width: 0;
      gap: 6px
    }

    .el-select__selection.is-near {
      margin-left: -8px
    }

    .el-select__selection .el-tag {
      cursor: pointer;
      border-color: transparent
    }

    .el-select__selection .el-tag .el-tag__content {
      min-width: 0
    }

    .el-select__selected-item {
      display: flex;
      flex-wrap: wrap;
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none
    }

    .el-select__tags-text {
      display: block;
      line-height: normal;
      overflow: hidden;
      text-overflow: ellipsis;
      white-space: nowrap
    }

    .el-select__placeholder {
      position: absolute;
      display: block;
      top: 50%;
      transform: translateY(-50%);
      width: 100%;
      overflow: hidden;
      text-overflow: ellipsis;
      white-space: nowrap;
      color: var(--el-input-text-color, var(--el-text-color-regular))
    }

    .el-select__placeholder.is-transparent {
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      color: var(--el-text-color-placeholder)
    }

    .el-select__popper.el-popper {
      background: var(--el-bg-color-overlay);
      border: 1px solid var(--el-border-color-light);
      box-shadow: var(--el-box-shadow-light)
    }

    .el-select__popper.el-popper .el-popper__arrow::before {
      border: 1px solid var(--el-border-color-light)
    }

    .el-select__popper.el-popper[data-popper-placement^=top] .el-popper__arrow::before {
      border-top-color: transparent;
      border-left-color: transparent
    }

    .el-select__popper.el-popper[data-popper-placement^=bottom] .el-popper__arrow::before {
      border-bottom-color: transparent;
      border-right-color: transparent
    }

    .el-select__popper.el-popper[data-popper-placement^=left] .el-popper__arrow::before {
      border-left-color: transparent;
      border-bottom-color: transparent
    }

    .el-select__popper.el-popper[data-popper-placement^=right] .el-popper__arrow::before {
      border-right-color: transparent;
      border-top-color: transparent
    }

    .el-select__input-wrapper {
      max-width: 100%
    }

    .el-select__input-wrapper.is-hidden {
      position: absolute;
      opacity: 0
    }

    .el-select__input {
      border: none;
      outline: 0;
      padding: 0;
      color: var(--el-select-multiple-input-color);
      font-size: inherit;
      font-family: inherit;
      -webkit-appearance: none;
      -moz-appearance: none;
      appearance: none;
      height: 24px;
      max-width: 100%;
      background-color: transparent
    }

    .el-select__input.is-disabled {
      cursor: not-allowed
    }

    .el-select__input-calculator {
      position: absolute;
      left: 0;
      top: 0;
      max-width: 100%;
      visibility: hidden;
      white-space: pre;
      overflow: hidden
    }

    .el-select--large .el-select__wrapper {
      gap: 6px;
      padding: 8px 16px;
      min-height: 40px;
      line-height: 24px;
      font-size: 14px
    }

    .el-select--large .el-select__selection {
      gap: 6px
    }

    .el-select--large .el-select__selection.is-near {
      margin-left: -8px
    }

    .el-select--large .el-select__prefix {
      gap: 6px
    }

    .el-select--large .el-select__suffix {
      gap: 6px
    }

    .el-select--large .el-select__input {
      height: 24px
    }

    .el-select--small .el-select__wrapper {
      gap: 4px;
      padding: 2px 8px;
      min-height: 24px;
      line-height: 20px;
      font-size: 12px
    }

    .el-select--small .el-select__selection {
      gap: 4px
    }

    .el-select--small .el-select__selection.is-near {
      margin-left: -6px
    }

    .el-select--small .el-select__prefix {
      gap: 4px
    }

    .el-select--small .el-select__suffix {
      gap: 4px
    }

    .el-select--small .el-select__input {
      height: 20px
    }

    .el-skeleton {
      --el-skeleton-circle-size: var(--el-avatar-size)
    }

    .el-skeleton__item {
      background: var(--el-skeleton-color);
      display: inline-block;
      height: 16px;
      border-radius: var(--el-border-radius-base);
      width: 100%
    }

    .el-skeleton__circle {
      border-radius: 50%;
      width: var(--el-skeleton-circle-size);
      height: var(--el-skeleton-circle-size);
      line-height: var(--el-skeleton-circle-size)
    }

    .el-skeleton__button {
      height: 40px;
      width: 64px;
      border-radius: 4px
    }

    .el-skeleton__p {
      width: 100%
    }

    .el-skeleton__p.is-last {
      width: 61%
    }

    .el-skeleton__p.is-first {
      width: 33%
    }

    .el-skeleton__text {
      width: 100%;
      height: var(--el-font-size-small)
    }

    .el-skeleton__caption {
      height: var(--el-font-size-extra-small)
    }

    .el-skeleton__h1 {
      height: var(--el-font-size-extra-large)
    }

    .el-skeleton__h3 {
      height: var(--el-font-size-large)
    }

    .el-skeleton__h5 {
      height: var(--el-font-size-medium)
    }

    .el-skeleton__image {
      width: unset;
      display: flex;
      align-items: center;
      justify-content: center;
      border-radius: 0
    }

    .el-skeleton__image svg {
      color: var(--el-svg-monochrome-grey);
      fill: currentColor;
      width: 22%;
      height: 22%
    }

    .el-skeleton {
      --el-skeleton-color: var(--el-fill-color);
      --el-skeleton-to-color: var(--el-fill-color-darker)
    }

    @-webkit-keyframes el-skeleton-loading {
      0% {
        background-position: 100% 50%
      }

      100% {
        background-position: 0 50%
      }
    }

    @keyframes el-skeleton-loading {
      0% {
        background-position: 100% 50%
      }

      100% {
        background-position: 0 50%
      }
    }

    .el-skeleton {
      width: 100%
    }

    .el-skeleton__first-line {
      height: 16px;
      margin-top: 16px;
      background: var(--el-skeleton-color)
    }

    .el-skeleton__paragraph {
      height: 16px;
      margin-top: 16px;
      background: var(--el-skeleton-color)
    }

    .el-skeleton.is-animated .el-skeleton__item {
      background: linear-gradient(90deg, var(--el-skeleton-color) 25%, var(--el-skeleton-to-color) 37%, var(--el-skeleton-color) 63%);
      background-size: 400% 100%;
      -webkit-animation: el-skeleton-loading 1.4s ease infinite;
      animation: el-skeleton-loading 1.4s ease infinite
    }

    .el-slider {
      --el-slider-main-bg-color: var(--el-color-primary);
      --el-slider-runway-bg-color: var(--el-border-color-light);
      --el-slider-stop-bg-color: var(--el-color-white);
      --el-slider-disabled-color: var(--el-text-color-placeholder);
      --el-slider-border-radius: 3px;
      --el-slider-height: 6px;
      --el-slider-button-size: 20px;
      --el-slider-button-wrapper-size: 36px;
      --el-slider-button-wrapper-offset: -15px
    }

    .el-slider {
      width: 100%;
      height: 32px;
      display: flex;
      align-items: center
    }

    .el-slider__runway {
      flex: 1;
      height: var(--el-slider-height);
      background-color: var(--el-slider-runway-bg-color);
      border-radius: var(--el-slider-border-radius);
      position: relative;
      cursor: pointer
    }

    .el-slider__runway.show-input {
      margin-right: 30px;
      width: auto
    }

    .el-slider__runway.is-disabled {
      cursor: default
    }

    .el-slider__runway.is-disabled .el-slider__bar {
      background-color: var(--el-slider-disabled-color)
    }

    .el-slider__runway.is-disabled .el-slider__button {
      border-color: var(--el-slider-disabled-color)
    }

    .el-slider__runway.is-disabled .el-slider__button-wrapper.hover,
    .el-slider__runway.is-disabled .el-slider__button-wrapper:hover {
      cursor: not-allowed
    }

    .el-slider__runway.is-disabled .el-slider__button-wrapper.dragging {
      cursor: not-allowed
    }

    .el-slider__runway.is-disabled .el-slider__button.dragging,
    .el-slider__runway.is-disabled .el-slider__button.hover,
    .el-slider__runway.is-disabled .el-slider__button:hover {
      transform: scale(1)
    }

    .el-slider__runway.is-disabled .el-slider__button.hover,
    .el-slider__runway.is-disabled .el-slider__button:hover {
      cursor: not-allowed
    }

    .el-slider__runway.is-disabled .el-slider__button.dragging {
      cursor: not-allowed
    }

    .el-slider__input {
      flex-shrink: 0;
      width: 130px
    }

    .el-slider__bar {
      height: var(--el-slider-height);
      background-color: var(--el-slider-main-bg-color);
      border-top-left-radius: var(--el-slider-border-radius);
      border-bottom-left-radius: var(--el-slider-border-radius);
      position: absolute
    }

    .el-slider__button-wrapper {
      height: var(--el-slider-button-wrapper-size);
      width: var(--el-slider-button-wrapper-size);
      position: absolute;
      z-index: 1;
      top: var(--el-slider-button-wrapper-offset);
      transform: translateX(-50%);
      background-color: transparent;
      text-align: center;
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      line-height: normal;
      outline: 0
    }

    .el-slider__button-wrapper::after {
      display: inline-block;
      content: """";
      height: 100%;
      vertical-align: middle
    }

    .el-slider__button-wrapper.hover,
    .el-slider__button-wrapper:hover {
      cursor: -webkit-grab;
      cursor: grab
    }

    .el-slider__button-wrapper.dragging {
      cursor: -webkit-grabbing;
      cursor: grabbing
    }

    .el-slider__button {
      display: inline-block;
      width: var(--el-slider-button-size);
      height: var(--el-slider-button-size);
      vertical-align: middle;
      border: solid 2px var(--el-slider-main-bg-color);
      background-color: var(--el-color-white);
      border-radius: 50%;
      box-sizing: border-box;
      transition: var(--el-transition-duration-fast);
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none
    }

    .el-slider__button.dragging,
    .el-slider__button.hover,
    .el-slider__button:hover {
      transform: scale(1.2)
    }

    .el-slider__button.hover,
    .el-slider__button:hover {
      cursor: -webkit-grab;
      cursor: grab
    }

    .el-slider__button.dragging {
      cursor: -webkit-grabbing;
      cursor: grabbing
    }

    .el-slider__stop {
      position: absolute;
      height: var(--el-slider-height);
      width: var(--el-slider-height);
      border-radius: var(--el-border-radius-circle);
      background-color: var(--el-slider-stop-bg-color);
      transform: translateX(-50%)
    }

    .el-slider__marks {
      top: 0;
      left: 12px;
      width: 18px;
      height: 100%
    }

    .el-slider__marks-text {
      position: absolute;
      transform: translateX(-50%);
      font-size: 14px;
      color: var(--el-color-info);
      margin-top: 15px;
      white-space: pre
    }

    .el-slider.is-vertical {
      position: relative;
      display: inline-flex;
      width: auto;
      height: 100%;
      flex: 0
    }

    .el-slider.is-vertical .el-slider__runway {
      width: var(--el-slider-height);
      height: 100%;
      margin: 0 16px
    }

    .el-slider.is-vertical .el-slider__bar {
      width: var(--el-slider-height);
      height: auto;
      border-radius: 0 0 3px 3px
    }

    .el-slider.is-vertical .el-slider__button-wrapper {
      top: auto;
      left: var(--el-slider-button-wrapper-offset);
      transform: translateY(50%)
    }

    .el-slider.is-vertical .el-slider__stop {
      transform: translateY(50%)
    }

    .el-slider.is-vertical .el-slider__marks-text {
      margin-top: 0;
      left: 15px;
      transform: translateY(50%)
    }

    .el-slider--large {
      height: 40px
    }

    .el-slider--small {
      height: 24px
    }

    .el-space {
      display: inline-flex;
      vertical-align: top
    }

    .el-space__item {
      display: flex;
      flex-wrap: wrap
    }

    .el-space__item>* {
      flex: 1
    }

    .el-space--vertical {
      flex-direction: column
    }

    .el-time-spinner {
      width: 100%;
      white-space: nowrap
    }

    .el-spinner {
      display: inline-block;
      vertical-align: middle
    }

    .el-spinner-inner {
      -webkit-animation: rotate 2s linear infinite;
      animation: rotate 2s linear infinite;
      width: 50px;
      height: 50px
    }

    .el-spinner-inner .path {
      stroke: var(--el-border-color-lighter);
      stroke-linecap: round;
      -webkit-animation: dash 1.5s ease-in-out infinite;
      animation: dash 1.5s ease-in-out infinite
    }

    @-webkit-keyframes rotate {
      100% {
        transform: rotate(360deg)
      }
    }

    @keyframes rotate {
      100% {
        transform: rotate(360deg)
      }
    }

    @-webkit-keyframes dash {
      0% {
        stroke-dasharray: 1, 150;
        stroke-dashoffset: 0
      }

      50% {
        stroke-dasharray: 90, 150;
        stroke-dashoffset: -35
      }

      100% {
        stroke-dasharray: 90, 150;
        stroke-dashoffset: -124
      }
    }

    @keyframes dash {
      0% {
        stroke-dasharray: 1, 150;
        stroke-dashoffset: 0
      }

      50% {
        stroke-dasharray: 90, 150;
        stroke-dashoffset: -35
      }

      100% {
        stroke-dasharray: 90, 150;
        stroke-dashoffset: -124
      }
    }

    .el-step {
      position: relative;
      flex-shrink: 1
    }

    .el-step:last-of-type .el-step__line {
      display: none
    }

    .el-step:last-of-type.is-flex {
      flex-basis: auto !important;
      flex-shrink: 0;
      flex-grow: 0
    }

    .el-step:last-of-type .el-step__description,
    .el-step:last-of-type .el-step__main {
      padding-right: 0
    }

    .el-step__head {
      position: relative;
      width: 100%
    }

    .el-step__head.is-process {
      color: var(--el-text-color-primary);
      border-color: var(--el-text-color-primary)
    }

    .el-step__head.is-wait {
      color: var(--el-text-color-placeholder);
      border-color: var(--el-text-color-placeholder)
    }

    .el-step__head.is-success {
      color: var(--el-color-success);
      border-color: var(--el-color-success)
    }

    .el-step__head.is-error {
      color: var(--el-color-danger);
      border-color: var(--el-color-danger)
    }

    .el-step__head.is-finish {
      color: var(--el-color-primary);
      border-color: var(--el-color-primary)
    }

    .el-step__icon {
      position: relative;
      z-index: 1;
      display: inline-flex;
      justify-content: center;
      align-items: center;
      width: 24px;
      height: 24px;
      font-size: 14px;
      box-sizing: border-box;
      background: var(--el-bg-color);
      transition: .15s ease-out
    }

    .el-step__icon.is-text {
      border-radius: 50%;
      border: 2px solid;
      border-color: inherit
    }

    .el-step__icon.is-icon {
      width: 40px
    }

    .el-step__icon-inner {
      display: inline-block;
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      text-align: center;
      font-weight: 700;
      line-height: 1;
      color: inherit
    }

    .el-step__icon-inner[class*=el-icon]:not(.is-status) {
      font-size: 25px;
      font-weight: 400
    }

    .el-step__icon-inner.is-status {
      transform: translateY(1px)
    }

    .el-step__line {
      position: absolute;
      border-color: inherit;
      background-color: var(--el-text-color-placeholder)
    }

    .el-step__line-inner {
      display: block;
      border-width: 1px;
      border-style: solid;
      border-color: inherit;
      transition: .15s ease-out;
      box-sizing: border-box;
      width: 0;
      height: 0
    }

    .el-step__main {
      white-space: normal;
      text-align: left
    }

    .el-step__title {
      font-size: 16px;
      line-height: 38px
    }

    .el-step__title.is-process {
      font-weight: 700;
      color: var(--el-text-color-primary)
    }

    .el-step__title.is-wait {
      color: var(--el-text-color-placeholder)
    }

    .el-step__title.is-success {
      color: var(--el-color-success)
    }

    .el-step__title.is-error {
      color: var(--el-color-danger)
    }

    .el-step__title.is-finish {
      color: var(--el-color-primary)
    }

    .el-step__description {
      padding-right: 10%;
      margin-top: -5px;
      font-size: 12px;
      line-height: 20px;
      font-weight: 400
    }

    .el-step__description.is-process {
      color: var(--el-text-color-primary)
    }

    .el-step__description.is-wait {
      color: var(--el-text-color-placeholder)
    }

    .el-step__description.is-success {
      color: var(--el-color-success)
    }

    .el-step__description.is-error {
      color: var(--el-color-danger)
    }

    .el-step__description.is-finish {
      color: var(--el-color-primary)
    }

    .el-step.is-horizontal {
      display: inline-block
    }

    .el-step.is-horizontal .el-step__line {
      height: 2px;
      top: 11px;
      left: 0;
      right: 0
    }

    .el-step.is-vertical {
      display: flex
    }

    .el-step.is-vertical .el-step__head {
      flex-grow: 0;
      width: 24px
    }

    .el-step.is-vertical .el-step__main {
      padding-left: 10px;
      flex-grow: 1
    }

    .el-step.is-vertical .el-step__title {
      line-height: 24px;
      padding-bottom: 8px
    }

    .el-step.is-vertical .el-step__line {
      width: 2px;
      top: 0;
      bottom: 0;
      left: 11px
    }

    .el-step.is-vertical .el-step__icon.is-icon {
      width: 24px
    }

    .el-step.is-center .el-step__head {
      text-align: center
    }

    .el-step.is-center .el-step__main {
      text-align: center
    }

    .el-step.is-center .el-step__description {
      padding-left: 20%;
      padding-right: 20%
    }

    .el-step.is-center .el-step__line {
      left: 50%;
      right: -50%
    }

    .el-step.is-simple {
      display: flex;
      align-items: center
    }

    .el-step.is-simple .el-step__head {
      width: auto;
      font-size: 0;
      padding-right: 10px
    }

    .el-step.is-simple .el-step__icon {
      background: 0 0;
      width: 16px;
      height: 16px;
      font-size: 12px
    }

    .el-step.is-simple .el-step__icon-inner[class*=el-icon]:not(.is-status) {
      font-size: 18px
    }

    .el-step.is-simple .el-step__icon-inner.is-status {
      transform: scale(.8) translateY(1px)
    }

    .el-step.is-simple .el-step__main {
      position: relative;
      display: flex;
      align-items: stretch;
      flex-grow: 1
    }

    .el-step.is-simple .el-step__title {
      font-size: 16px;
      line-height: 20px
    }

    .el-step.is-simple:not(:last-of-type) .el-step__title {
      max-width: 50%;
      overflow-wrap: break-word
    }

    .el-step.is-simple .el-step__arrow {
      flex-grow: 1;
      display: flex;
      align-items: center;
      justify-content: center
    }

    .el-step.is-simple .el-step__arrow::after,
    .el-step.is-simple .el-step__arrow::before {
      content: """";
      display: inline-block;
      position: absolute;
      height: 15px;
      width: 1px;
      background: var(--el-text-color-placeholder)
    }

    .el-step.is-simple .el-step__arrow::before {
      transform: rotate(-45deg) translateY(-4px);
      transform-origin: 0 0
    }

    .el-step.is-simple .el-step__arrow::after {
      transform: rotate(45deg) translateY(4px);
      transform-origin: 100% 100%
    }

    .el-step.is-simple:last-of-type .el-step__arrow {
      display: none
    }

    .el-steps {
      display: flex
    }

    .el-steps--simple {
      padding: 13px 8%;
      border-radius: 4px;
      background: var(--el-fill-color-light)
    }

    .el-steps--horizontal {
      white-space: nowrap
    }

    .el-steps--vertical {
      height: 100%;
      flex-flow: column
    }

    .el-switch {
      --el-switch-on-color: var(--el-color-primary);
      --el-switch-off-color: var(--el-border-color)
    }

    .el-switch {
      display: inline-flex;
      align-items: center;
      position: relative;
      font-size: 14px;
      line-height: 20px;
      height: 32px;
      vertical-align: middle
    }

    .el-switch.is-disabled .el-switch__core,
    .el-switch.is-disabled .el-switch__label {
      cursor: not-allowed
    }

    .el-switch__label {
      transition: var(--el-transition-duration-fast);
      height: 20px;
      display: inline-block;
      font-size: 14px;
      font-weight: 500;
      cursor: pointer;
      vertical-align: middle;
      color: var(--el-text-color-primary)
    }

    .el-switch__label.is-active {
      color: var(--el-color-primary)
    }

    .el-switch__label--left {
      margin-right: 10px
    }

    .el-switch__label--right {
      margin-left: 10px
    }

    .el-switch__label * {
      line-height: 1;
      font-size: 14px;
      display: inline-block
    }

    .el-switch__label .el-icon {
      height: inherit
    }

    .el-switch__label .el-icon svg {
      vertical-align: middle
    }

    .el-switch__input {
      position: absolute;
      width: 0;
      height: 0;
      opacity: 0;
      margin: 0
    }

    .el-switch__input:focus-visible~.el-switch__core {
      outline: 2px solid var(--el-switch-on-color);
      outline-offset: 1px
    }

    .el-switch__core {
      display: inline-flex;
      position: relative;
      align-items: center;
      min-width: 40px;
      height: 20px;
      border: 1px solid var(--el-switch-border-color, var(--el-switch-off-color));
      outline: 0;
      border-radius: 10px;
      box-sizing: border-box;
      background: var(--el-switch-off-color);
      cursor: pointer;
      transition: border-color var(--el-transition-duration), background-color var(--el-transition-duration)
    }

    .el-switch__core .el-switch__inner {
      width: 100%;
      transition: all var(--el-transition-duration);
      height: 16px;
      display: flex;
      justify-content: center;
      align-items: center;
      overflow: hidden;
      padding: 0 4px 0 calc(16px + 2px)
    }

    .el-switch__core .el-switch__inner .is-icon,
    .el-switch__core .el-switch__inner .is-text {
      font-size: 12px;
      color: var(--el-color-white);
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      overflow: hidden;
      text-overflow: ellipsis;
      white-space: nowrap
    }

    .el-switch__core .el-switch__action {
      position: absolute;
      left: 1px;
      border-radius: var(--el-border-radius-circle);
      transition: all var(--el-transition-duration);
      width: 16px;
      height: 16px;
      background-color: var(--el-color-white);
      display: flex;
      justify-content: center;
      align-items: center;
      color: var(--el-switch-off-color)
    }

    .el-switch.is-checked .el-switch__core {
      border-color: var(--el-switch-border-color, var(--el-switch-on-color));
      background-color: var(--el-switch-on-color)
    }

    .el-switch.is-checked .el-switch__core .el-switch__action {
      left: calc(100% - 17px);
      color: var(--el-switch-on-color)
    }

    .el-switch.is-checked .el-switch__core .el-switch__inner {
      padding: 0 calc(16px + 2px) 0 4px
    }

    .el-switch.is-disabled {
      opacity: .6
    }

    .el-switch--wide .el-switch__label.el-switch__label--left span {
      left: 10px
    }

    .el-switch--wide .el-switch__label.el-switch__label--right span {
      right: 10px
    }

    .el-switch .label-fade-enter-from,
    .el-switch .label-fade-leave-active {
      opacity: 0
    }

    .el-switch--large {
      font-size: 14px;
      line-height: 24px;
      height: 40px
    }

    .el-switch--large .el-switch__label {
      height: 24px;
      font-size: 14px
    }

    .el-switch--large .el-switch__label * {
      font-size: 14px
    }

    .el-switch--large .el-switch__core {
      min-width: 50px;
      height: 24px;
      border-radius: 12px
    }

    .el-switch--large .el-switch__core .el-switch__inner {
      height: 20px;
      padding: 0 6px 0 calc(20px + 2px)
    }

    .el-switch--large .el-switch__core .el-switch__action {
      width: 20px;
      height: 20px
    }

    .el-switch--large.is-checked .el-switch__core .el-switch__action {
      left: calc(100% - 21px)
    }

    .el-switch--large.is-checked .el-switch__core .el-switch__inner {
      padding: 0 calc(20px + 2px) 0 6px
    }

    .el-switch--small {
      font-size: 12px;
      line-height: 16px;
      height: 24px
    }

    .el-switch--small .el-switch__label {
      height: 16px;
      font-size: 12px
    }

    .el-switch--small .el-switch__label * {
      font-size: 12px
    }

    .el-switch--small .el-switch__core {
      min-width: 30px;
      height: 16px;
      border-radius: 8px
    }

    .el-switch--small .el-switch__core .el-switch__inner {
      height: 12px;
      padding: 0 2px 0 calc(12px + 2px)
    }

    .el-switch--small .el-switch__core .el-switch__action {
      width: 12px;
      height: 12px
    }

    .el-switch--small.is-checked .el-switch__core .el-switch__action {
      left: calc(100% - 13px)
    }

    .el-switch--small.is-checked .el-switch__core .el-switch__inner {
      padding: 0 calc(12px + 2px) 0 2px
    }

    .el-table-column--selection .cell {
      padding-left: 14px;
      padding-right: 14px
    }

    .el-table-filter {
      border: solid 1px var(--el-border-color-lighter);
      border-radius: 2px;
      background-color: #fff;
      box-shadow: var(--el-box-shadow-light);
      box-sizing: border-box
    }

    .el-table-filter__list {
      padding: 5px 0;
      margin: 0;
      list-style: none;
      min-width: 100px
    }

    .el-table-filter__list-item {
      line-height: 36px;
      padding: 0 10px;
      cursor: pointer;
      font-size: var(--el-font-size-base)
    }

    .el-table-filter__list-item:hover {
      background-color: var(--el-color-primary-light-9);
      color: var(--el-color-primary)
    }

    .el-table-filter__list-item.is-active {
      background-color: var(--el-color-primary);
      color: #fff
    }

    .el-table-filter__content {
      min-width: 100px
    }

    .el-table-filter__bottom {
      border-top: 1px solid var(--el-border-color-lighter);
      padding: 8px
    }

    .el-table-filter__bottom button {
      background: 0 0;
      border: none;
      color: var(--el-text-color-regular);
      cursor: pointer;
      font-size: var(--el-font-size-small);
      padding: 0 3px
    }

    .el-table-filter__bottom button:hover {
      color: var(--el-color-primary)
    }

    .el-table-filter__bottom button:focus {
      outline: 0
    }

    .el-table-filter__bottom button.is-disabled {
      color: var(--el-disabled-text-color);
      cursor: not-allowed
    }

    .el-table-filter__wrap {
      max-height: 280px
    }

    .el-table-filter__checkbox-group {
      padding: 10px
    }

    .el-table-filter__checkbox-group label.el-checkbox {
      display: flex;
      align-items: center;
      margin-right: 5px;
      margin-bottom: 12px;
      margin-left: 5px;
      height: unset
    }

    .el-table-filter__checkbox-group .el-checkbox:last-child {
      margin-bottom: 0
    }

    .el-table {
      --el-table-border-color: var(--el-border-color-lighter);
      --el-table-border: 1px solid var(--el-table-border-color);
      --el-table-text-color: var(--el-text-color-regular);
      --el-table-header-text-color: var(--el-text-color-secondary);
      --el-table-row-hover-bg-color: var(--el-fill-color-light);
      --el-table-current-row-bg-color: var(--el-color-primary-light-9);
      --el-table-header-bg-color: var(--el-bg-color);
      --el-table-fixed-box-shadow: var(--el-box-shadow-light);
      --el-table-bg-color: var(--el-fill-color-blank);
      --el-table-tr-bg-color: var(--el-bg-color);
      --el-table-expanded-cell-bg-color: var(--el-fill-color-blank);
      --el-table-fixed-left-column: inset 10px 0 10px -10px rgba(0, 0, 0, 0.15);
      --el-table-fixed-right-column: inset -10px 0 10px -10px rgba(0, 0, 0, 0.15);
      --el-table-index: var(--el-index-normal)
    }

    .el-table {
      position: relative;
      overflow: hidden;
      box-sizing: border-box;
      height: -webkit-fit-content;
      height: -moz-fit-content;
      height: fit-content;
      width: 100%;
      max-width: 100%;
      background-color: var(--el-table-bg-color);
      font-size: 14px;
      color: var(--el-table-text-color)
    }

    .el-table__inner-wrapper {
      position: relative;
      display: flex;
      flex-direction: column;
      height: 100%
    }

    .el-table__inner-wrapper::before {
      left: 0;
      bottom: 0;
      width: 100%;
      height: 1px
    }

    .el-table tbody:focus-visible {
      outline: 0
    }

    .el-table.has-footer.el-table--fluid-height tr:last-child td.el-table__cell,
    .el-table.has-footer.el-table--scrollable-y tr:last-child td.el-table__cell {
      border-bottom-color: transparent
    }

    .el-table__empty-block {
      position: -webkit-sticky;
      position: sticky;
      left: 0;
      min-height: 60px;
      text-align: center;
      width: 100%;
      display: flex;
      justify-content: center;
      align-items: center
    }

    .el-table__empty-text {
      line-height: 60px;
      width: 50%;
      color: var(--el-text-color-secondary)
    }

    .el-table__expand-column .cell {
      padding: 0;
      text-align: center;
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none
    }

    .el-table__expand-icon {
      position: relative;
      cursor: pointer;
      color: var(--el-text-color-regular);
      font-size: 12px;
      transition: transform var(--el-transition-duration-fast) ease-in-out;
      height: 20px
    }

    .el-table__expand-icon--expanded {
      transform: rotate(90deg)
    }

    .el-table__expand-icon>.el-icon {
      font-size: 12px
    }

    .el-table__expanded-cell {
      background-color: var(--el-table-expanded-cell-bg-color)
    }

    .el-table__expanded-cell[class*=cell] {
      padding: 20px 50px
    }

    .el-table__expanded-cell:hover {
      background-color: transparent !important
    }

    .el-table__placeholder {
      display: inline-block;
      width: 20px
    }

    .el-table__append-wrapper {
      overflow: hidden
    }

    .el-table--fit {
      border-right: 0;
      border-bottom: 0
    }

    .el-table--fit .el-table__cell.gutter {
      border-right-width: 1px
    }

    .el-table thead {
      color: var(--el-table-header-text-color)
    }

    .el-table thead th {
      font-weight: 600
    }

    .el-table thead.is-group th.el-table__cell {
      background: var(--el-fill-color-light)
    }

    .el-table .el-table__cell {
      padding: 8px 0;
      min-width: 0;
      box-sizing: border-box;
      text-overflow: ellipsis;
      vertical-align: middle;
      position: relative;
      text-align: left;
      z-index: var(--el-table-index)
    }

    .el-table .el-table__cell.is-center {
      text-align: center
    }

    .el-table .el-table__cell.is-right {
      text-align: right
    }

    .el-table .el-table__cell.gutter {
      width: 15px;
      border-right-width: 0;
      border-bottom-width: 0;
      padding: 0
    }

    .el-table .el-table__cell.is-hidden>* {
      visibility: hidden
    }

    .el-table .cell {
      box-sizing: border-box;
      overflow: hidden;
      text-overflow: ellipsis;
      white-space: normal;
      overflow-wrap: break-word;
      line-height: 23px;
      padding: 0 12px
    }

    .el-table .cell.el-tooltip {
      white-space: nowrap;
      min-width: 50px
    }

    .el-table--large {
      font-size: var(--el-font-size-base)
    }

    .el-table--large .el-table__cell {
      padding: 12px 0
    }

    .el-table--large .cell {
      padding: 0 16px
    }

    .el-table--default {
      font-size: 14px
    }

    .el-table--default .el-table__cell {
      padding: 8px 0
    }

    .el-table--default .cell {
      padding: 0 12px
    }

    .el-table--small {
      font-size: 12px
    }

    .el-table--small .el-table__cell {
      padding: 4px 0
    }

    .el-table--small .cell {
      padding: 0 8px
    }

    .el-table tr {
      background-color: var(--el-table-tr-bg-color)
    }

    .el-table tr input[type=checkbox] {
      margin: 0
    }

    .el-table td.el-table__cell,
    .el-table th.el-table__cell.is-leaf {
      border-bottom: var(--el-table-border)
    }

    .el-table th.el-table__cell.is-sortable {
      cursor: pointer
    }

    .el-table th.el-table__cell {
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      background-color: var(--el-table-header-bg-color)
    }

    .el-table th.el-table__cell>.cell.highlight {
      color: var(--el-color-primary)
    }

    .el-table th.el-table__cell.required>div::before {
      display: inline-block;
      content: """";
      width: 8px;
      height: 8px;
      border-radius: 50%;
      background: #ff4d51;
      margin-right: 5px;
      vertical-align: middle
    }

    .el-table td.el-table__cell div {
      box-sizing: border-box
    }

    .el-table td.el-table__cell.gutter {
      width: 0
    }

    .el-table--border .el-table__inner-wrapper::after,
    .el-table--border::after,
    .el-table--border::before,
    .el-table__inner-wrapper::before {
      content: """";
      position: absolute;
      background-color: var(--el-table-border-color);
      z-index: calc(var(--el-table-index) + 2)
    }

    .el-table--border .el-table__inner-wrapper::after {
      left: 0;
      top: 0;
      width: 100%;
      height: 1px;
      z-index: calc(var(--el-table-index) + 2)
    }

    .el-table--border::before {
      top: -1px;
      left: 0;
      width: 1px;
      height: 100%
    }

    .el-table--border::after {
      top: -1px;
      right: 0;
      width: 1px;
      height: 100%
    }

    .el-table--border .el-table__inner-wrapper {
      border-right: none;
      border-bottom: none
    }

    .el-table--border .el-table__footer-wrapper {
      position: relative;
      flex-shrink: 0
    }

    .el-table--border .el-table__cell {
      border-right: var(--el-table-border)
    }

    .el-table--border th.el-table__cell.gutter:last-of-type {
      border-bottom: var(--el-table-border);
      border-bottom-width: 1px
    }

    .el-table--border th.el-table__cell {
      border-bottom: var(--el-table-border)
    }

    .el-table--hidden {
      visibility: hidden
    }

    .el-table__body-wrapper,
    .el-table__footer-wrapper,
    .el-table__header-wrapper {
      width: 100%
    }

    .el-table__body-wrapper tr td.el-table-fixed-column--left,
    .el-table__body-wrapper tr td.el-table-fixed-column--right,
    .el-table__body-wrapper tr th.el-table-fixed-column--left,
    .el-table__body-wrapper tr th.el-table-fixed-column--right,
    .el-table__footer-wrapper tr td.el-table-fixed-column--left,
    .el-table__footer-wrapper tr td.el-table-fixed-column--right,
    .el-table__footer-wrapper tr th.el-table-fixed-column--left,
    .el-table__footer-wrapper tr th.el-table-fixed-column--right,
    .el-table__header-wrapper tr td.el-table-fixed-column--left,
    .el-table__header-wrapper tr td.el-table-fixed-column--right,
    .el-table__header-wrapper tr th.el-table-fixed-column--left,
    .el-table__header-wrapper tr th.el-table-fixed-column--right {
      position: -webkit-sticky !important;
      position: sticky !important;
      background: inherit;
      z-index: calc(var(--el-table-index) + 1)
    }

    .el-table__body-wrapper tr td.el-table-fixed-column--left.is-first-column::before,
    .el-table__body-wrapper tr td.el-table-fixed-column--left.is-last-column::before,
    .el-table__body-wrapper tr td.el-table-fixed-column--right.is-first-column::before,
    .el-table__body-wrapper tr td.el-table-fixed-column--right.is-last-column::before,
    .el-table__body-wrapper tr th.el-table-fixed-column--left.is-first-column::before,
    .el-table__body-wrapper tr th.el-table-fixed-column--left.is-last-column::before,
    .el-table__body-wrapper tr th.el-table-fixed-column--right.is-first-column::before,
    .el-table__body-wrapper tr th.el-table-fixed-column--right.is-last-column::before,
    .el-table__footer-wrapper tr td.el-table-fixed-column--left.is-first-column::before,
    .el-table__footer-wrapper tr td.el-table-fixed-column--left.is-last-column::before,
    .el-table__footer-wrapper tr td.el-table-fixed-column--right.is-first-column::before,
    .el-table__footer-wrapper tr td.el-table-fixed-column--right.is-last-column::before,
    .el-table__footer-wrapper tr th.el-table-fixed-column--left.is-first-column::before,
    .el-table__footer-wrapper tr th.el-table-fixed-column--left.is-last-column::before,
    .el-table__footer-wrapper tr th.el-table-fixed-column--right.is-first-column::before,
    .el-table__footer-wrapper tr th.el-table-fixed-column--right.is-last-column::before,
    .el-table__header-wrapper tr td.el-table-fixed-column--left.is-first-column::before,
    .el-table__header-wrapper tr td.el-table-fixed-column--left.is-last-column::before,
    .el-table__header-wrapper tr td.el-table-fixed-column--right.is-first-column::before,
    .el-table__header-wrapper tr td.el-table-fixed-column--right.is-last-column::before,
    .el-table__header-wrapper tr th.el-table-fixed-column--left.is-first-column::before,
    .el-table__header-wrapper tr th.el-table-fixed-column--left.is-last-column::before,
    .el-table__header-wrapper tr th.el-table-fixed-column--right.is-first-column::before,
    .el-table__header-wrapper tr th.el-table-fixed-column--right.is-last-column::before {
      content: """";
      position: absolute;
      top: 0;
      width: 10px;
      bottom: -1px;
      overflow-x: hidden;
      overflow-y: hidden;
      box-shadow: none;
      touch-action: none;
      pointer-events: none
    }

    .el-table__body-wrapper tr td.el-table-fixed-column--left.is-first-column::before,
    .el-table__body-wrapper tr td.el-table-fixed-column--right.is-first-column::before,
    .el-table__body-wrapper tr th.el-table-fixed-column--left.is-first-column::before,
    .el-table__body-wrapper tr th.el-table-fixed-column--right.is-first-column::before,
    .el-table__footer-wrapper tr td.el-table-fixed-column--left.is-first-column::before,
    .el-table__footer-wrapper tr td.el-table-fixed-column--right.is-first-column::before,
    .el-table__footer-wrapper tr th.el-table-fixed-column--left.is-first-column::before,
    .el-table__footer-wrapper tr th.el-table-fixed-column--right.is-first-column::before,
    .el-table__header-wrapper tr td.el-table-fixed-column--left.is-first-column::before,
    .el-table__header-wrapper tr td.el-table-fixed-column--right.is-first-column::before,
    .el-table__header-wrapper tr th.el-table-fixed-column--left.is-first-column::before,
    .el-table__header-wrapper tr th.el-table-fixed-column--right.is-first-column::before {
      left: -10px
    }

    .el-table__body-wrapper tr td.el-table-fixed-column--left.is-last-column::before,
    .el-table__body-wrapper tr td.el-table-fixed-column--right.is-last-column::before,
    .el-table__body-wrapper tr th.el-table-fixed-column--left.is-last-column::before,
    .el-table__body-wrapper tr th.el-table-fixed-column--right.is-last-column::before,
    .el-table__footer-wrapper tr td.el-table-fixed-column--left.is-last-column::before,
    .el-table__footer-wrapper tr td.el-table-fixed-column--right.is-last-column::before,
    .el-table__footer-wrapper tr th.el-table-fixed-column--left.is-last-column::before,
    .el-table__footer-wrapper tr th.el-table-fixed-column--right.is-last-column::before,
    .el-table__header-wrapper tr td.el-table-fixed-column--left.is-last-column::before,
    .el-table__header-wrapper tr td.el-table-fixed-column--right.is-last-column::before,
    .el-table__header-wrapper tr th.el-table-fixed-column--left.is-last-column::before,
    .el-table__header-wrapper tr th.el-table-fixed-column--right.is-last-column::before {
      right: -10px;
      box-shadow: none
    }

    .el-table__body-wrapper tr td.el-table__fixed-right-patch,
    .el-table__body-wrapper tr th.el-table__fixed-right-patch,
    .el-table__footer-wrapper tr td.el-table__fixed-right-patch,
    .el-table__footer-wrapper tr th.el-table__fixed-right-patch,
    .el-table__header-wrapper tr td.el-table__fixed-right-patch,
    .el-table__header-wrapper tr th.el-table__fixed-right-patch {
      position: -webkit-sticky !important;
      position: sticky !important;
      z-index: calc(var(--el-table-index) + 1);
      background: #fff;
      right: 0
    }

    .el-table__header-wrapper {
      flex-shrink: 0
    }

    .el-table__header-wrapper tr th.el-table-fixed-column--left,
    .el-table__header-wrapper tr th.el-table-fixed-column--right {
      background-color: var(--el-table-header-bg-color)
    }

    .el-table__body,
    .el-table__footer,
    .el-table__header {
      table-layout: fixed;
      border-collapse: separate
    }

    .el-table__header-wrapper {
      overflow: hidden
    }

    .el-table__header-wrapper tbody td.el-table__cell {
      background-color: var(--el-table-row-hover-bg-color);
      color: var(--el-table-text-color)
    }

    .el-table__footer-wrapper {
      overflow: hidden;
      flex-shrink: 0
    }

    .el-table__footer-wrapper tfoot td.el-table__cell {
      background-color: var(--el-table-row-hover-bg-color);
      color: var(--el-table-text-color)
    }

    .el-table__body-wrapper .el-table-column--selection>.cell,
    .el-table__header-wrapper .el-table-column--selection>.cell {
      display: inline-flex;
      align-items: center;
      height: 23px
    }

    .el-table__body-wrapper .el-table-column--selection .el-checkbox,
    .el-table__header-wrapper .el-table-column--selection .el-checkbox {
      height: unset
    }

    .el-table.is-scrolling-left .el-table-fixed-column--right.is-first-column::before {
      box-shadow: var(--el-table-fixed-right-column)
    }

    .el-table.is-scrolling-left.el-table--border .el-table-fixed-column--left.is-last-column.el-table__cell {
      border-right: var(--el-table-border)
    }

    .el-table.is-scrolling-left th.el-table-fixed-column--left {
      background-color: var(--el-table-header-bg-color)
    }

    .el-table.is-scrolling-right .el-table-fixed-column--left.is-last-column::before {
      box-shadow: var(--el-table-fixed-left-column)
    }

    .el-table.is-scrolling-right .el-table-fixed-column--left.is-last-column.el-table__cell {
      border-right: none
    }

    .el-table.is-scrolling-right th.el-table-fixed-column--right {
      background-color: var(--el-table-header-bg-color)
    }

    .el-table.is-scrolling-middle .el-table-fixed-column--left.is-last-column.el-table__cell {
      border-right: none
    }

    .el-table.is-scrolling-middle .el-table-fixed-column--right.is-first-column::before {
      box-shadow: var(--el-table-fixed-right-column)
    }

    .el-table.is-scrolling-middle .el-table-fixed-column--left.is-last-column::before {
      box-shadow: var(--el-table-fixed-left-column)
    }

    .el-table.is-scrolling-none .el-table-fixed-column--left.is-first-column::before,
    .el-table.is-scrolling-none .el-table-fixed-column--left.is-last-column::before,
    .el-table.is-scrolling-none .el-table-fixed-column--right.is-first-column::before,
    .el-table.is-scrolling-none .el-table-fixed-column--right.is-last-column::before {
      box-shadow: none
    }

    .el-table.is-scrolling-none th.el-table-fixed-column--left,
    .el-table.is-scrolling-none th.el-table-fixed-column--right {
      background-color: var(--el-table-header-bg-color)
    }

    .el-table__body-wrapper {
      overflow: hidden;
      position: relative;
      flex: 1
    }

    .el-table__body-wrapper .el-scrollbar__bar {
      z-index: calc(var(--el-table-index) + 2)
    }

    .el-table .caret-wrapper {
      display: inline-flex;
      flex-direction: column;
      align-items: center;
      height: 14px;
      width: 24px;
      vertical-align: middle;
      cursor: pointer;
      overflow: initial;
      position: relative
    }

    .el-table .sort-caret {
      width: 0;
      height: 0;
      border: solid 5px transparent;
      position: absolute;
      left: 7px
    }

    .el-table .sort-caret.ascending {
      border-bottom-color: var(--el-text-color-placeholder);
      top: -5px
    }

    .el-table .sort-caret.descending {
      border-top-color: var(--el-text-color-placeholder);
      bottom: -3px
    }

    .el-table .ascending .sort-caret.ascending {
      border-bottom-color: var(--el-color-primary)
    }

    .el-table .descending .sort-caret.descending {
      border-top-color: var(--el-color-primary)
    }

    .el-table .hidden-columns {
      visibility: hidden;
      position: absolute;
      z-index: -1
    }

    .el-table--striped .el-table__body tr.el-table__row--striped td.el-table__cell {
      background: var(--el-fill-color-lighter)
    }

    .el-table--striped .el-table__body tr.el-table__row--striped.current-row td.el-table__cell {
      background-color: var(--el-table-current-row-bg-color)
    }

    .el-table__body tr.hover-row.current-row>td.el-table__cell,
    .el-table__body tr.hover-row.el-table__row--striped.current-row>td.el-table__cell,
    .el-table__body tr.hover-row.el-table__row--striped>td.el-table__cell,
    .el-table__body tr.hover-row>td.el-table__cell {
      background-color: var(--el-table-row-hover-bg-color)
    }

    .el-table__body tr.current-row>td.el-table__cell {
      background-color: var(--el-table-current-row-bg-color)
    }

    .el-table.el-table--scrollable-y .el-table__body-header {
      position: -webkit-sticky;
      position: sticky;
      top: 0;
      z-index: calc(var(--el-table-index) + 2)
    }

    .el-table.el-table--scrollable-y .el-table__body-footer {
      position: -webkit-sticky;
      position: sticky;
      bottom: 0;
      z-index: calc(var(--el-table-index) + 2)
    }

    .el-table__column-resize-proxy {
      position: absolute;
      left: 200px;
      top: 0;
      bottom: 0;
      width: 0;
      border-left: var(--el-table-border);
      z-index: calc(var(--el-table-index) + 9)
    }

    .el-table__column-filter-trigger {
      display: inline-block;
      cursor: pointer
    }

    .el-table__column-filter-trigger i {
      color: var(--el-color-info);
      font-size: 14px;
      vertical-align: middle
    }

    .el-table__border-left-patch {
      top: 0;
      left: 0;
      width: 1px;
      height: 100%;
      z-index: calc(var(--el-table-index) + 2);
      position: absolute;
      background-color: var(--el-table-border-color)
    }

    .el-table__border-bottom-patch {
      left: 0;
      height: 1px;
      z-index: calc(var(--el-table-index) + 2);
      position: absolute;
      background-color: var(--el-table-border-color)
    }

    .el-table__border-right-patch {
      top: 0;
      height: 100%;
      width: 1px;
      z-index: calc(var(--el-table-index) + 2);
      position: absolute;
      background-color: var(--el-table-border-color)
    }

    .el-table--enable-row-transition .el-table__body td.el-table__cell {
      transition: background-color .25s ease
    }

    .el-table--enable-row-hover .el-table__body tr:hover>td.el-table__cell {
      background-color: var(--el-table-row-hover-bg-color)
    }

    .el-table [class*=el-table__row--level] .el-table__expand-icon {
      display: inline-block;
      width: 12px;
      line-height: 12px;
      height: 12px;
      text-align: center;
      margin-right: 8px
    }

    .el-table .el-table.el-table--border .el-table__cell {
      border-right: var(--el-table-border)
    }

    .el-table:not(.el-table--border) .el-table__cell {
      border-right: none
    }

    .el-table:not(.el-table--border)>.el-table__inner-wrapper::after {
      content: none
    }

    .el-table-v2 {
      --el-table-border-color: var(--el-border-color-lighter);
      --el-table-border: 1px solid var(--el-table-border-color);
      --el-table-text-color: var(--el-text-color-regular);
      --el-table-header-text-color: var(--el-text-color-secondary);
      --el-table-row-hover-bg-color: var(--el-fill-color-light);
      --el-table-current-row-bg-color: var(--el-color-primary-light-9);
      --el-table-header-bg-color: var(--el-bg-color);
      --el-table-fixed-box-shadow: var(--el-box-shadow-light);
      --el-table-bg-color: var(--el-fill-color-blank);
      --el-table-tr-bg-color: var(--el-bg-color);
      --el-table-expanded-cell-bg-color: var(--el-fill-color-blank);
      --el-table-fixed-left-column: inset 10px 0 10px -10px rgba(0, 0, 0, 0.15);
      --el-table-fixed-right-column: inset -10px 0 10px -10px rgba(0, 0, 0, 0.15);
      --el-table-index: var(--el-index-normal)
    }

    .el-table-v2 {
      font-size: 14px
    }

    .el-table-v2 * {
      box-sizing: border-box
    }

    .el-table-v2__root {
      position: relative
    }

    .el-table-v2__root:hover .el-table-v2__main .el-virtual-scrollbar {
      opacity: 1
    }

    .el-table-v2__main {
      display: flex;
      flex-direction: column-reverse;
      position: absolute;
      overflow: hidden;
      top: 0;
      background-color: var(--el-bg-color);
      left: 0
    }

    .el-table-v2__main .el-vl__horizontal,
    .el-table-v2__main .el-vl__vertical {
      z-index: 2
    }

    .el-table-v2__left {
      display: flex;
      flex-direction: column-reverse;
      position: absolute;
      overflow: hidden;
      top: 0;
      background-color: var(--el-bg-color);
      left: 0;
      box-shadow: 2px 0 4px 0 rgba(0, 0, 0, .06)
    }

    .el-table-v2__left .el-virtual-scrollbar {
      opacity: 0
    }

    .el-table-v2__left .el-vl__horizontal,
    .el-table-v2__left .el-vl__vertical {
      z-index: -1
    }

    .el-table-v2__right {
      display: flex;
      flex-direction: column-reverse;
      position: absolute;
      overflow: hidden;
      top: 0;
      background-color: var(--el-bg-color);
      right: 0;
      box-shadow: -2px 0 4px 0 rgba(0, 0, 0, .06)
    }

    .el-table-v2__right .el-virtual-scrollbar {
      opacity: 0
    }

    .el-table-v2__right .el-vl__horizontal,
    .el-table-v2__right .el-vl__vertical {
      z-index: -1
    }

    .el-table-v2__header-row {
      -webkit-padding-end: var(--el-table-scrollbar-size);
      padding-inline-end: var(--el-table-scrollbar-size)
    }

    .el-table-v2__row {
      -webkit-padding-end: var(--el-table-scrollbar-size);
      padding-inline-end: var(--el-table-scrollbar-size)
    }

    .el-table-v2__header-wrapper {
      overflow: hidden
    }

    .el-table-v2__header {
      position: relative;
      overflow: hidden
    }

    .el-table-v2__footer {
      position: absolute;
      left: 0;
      right: 0;
      bottom: 0;
      overflow: hidden
    }

    .el-table-v2__empty {
      position: absolute;
      left: 0
    }

    .el-table-v2__overlay {
      position: absolute;
      left: 0;
      right: 0;
      top: 0;
      bottom: 0;
      z-index: 9999
    }

    .el-table-v2__header-row {
      display: flex;
      border-bottom: var(--el-table-border)
    }

    .el-table-v2__header-cell {
      display: flex;
      align-items: center;
      padding: 0 8px;
      height: 100%;
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      overflow: hidden;
      background-color: var(--el-table-header-bg-color);
      color: var(--el-table-header-text-color);
      font-weight: 700
    }

    .el-table-v2__header-cell.is-align-center {
      justify-content: center;
      text-align: center
    }

    .el-table-v2__header-cell.is-align-right {
      justify-content: flex-end;
      text-align: right
    }

    .el-table-v2__header-cell.is-sortable {
      cursor: pointer
    }

    .el-table-v2__header-cell:hover .el-icon {
      display: block
    }

    .el-table-v2__sort-icon {
      transition: opacity, display var(--el-transition-duration);
      opacity: .6;
      display: none
    }

    .el-table-v2__sort-icon.is-sorting {
      display: block;
      opacity: 1
    }

    .el-table-v2__row {
      border-bottom: var(--el-table-border);
      display: flex;
      align-items: center;
      transition: background-color var(--el-transition-duration)
    }

    .el-table-v2__row.is-hovered {
      background-color: var(--el-table-row-hover-bg-color)
    }

    .el-table-v2__row:hover {
      background-color: var(--el-table-row-hover-bg-color)
    }

    .el-table-v2__row-cell {
      height: 100%;
      overflow: hidden;
      display: flex;
      align-items: center;
      padding: 0 8px
    }

    .el-table-v2__row-cell.is-align-center {
      justify-content: center;
      text-align: center
    }

    .el-table-v2__row-cell.is-align-right {
      justify-content: flex-end;
      text-align: right
    }

    .el-table-v2__expand-icon {
      margin: 0 4px;
      cursor: pointer;
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none
    }

    .el-table-v2__expand-icon svg {
      transition: transform var(--el-transition-duration)
    }

    .el-table-v2__expand-icon.is-expanded svg {
      transform: rotate(90deg)
    }

    .el-table-v2:not(.is-dynamic) .el-table-v2__cell-text {
      overflow: hidden;
      text-overflow: ellipsis;
      white-space: nowrap
    }

    .el-table-v2.is-dynamic .el-table-v2__row {
      overflow: hidden;
      align-items: stretch
    }

    .el-table-v2.is-dynamic .el-table-v2__row .el-table-v2__row-cell {
      overflow-wrap: break-word
    }

    .el-tabs {
      --el-tabs-header-height: 40px
    }

    .el-tabs__header {
      padding: 0;
      position: relative;
      margin: 0 0 15px
    }

    .el-tabs__active-bar {
      position: absolute;
      bottom: 0;
      left: 0;
      height: 2px;
      background-color: var(--el-color-primary);
      z-index: 1;
      transition: width var(--el-transition-duration) var(--el-transition-function-ease-in-out-bezier), transform var(--el-transition-duration) var(--el-transition-function-ease-in-out-bezier);
      list-style: none
    }

    .el-tabs__new-tab {
      display: flex;
      align-items: center;
      justify-content: center;
      float: right;
      border: 1px solid var(--el-border-color);
      height: 20px;
      width: 20px;
      line-height: 20px;
      margin: 10px 0 10px 10px;
      border-radius: 3px;
      text-align: center;
      font-size: 12px;
      color: var(--el-text-color-primary);
      cursor: pointer;
      transition: all .15s
    }

    .el-tabs__new-tab .is-icon-plus {
      height: inherit;
      width: inherit;
      transform: scale(.8, .8)
    }

    .el-tabs__new-tab .is-icon-plus svg {
      vertical-align: middle
    }

    .el-tabs__new-tab:hover {
      color: var(--el-color-primary)
    }

    .el-tabs__nav-wrap {
      overflow: hidden;
      margin-bottom: -1px;
      position: relative
    }

    .el-tabs__nav-wrap::after {
      content: """";
      position: absolute;
      left: 0;
      bottom: 0;
      width: 100%;
      height: 2px;
      background-color: var(--el-border-color-light);
      z-index: var(--el-index-normal)
    }

    .el-tabs__nav-wrap.is-scrollable {
      padding: 0 20px;
      box-sizing: border-box
    }

    .el-tabs__nav-scroll {
      overflow: hidden
    }

    .el-tabs__nav-next,
    .el-tabs__nav-prev {
      position: absolute;
      cursor: pointer;
      line-height: 44px;
      font-size: 12px;
      color: var(--el-text-color-secondary);
      width: 20px;
      text-align: center
    }

    .el-tabs__nav-next {
      right: 0
    }

    .el-tabs__nav-prev {
      left: 0
    }

    .el-tabs__nav {
      display: flex;
      white-space: nowrap;
      position: relative;
      transition: transform var(--el-transition-duration);
      float: left;
      z-index: calc(var(--el-index-normal) + 1)
    }

    .el-tabs__nav.is-stretch {
      min-width: 100%;
      display: flex
    }

    .el-tabs__nav.is-stretch>* {
      flex: 1;
      text-align: center
    }

    .el-tabs__item {
      padding: 0 20px;
      height: var(--el-tabs-header-height);
      box-sizing: border-box;
      display: flex;
      align-items: center;
      justify-content: center;
      list-style: none;
      font-size: var(--el-font-size-base);
      font-weight: 500;
      color: var(--el-text-color-primary);
      position: relative
    }

    .el-tabs__item:focus,
    .el-tabs__item:focus:active {
      outline: 0
    }

    .el-tabs__item:focus-visible {
      box-shadow: 0 0 2px 2px var(--el-color-primary) inset;
      border-radius: 3px
    }

    .el-tabs__item .is-icon-close {
      border-radius: 50%;
      text-align: center;
      transition: all var(--el-transition-duration) var(--el-transition-function-ease-in-out-bezier);
      margin-left: 5px
    }

    .el-tabs__item .is-icon-close:before {
      transform: scale(.9);
      display: inline-block
    }

    .el-tabs__item .is-icon-close:hover {
      background-color: var(--el-text-color-placeholder);
      color: #fff
    }

    .el-tabs__item.is-active {
      color: var(--el-color-primary)
    }

    .el-tabs__item:hover {
      color: var(--el-color-primary);
      cursor: pointer
    }

    .el-tabs__item.is-disabled {
      color: var(--el-disabled-text-color);
      cursor: not-allowed
    }

    .el-tabs__content {
      overflow: hidden;
      position: relative
    }

    .el-tabs--card>.el-tabs__header {
      border-bottom: 1px solid var(--el-border-color-light);
      height: var(--el-tabs-header-height)
    }

    .el-tabs--card>.el-tabs__header .el-tabs__nav-wrap::after {
      content: none
    }

    .el-tabs--card>.el-tabs__header .el-tabs__nav {
      border: 1px solid var(--el-border-color-light);
      border-bottom: none;
      border-radius: 4px 4px 0 0;
      box-sizing: border-box
    }

    .el-tabs--card>.el-tabs__header .el-tabs__active-bar {
      display: none
    }

    .el-tabs--card>.el-tabs__header .el-tabs__item .is-icon-close {
      position: relative;
      font-size: 12px;
      width: 0;
      height: 14px;
      overflow: hidden;
      right: -2px;
      transform-origin: 100% 50%
    }

    .el-tabs--card>.el-tabs__header .el-tabs__item {
      border-bottom: 1px solid transparent;
      border-left: 1px solid var(--el-border-color-light);
      transition: color var(--el-transition-duration) var(--el-transition-function-ease-in-out-bezier), padding var(--el-transition-duration) var(--el-transition-function-ease-in-out-bezier)
    }

    .el-tabs--card>.el-tabs__header .el-tabs__item:first-child {
      border-left: none
    }

    .el-tabs--card>.el-tabs__header .el-tabs__item.is-closable:hover {
      padding-left: 13px;
      padding-right: 13px
    }

    .el-tabs--card>.el-tabs__header .el-tabs__item.is-closable:hover .is-icon-close {
      width: 14px
    }

    .el-tabs--card>.el-tabs__header .el-tabs__item.is-active {
      border-bottom-color: var(--el-bg-color)
    }

    .el-tabs--card>.el-tabs__header .el-tabs__item.is-active.is-closable {
      padding-left: 20px;
      padding-right: 20px
    }

    .el-tabs--card>.el-tabs__header .el-tabs__item.is-active.is-closable .is-icon-close {
      width: 14px
    }

    .el-tabs--border-card {
      background: var(--el-bg-color-overlay);
      border: 1px solid var(--el-border-color)
    }

    .el-tabs--border-card>.el-tabs__content {
      padding: 15px
    }

    .el-tabs--border-card>.el-tabs__header {
      background-color: var(--el-fill-color-light);
      border-bottom: 1px solid var(--el-border-color-light);
      margin: 0
    }

    .el-tabs--border-card>.el-tabs__header .el-tabs__nav-wrap::after {
      content: none
    }

    .el-tabs--border-card>.el-tabs__header .el-tabs__item {
      transition: all var(--el-transition-duration) var(--el-transition-function-ease-in-out-bezier);
      border: 1px solid transparent;
      margin-top: -1px;
      color: var(--el-text-color-secondary)
    }

    .el-tabs--border-card>.el-tabs__header .el-tabs__item:first-child {
      margin-left: -1px
    }

    .el-tabs--border-card>.el-tabs__header .el-tabs__item+.el-tabs__item {
      margin-left: -1px
    }

    .el-tabs--border-card>.el-tabs__header .el-tabs__item.is-active {
      color: var(--el-color-primary);
      background-color: var(--el-bg-color-overlay);
      border-right-color: var(--el-border-color);
      border-left-color: var(--el-border-color)
    }

    .el-tabs--border-card>.el-tabs__header .el-tabs__item:not(.is-disabled):hover {
      color: var(--el-color-primary)
    }

    .el-tabs--border-card>.el-tabs__header .el-tabs__item.is-disabled {
      color: var(--el-disabled-text-color)
    }

    .el-tabs--border-card>.el-tabs__header .is-scrollable .el-tabs__item:first-child {
      margin-left: 0
    }

    .el-tabs--bottom .el-tabs__item.is-bottom:nth-child(2),
    .el-tabs--bottom .el-tabs__item.is-top:nth-child(2),
    .el-tabs--top .el-tabs__item.is-bottom:nth-child(2),
    .el-tabs--top .el-tabs__item.is-top:nth-child(2) {
      padding-left: 0
    }

    .el-tabs--bottom .el-tabs__item.is-bottom:last-child,
    .el-tabs--bottom .el-tabs__item.is-top:last-child,
    .el-tabs--top .el-tabs__item.is-bottom:last-child,
    .el-tabs--top .el-tabs__item.is-top:last-child {
      padding-right: 0
    }

    .el-tabs--bottom .el-tabs--left>.el-tabs__header .el-tabs__item:nth-child(2),
    .el-tabs--bottom .el-tabs--right>.el-tabs__header .el-tabs__item:nth-child(2),
    .el-tabs--bottom.el-tabs--border-card>.el-tabs__header .el-tabs__item:nth-child(2),
    .el-tabs--bottom.el-tabs--card>.el-tabs__header .el-tabs__item:nth-child(2),
    .el-tabs--top .el-tabs--left>.el-tabs__header .el-tabs__item:nth-child(2),
    .el-tabs--top .el-tabs--right>.el-tabs__header .el-tabs__item:nth-child(2),
    .el-tabs--top.el-tabs--border-card>.el-tabs__header .el-tabs__item:nth-child(2),
    .el-tabs--top.el-tabs--card>.el-tabs__header .el-tabs__item:nth-child(2) {
      padding-left: 20px
    }

    .el-tabs--bottom .el-tabs--left>.el-tabs__header .el-tabs__item:nth-child(2):not(.is-active).is-closable:hover,
    .el-tabs--bottom .el-tabs--right>.el-tabs__header .el-tabs__item:nth-child(2):not(.is-active).is-closable:hover,
    .el-tabs--bottom.el-tabs--border-card>.el-tabs__header .el-tabs__item:nth-child(2):not(.is-active).is-closable:hover,
    .el-tabs--bottom.el-tabs--card>.el-tabs__header .el-tabs__item:nth-child(2):not(.is-active).is-closable:hover,
    .el-tabs--top .el-tabs--left>.el-tabs__header .el-tabs__item:nth-child(2):not(.is-active).is-closable:hover,
    .el-tabs--top .el-tabs--right>.el-tabs__header .el-tabs__item:nth-child(2):not(.is-active).is-closable:hover,
    .el-tabs--top.el-tabs--border-card>.el-tabs__header .el-tabs__item:nth-child(2):not(.is-active).is-closable:hover,
    .el-tabs--top.el-tabs--card>.el-tabs__header .el-tabs__item:nth-child(2):not(.is-active).is-closable:hover {
      padding-left: 13px
    }

    .el-tabs--bottom .el-tabs--left>.el-tabs__header .el-tabs__item:last-child,
    .el-tabs--bottom .el-tabs--right>.el-tabs__header .el-tabs__item:last-child,
    .el-tabs--bottom.el-tabs--border-card>.el-tabs__header .el-tabs__item:last-child,
    .el-tabs--bottom.el-tabs--card>.el-tabs__header .el-tabs__item:last-child,
    .el-tabs--top .el-tabs--left>.el-tabs__header .el-tabs__item:last-child,
    .el-tabs--top .el-tabs--right>.el-tabs__header .el-tabs__item:last-child,
    .el-tabs--top.el-tabs--border-card>.el-tabs__header .el-tabs__item:last-child,
    .el-tabs--top.el-tabs--card>.el-tabs__header .el-tabs__item:last-child {
      padding-right: 20px
    }

    .el-tabs--bottom .el-tabs--left>.el-tabs__header .el-tabs__item:last-child:not(.is-active).is-closable:hover,
    .el-tabs--bottom .el-tabs--right>.el-tabs__header .el-tabs__item:last-child:not(.is-active).is-closable:hover,
    .el-tabs--bottom.el-tabs--border-card>.el-tabs__header .el-tabs__item:last-child:not(.is-active).is-closable:hover,
    .el-tabs--bottom.el-tabs--card>.el-tabs__header .el-tabs__item:last-child:not(.is-active).is-closable:hover,
    .el-tabs--top .el-tabs--left>.el-tabs__header .el-tabs__item:last-child:not(.is-active).is-closable:hover,
    .el-tabs--top .el-tabs--right>.el-tabs__header .el-tabs__item:last-child:not(.is-active).is-closable:hover,
    .el-tabs--top.el-tabs--border-card>.el-tabs__header .el-tabs__item:last-child:not(.is-active).is-closable:hover,
    .el-tabs--top.el-tabs--card>.el-tabs__header .el-tabs__item:last-child:not(.is-active).is-closable:hover {
      padding-right: 13px
    }

    .el-tabs--bottom .el-tabs__header.is-bottom {
      margin-bottom: 0;
      margin-top: 10px
    }

    .el-tabs--bottom.el-tabs--border-card .el-tabs__header.is-bottom {
      border-bottom: 0;
      border-top: 1px solid var(--el-border-color)
    }

    .el-tabs--bottom.el-tabs--border-card .el-tabs__nav-wrap.is-bottom {
      margin-top: -1px;
      margin-bottom: 0
    }

    .el-tabs--bottom.el-tabs--border-card .el-tabs__item.is-bottom:not(.is-active) {
      border: 1px solid transparent
    }

    .el-tabs--bottom.el-tabs--border-card .el-tabs__item.is-bottom {
      margin: 0 -1px -1px
    }

    .el-tabs--left,
    .el-tabs--right {
      overflow: hidden
    }

    .el-tabs--left .el-tabs__header.is-left,
    .el-tabs--left .el-tabs__header.is-right,
    .el-tabs--left .el-tabs__nav-scroll,
    .el-tabs--left .el-tabs__nav-wrap.is-left,
    .el-tabs--left .el-tabs__nav-wrap.is-right,
    .el-tabs--right .el-tabs__header.is-left,
    .el-tabs--right .el-tabs__header.is-right,
    .el-tabs--right .el-tabs__nav-scroll,
    .el-tabs--right .el-tabs__nav-wrap.is-left,
    .el-tabs--right .el-tabs__nav-wrap.is-right {
      height: 100%
    }

    .el-tabs--left .el-tabs__active-bar.is-left,
    .el-tabs--left .el-tabs__active-bar.is-right,
    .el-tabs--right .el-tabs__active-bar.is-left,
    .el-tabs--right .el-tabs__active-bar.is-right {
      top: 0;
      bottom: auto;
      width: 2px;
      height: auto
    }

    .el-tabs--left .el-tabs__nav-wrap.is-left,
    .el-tabs--left .el-tabs__nav-wrap.is-right,
    .el-tabs--right .el-tabs__nav-wrap.is-left,
    .el-tabs--right .el-tabs__nav-wrap.is-right {
      margin-bottom: 0
    }

    .el-tabs--left .el-tabs__nav-wrap.is-left>.el-tabs__nav-next,
    .el-tabs--left .el-tabs__nav-wrap.is-left>.el-tabs__nav-prev,
    .el-tabs--left .el-tabs__nav-wrap.is-right>.el-tabs__nav-next,
    .el-tabs--left .el-tabs__nav-wrap.is-right>.el-tabs__nav-prev,
    .el-tabs--right .el-tabs__nav-wrap.is-left>.el-tabs__nav-next,
    .el-tabs--right .el-tabs__nav-wrap.is-left>.el-tabs__nav-prev,
    .el-tabs--right .el-tabs__nav-wrap.is-right>.el-tabs__nav-next,
    .el-tabs--right .el-tabs__nav-wrap.is-right>.el-tabs__nav-prev {
      height: 30px;
      line-height: 30px;
      width: 100%;
      text-align: center;
      cursor: pointer
    }

    .el-tabs--left .el-tabs__nav-wrap.is-left>.el-tabs__nav-next i,
    .el-tabs--left .el-tabs__nav-wrap.is-left>.el-tabs__nav-prev i,
    .el-tabs--left .el-tabs__nav-wrap.is-right>.el-tabs__nav-next i,
    .el-tabs--left .el-tabs__nav-wrap.is-right>.el-tabs__nav-prev i,
    .el-tabs--right .el-tabs__nav-wrap.is-left>.el-tabs__nav-next i,
    .el-tabs--right .el-tabs__nav-wrap.is-left>.el-tabs__nav-prev i,
    .el-tabs--right .el-tabs__nav-wrap.is-right>.el-tabs__nav-next i,
    .el-tabs--right .el-tabs__nav-wrap.is-right>.el-tabs__nav-prev i {
      transform: rotateZ(90deg)
    }

    .el-tabs--left .el-tabs__nav-wrap.is-left>.el-tabs__nav-prev,
    .el-tabs--left .el-tabs__nav-wrap.is-right>.el-tabs__nav-prev,
    .el-tabs--right .el-tabs__nav-wrap.is-left>.el-tabs__nav-prev,
    .el-tabs--right .el-tabs__nav-wrap.is-right>.el-tabs__nav-prev {
      left: auto;
      top: 0
    }

    .el-tabs--left .el-tabs__nav-wrap.is-left>.el-tabs__nav-next,
    .el-tabs--left .el-tabs__nav-wrap.is-right>.el-tabs__nav-next,
    .el-tabs--right .el-tabs__nav-wrap.is-left>.el-tabs__nav-next,
    .el-tabs--right .el-tabs__nav-wrap.is-right>.el-tabs__nav-next {
      right: auto;
      bottom: 0
    }

    .el-tabs--left .el-tabs__nav-wrap.is-left.is-scrollable,
    .el-tabs--left .el-tabs__nav-wrap.is-right.is-scrollable,
    .el-tabs--right .el-tabs__nav-wrap.is-left.is-scrollable,
    .el-tabs--right .el-tabs__nav-wrap.is-right.is-scrollable {
      padding: 30px 0
    }

    .el-tabs--left .el-tabs__nav-wrap.is-left::after,
    .el-tabs--left .el-tabs__nav-wrap.is-right::after,
    .el-tabs--right .el-tabs__nav-wrap.is-left::after,
    .el-tabs--right .el-tabs__nav-wrap.is-right::after {
      height: 100%;
      width: 2px;
      bottom: auto;
      top: 0
    }

    .el-tabs--left .el-tabs__nav.is-left,
    .el-tabs--left .el-tabs__nav.is-right,
    .el-tabs--right .el-tabs__nav.is-left,
    .el-tabs--right .el-tabs__nav.is-right {
      flex-direction: column
    }

    .el-tabs--left .el-tabs__item.is-left,
    .el-tabs--right .el-tabs__item.is-left {
      justify-content: flex-end
    }

    .el-tabs--left .el-tabs__item.is-right,
    .el-tabs--right .el-tabs__item.is-right {
      justify-content: flex-start
    }

    .el-tabs--left .el-tabs__header.is-left {
      float: left;
      margin-bottom: 0;
      margin-right: 10px
    }

    .el-tabs--left .el-tabs__nav-wrap.is-left {
      margin-right: -1px
    }

    .el-tabs--left .el-tabs__nav-wrap.is-left::after {
      left: auto;
      right: 0
    }

    .el-tabs--left .el-tabs__active-bar.is-left {
      right: 0;
      left: auto
    }

    .el-tabs--left .el-tabs__item.is-left {
      text-align: right
    }

    .el-tabs--left.el-tabs--card .el-tabs__active-bar.is-left {
      display: none
    }

    .el-tabs--left.el-tabs--card .el-tabs__item.is-left {
      border-left: none;
      border-right: 1px solid var(--el-border-color-light);
      border-bottom: none;
      border-top: 1px solid var(--el-border-color-light);
      text-align: left
    }

    .el-tabs--left.el-tabs--card .el-tabs__item.is-left:first-child {
      border-right: 1px solid var(--el-border-color-light);
      border-top: none
    }

    .el-tabs--left.el-tabs--card .el-tabs__item.is-left.is-active {
      border: 1px solid var(--el-border-color-light);
      border-right-color: #fff;
      border-left: none;
      border-bottom: none
    }

    .el-tabs--left.el-tabs--card .el-tabs__item.is-left.is-active:first-child {
      border-top: none
    }

    .el-tabs--left.el-tabs--card .el-tabs__item.is-left.is-active:last-child {
      border-bottom: none
    }

    .el-tabs--left.el-tabs--card .el-tabs__nav {
      border-radius: 4px 0 0 4px;
      border-bottom: 1px solid var(--el-border-color-light);
      border-right: none
    }

    .el-tabs--left.el-tabs--card .el-tabs__new-tab {
      float: none
    }

    .el-tabs--left.el-tabs--border-card .el-tabs__header.is-left {
      border-right: 1px solid var(--el-border-color)
    }

    .el-tabs--left.el-tabs--border-card .el-tabs__item.is-left {
      border: 1px solid transparent;
      margin: -1px 0 -1px -1px
    }

    .el-tabs--left.el-tabs--border-card .el-tabs__item.is-left.is-active {
      border-color: transparent;
      border-top-color: #d1dbe5;
      border-bottom-color: #d1dbe5
    }

    .el-tabs--right .el-tabs__header.is-right {
      float: right;
      margin-bottom: 0;
      margin-left: 10px
    }

    .el-tabs--right .el-tabs__nav-wrap.is-right {
      margin-left: -1px
    }

    .el-tabs--right .el-tabs__nav-wrap.is-right::after {
      left: 0;
      right: auto
    }

    .el-tabs--right .el-tabs__active-bar.is-right {
      left: 0
    }

    .el-tabs--right.el-tabs--card .el-tabs__active-bar.is-right {
      display: none
    }

    .el-tabs--right.el-tabs--card .el-tabs__item.is-right {
      border-bottom: none;
      border-top: 1px solid var(--el-border-color-light)
    }

    .el-tabs--right.el-tabs--card .el-tabs__item.is-right:first-child {
      border-left: 1px solid var(--el-border-color-light);
      border-top: none
    }

    .el-tabs--right.el-tabs--card .el-tabs__item.is-right.is-active {
      border: 1px solid var(--el-border-color-light);
      border-left-color: #fff;
      border-right: none;
      border-bottom: none
    }

    .el-tabs--right.el-tabs--card .el-tabs__item.is-right.is-active:first-child {
      border-top: none
    }

    .el-tabs--right.el-tabs--card .el-tabs__item.is-right.is-active:last-child {
      border-bottom: none
    }

    .el-tabs--right.el-tabs--card .el-tabs__nav {
      border-radius: 0 4px 4px 0;
      border-bottom: 1px solid var(--el-border-color-light);
      border-left: none
    }

    .el-tabs--right.el-tabs--border-card .el-tabs__header.is-right {
      border-left: 1px solid var(--el-border-color)
    }

    .el-tabs--right.el-tabs--border-card .el-tabs__item.is-right {
      border: 1px solid transparent;
      margin: -1px -1px -1px 0
    }

    .el-tabs--right.el-tabs--border-card .el-tabs__item.is-right.is-active {
      border-color: transparent;
      border-top-color: #d1dbe5;
      border-bottom-color: #d1dbe5
    }

    .slideInLeft-transition,
    .slideInRight-transition {
      display: inline-block
    }

    .slideInRight-enter {
      -webkit-animation: slideInRight-enter var(--el-transition-duration);
      animation: slideInRight-enter var(--el-transition-duration)
    }

    .slideInRight-leave {
      position: absolute;
      left: 0;
      right: 0;
      -webkit-animation: slideInRight-leave var(--el-transition-duration);
      animation: slideInRight-leave var(--el-transition-duration)
    }

    .slideInLeft-enter {
      -webkit-animation: slideInLeft-enter var(--el-transition-duration);
      animation: slideInLeft-enter var(--el-transition-duration)
    }

    .slideInLeft-leave {
      position: absolute;
      left: 0;
      right: 0;
      -webkit-animation: slideInLeft-leave var(--el-transition-duration);
      animation: slideInLeft-leave var(--el-transition-duration)
    }

    @-webkit-keyframes slideInRight-enter {
      0% {
        opacity: 0;
        transform-origin: 0 0;
        transform: translateX(100%)
      }

      to {
        opacity: 1;
        transform-origin: 0 0;
        transform: translateX(0)
      }
    }

    @keyframes slideInRight-enter {
      0% {
        opacity: 0;
        transform-origin: 0 0;
        transform: translateX(100%)
      }

      to {
        opacity: 1;
        transform-origin: 0 0;
        transform: translateX(0)
      }
    }

    @-webkit-keyframes slideInRight-leave {
      0% {
        transform-origin: 0 0;
        transform: translateX(0);
        opacity: 1
      }

      100% {
        transform-origin: 0 0;
        transform: translateX(100%);
        opacity: 0
      }
    }

    @keyframes slideInRight-leave {
      0% {
        transform-origin: 0 0;
        transform: translateX(0);
        opacity: 1
      }

      100% {
        transform-origin: 0 0;
        transform: translateX(100%);
        opacity: 0
      }
    }

    @-webkit-keyframes slideInLeft-enter {
      0% {
        opacity: 0;
        transform-origin: 0 0;
        transform: translateX(-100%)
      }

      to {
        opacity: 1;
        transform-origin: 0 0;
        transform: translateX(0)
      }
    }

    @keyframes slideInLeft-enter {
      0% {
        opacity: 0;
        transform-origin: 0 0;
        transform: translateX(-100%)
      }

      to {
        opacity: 1;
        transform-origin: 0 0;
        transform: translateX(0)
      }
    }

    @-webkit-keyframes slideInLeft-leave {
      0% {
        transform-origin: 0 0;
        transform: translateX(0);
        opacity: 1
      }

      100% {
        transform-origin: 0 0;
        transform: translateX(-100%);
        opacity: 0
      }
    }

    @keyframes slideInLeft-leave {
      0% {
        transform-origin: 0 0;
        transform: translateX(0);
        opacity: 1
      }

      100% {
        transform-origin: 0 0;
        transform: translateX(-100%);
        opacity: 0
      }
    }

    .el-tag {
      --el-tag-font-size: 12px;
      --el-tag-border-radius: 4px;
      --el-tag-border-radius-rounded: 9999px
    }

    .el-tag {
      --el-tag-bg-color: var(--el-color-primary-light-9);
      --el-tag-border-color: var(--el-color-primary-light-8);
      --el-tag-hover-color: var(--el-color-primary);
      background-color: var(--el-tag-bg-color);
      border-color: var(--el-tag-border-color);
      color: var(--el-tag-text-color);
      display: inline-flex;
      justify-content: center;
      align-items: center;
      vertical-align: middle;
      height: 24px;
      padding: 0 9px;
      font-size: var(--el-tag-font-size);
      line-height: 1;
      border-width: 1px;
      border-style: solid;
      border-radius: var(--el-tag-border-radius);
      box-sizing: border-box;
      white-space: nowrap;
      --el-icon-size: 14px
    }

    .el-tag.el-tag--primary {
      --el-tag-bg-color: var(--el-color-primary-light-9);
      --el-tag-border-color: var(--el-color-primary-light-8);
      --el-tag-hover-color: var(--el-color-primary)
    }

    .el-tag.el-tag--success {
      --el-tag-bg-color: var(--el-color-success-light-9);
      --el-tag-border-color: var(--el-color-success-light-8);
      --el-tag-hover-color: var(--el-color-success)
    }

    .el-tag.el-tag--warning {
      --el-tag-bg-color: var(--el-color-warning-light-9);
      --el-tag-border-color: var(--el-color-warning-light-8);
      --el-tag-hover-color: var(--el-color-warning)
    }

    .el-tag.el-tag--danger {
      --el-tag-bg-color: var(--el-color-danger-light-9);
      --el-tag-border-color: var(--el-color-danger-light-8);
      --el-tag-hover-color: var(--el-color-danger)
    }

    .el-tag.el-tag--error {
      --el-tag-bg-color: var(--el-color-error-light-9);
      --el-tag-border-color: var(--el-color-error-light-8);
      --el-tag-hover-color: var(--el-color-error)
    }

    .el-tag.el-tag--info {
      --el-tag-bg-color: var(--el-color-info-light-9);
      --el-tag-border-color: var(--el-color-info-light-8);
      --el-tag-hover-color: var(--el-color-info)
    }

    .el-tag.el-tag--primary {
      --el-tag-text-color: var(--el-color-primary)
    }

    .el-tag.el-tag--success {
      --el-tag-text-color: var(--el-color-success)
    }

    .el-tag.el-tag--warning {
      --el-tag-text-color: var(--el-color-warning)
    }

    .el-tag.el-tag--danger {
      --el-tag-text-color: var(--el-color-danger)
    }

    .el-tag.el-tag--error {
      --el-tag-text-color: var(--el-color-error)
    }

    .el-tag.el-tag--info {
      --el-tag-text-color: var(--el-color-info)
    }

    .el-tag.is-hit {
      border-color: var(--el-color-primary)
    }

    .el-tag.is-round {
      border-radius: var(--el-tag-border-radius-rounded)
    }

    .el-tag .el-tag__close {
      flex-shrink: 0;
      color: var(--el-tag-text-color)
    }

    .el-tag .el-tag__close:hover {
      color: var(--el-color-white);
      background-color: var(--el-tag-hover-color)
    }

    .el-tag .el-icon {
      border-radius: 50%;
      cursor: pointer;
      font-size: calc(var(--el-icon-size) - 2px);
      height: var(--el-icon-size);
      width: var(--el-icon-size)
    }

    .el-tag .el-tag__close {
      margin-left: 6px
    }

    .el-tag--dark {
      --el-tag-bg-color: var(--el-color-primary);
      --el-tag-border-color: var(--el-color-primary);
      --el-tag-hover-color: var(--el-color-primary-light-3);
      --el-tag-text-color: var(--el-color-white);
      --el-tag-text-color: var(--el-color-white)
    }

    .el-tag--dark.el-tag--primary {
      --el-tag-bg-color: var(--el-color-primary);
      --el-tag-border-color: var(--el-color-primary);
      --el-tag-hover-color: var(--el-color-primary-light-3)
    }

    .el-tag--dark.el-tag--success {
      --el-tag-bg-color: var(--el-color-success);
      --el-tag-border-color: var(--el-color-success);
      --el-tag-hover-color: var(--el-color-success-light-3)
    }

    .el-tag--dark.el-tag--warning {
      --el-tag-bg-color: var(--el-color-warning);
      --el-tag-border-color: var(--el-color-warning);
      --el-tag-hover-color: var(--el-color-warning-light-3)
    }

    .el-tag--dark.el-tag--danger {
      --el-tag-bg-color: var(--el-color-danger);
      --el-tag-border-color: var(--el-color-danger);
      --el-tag-hover-color: var(--el-color-danger-light-3)
    }

    .el-tag--dark.el-tag--error {
      --el-tag-bg-color: var(--el-color-error);
      --el-tag-border-color: var(--el-color-error);
      --el-tag-hover-color: var(--el-color-error-light-3)
    }

    .el-tag--dark.el-tag--info {
      --el-tag-bg-color: var(--el-color-info);
      --el-tag-border-color: var(--el-color-info);
      --el-tag-hover-color: var(--el-color-info-light-3)
    }

    .el-tag--dark.el-tag--primary {
      --el-tag-text-color: var(--el-color-white)
    }

    .el-tag--dark.el-tag--success {
      --el-tag-text-color: var(--el-color-white)
    }

    .el-tag--dark.el-tag--warning {
      --el-tag-text-color: var(--el-color-white)
    }

    .el-tag--dark.el-tag--danger {
      --el-tag-text-color: var(--el-color-white)
    }

    .el-tag--dark.el-tag--error {
      --el-tag-text-color: var(--el-color-white)
    }

    .el-tag--dark.el-tag--info {
      --el-tag-text-color: var(--el-color-white)
    }

    .el-tag--plain {
      --el-tag-bg-color: var(--el-fill-color-blank);
      --el-tag-border-color: var(--el-color-primary-light-5);
      --el-tag-hover-color: var(--el-color-primary);
      --el-tag-bg-color: var(--el-fill-color-blank)
    }

    .el-tag--plain.el-tag--primary {
      --el-tag-bg-color: var(--el-fill-color-blank);
      --el-tag-border-color: var(--el-color-primary-light-5);
      --el-tag-hover-color: var(--el-color-primary)
    }

    .el-tag--plain.el-tag--success {
      --el-tag-bg-color: var(--el-fill-color-blank);
      --el-tag-border-color: var(--el-color-success-light-5);
      --el-tag-hover-color: var(--el-color-success)
    }

    .el-tag--plain.el-tag--warning {
      --el-tag-bg-color: var(--el-fill-color-blank);
      --el-tag-border-color: var(--el-color-warning-light-5);
      --el-tag-hover-color: var(--el-color-warning)
    }

    .el-tag--plain.el-tag--danger {
      --el-tag-bg-color: var(--el-fill-color-blank);
      --el-tag-border-color: var(--el-color-danger-light-5);
      --el-tag-hover-color: var(--el-color-danger)
    }

    .el-tag--plain.el-tag--error {
      --el-tag-bg-color: var(--el-fill-color-blank);
      --el-tag-border-color: var(--el-color-error-light-5);
      --el-tag-hover-color: var(--el-color-error)
    }

    .el-tag--plain.el-tag--info {
      --el-tag-bg-color: var(--el-fill-color-blank);
      --el-tag-border-color: var(--el-color-info-light-5);
      --el-tag-hover-color: var(--el-color-info)
    }

    .el-tag.is-closable {
      padding-right: 5px
    }

    .el-tag--large {
      padding: 0 11px;
      height: 32px;
      --el-icon-size: 16px
    }

    .el-tag--large .el-tag__close {
      margin-left: 8px
    }

    .el-tag--large.is-closable {
      padding-right: 7px
    }

    .el-tag--small {
      padding: 0 7px;
      height: 20px;
      --el-icon-size: 12px
    }

    .el-tag--small .el-tag__close {
      margin-left: 4px
    }

    .el-tag--small.is-closable {
      padding-right: 3px
    }

    .el-tag--small .el-icon-close {
      transform: scale(.8)
    }

    .el-tag.el-tag--primary.is-hit {
      border-color: var(--el-color-primary)
    }

    .el-tag.el-tag--success.is-hit {
      border-color: var(--el-color-success)
    }

    .el-tag.el-tag--warning.is-hit {
      border-color: var(--el-color-warning)
    }

    .el-tag.el-tag--danger.is-hit {
      border-color: var(--el-color-danger)
    }

    .el-tag.el-tag--error.is-hit {
      border-color: var(--el-color-error)
    }

    .el-tag.el-tag--info.is-hit {
      border-color: var(--el-color-info)
    }

    .el-text {
      --el-text-font-size: var(--el-font-size-base);
      --el-text-color: var(--el-text-color-regular)
    }

    .el-text {
      align-self: center;
      margin: 0;
      padding: 0;
      font-size: var(--el-text-font-size);
      color: var(--el-text-color);
      overflow-wrap: break-word
    }

    .el-text.is-truncated {
      display: inline-block;
      max-width: 100%;
      text-overflow: ellipsis;
      white-space: nowrap;
      overflow: hidden
    }

    .el-text.is-line-clamp {
      display: -webkit-inline-box;
      -webkit-box-orient: vertical;
      overflow: hidden
    }

    .el-text--large {
      --el-text-font-size: var(--el-font-size-medium)
    }

    .el-text--default {
      --el-text-font-size: var(--el-font-size-base)
    }

    .el-text--small {
      --el-text-font-size: var(--el-font-size-extra-small)
    }

    .el-text.el-text--primary {
      --el-text-color: var(--el-color-primary)
    }

    .el-text.el-text--success {
      --el-text-color: var(--el-color-success)
    }

    .el-text.el-text--warning {
      --el-text-color: var(--el-color-warning)
    }

    .el-text.el-text--danger {
      --el-text-color: var(--el-color-danger)
    }

    .el-text.el-text--error {
      --el-text-color: var(--el-color-error)
    }

    .el-text.el-text--info {
      --el-text-color: var(--el-color-info)
    }

    .el-text>.el-icon {
      vertical-align: -2px
    }

    .time-select {
      margin: 5px 0;
      min-width: 0
    }

    .time-select .el-picker-panel__content {
      max-height: 200px;
      margin: 0
    }

    .time-select-item {
      padding: 8px 10px;
      font-size: 14px;
      line-height: 20px
    }

    .time-select-item.disabled {
      color: var(--el-datepicker-border-color);
      cursor: not-allowed
    }

    .time-select-item:hover {
      background-color: var(--el-fill-color-light);
      font-weight: 700;
      cursor: pointer
    }

    .time-select .time-select-item.selected:not(.disabled) {
      color: var(--el-color-primary);
      font-weight: 700
    }

    .el-timeline-item {
      position: relative;
      padding-bottom: 20px
    }

    .el-timeline-item__wrapper {
      position: relative;
      padding-left: 28px;
      top: -3px
    }

    .el-timeline-item__tail {
      position: absolute;
      left: 4px;
      height: 100%;
      border-left: 2px solid var(--el-timeline-node-color)
    }

    .el-timeline-item .el-timeline-item__icon {
      color: var(--el-color-white);
      font-size: var(--el-font-size-small)
    }

    .el-timeline-item__node {
      position: absolute;
      background-color: var(--el-timeline-node-color);
      border-color: var(--el-timeline-node-color);
      border-radius: 50%;
      box-sizing: border-box;
      display: flex;
      justify-content: center;
      align-items: center
    }

    .el-timeline-item__node--normal {
      left: -1px;
      width: var(--el-timeline-node-size-normal);
      height: var(--el-timeline-node-size-normal)
    }

    .el-timeline-item__node--large {
      left: -2px;
      width: var(--el-timeline-node-size-large);
      height: var(--el-timeline-node-size-large)
    }

    .el-timeline-item__node.is-hollow {
      background: var(--el-color-white);
      border-style: solid;
      border-width: 2px
    }

    .el-timeline-item__node--primary {
      background-color: var(--el-color-primary);
      border-color: var(--el-color-primary)
    }

    .el-timeline-item__node--success {
      background-color: var(--el-color-success);
      border-color: var(--el-color-success)
    }

    .el-timeline-item__node--warning {
      background-color: var(--el-color-warning);
      border-color: var(--el-color-warning)
    }

    .el-timeline-item__node--danger {
      background-color: var(--el-color-danger);
      border-color: var(--el-color-danger)
    }

    .el-timeline-item__node--info {
      background-color: var(--el-color-info);
      border-color: var(--el-color-info)
    }

    .el-timeline-item__dot {
      position: absolute;
      display: flex;
      justify-content: center;
      align-items: center
    }

    .el-timeline-item__content {
      color: var(--el-text-color-primary)
    }

    .el-timeline-item__timestamp {
      color: var(--el-text-color-secondary);
      line-height: 1;
      font-size: var(--el-font-size-small)
    }

    .el-timeline-item__timestamp.is-top {
      margin-bottom: 8px;
      padding-top: 4px
    }

    .el-timeline-item__timestamp.is-bottom {
      margin-top: 8px
    }

    .el-timeline {
      --el-timeline-node-size-normal: 12px;
      --el-timeline-node-size-large: 14px;
      --el-timeline-node-color: var(--el-border-color-light)
    }

    .el-timeline {
      margin: 0;
      font-size: var(--el-font-size-base);
      list-style: none
    }

    .el-timeline .el-timeline-item:last-child .el-timeline-item__tail {
      display: none
    }

    .el-timeline .el-timeline-item__center {
      display: flex;
      align-items: center
    }

    .el-timeline .el-timeline-item__center .el-timeline-item__wrapper {
      width: 100%
    }

    .el-timeline .el-timeline-item__center .el-timeline-item__tail {
      top: 0
    }

    .el-timeline .el-timeline-item__center:first-child .el-timeline-item__tail {
      height: calc(50% + 10px);
      top: calc(50% - 10px)
    }

    .el-timeline .el-timeline-item__center:last-child .el-timeline-item__tail {
      display: block;
      height: calc(50% - 10px)
    }

    .el-tooltip-v2__content {
      --el-tooltip-v2-padding: 5px 10px;
      --el-tooltip-v2-border-radius: 4px;
      --el-tooltip-v2-border-color: var(--el-border-color);
      border-radius: var(--el-tooltip-v2-border-radius);
      color: var(--el-color-black);
      background-color: var(--el-color-white);
      padding: var(--el-tooltip-v2-padding);
      border: 1px solid var(--el-border-color)
    }

    .el-tooltip-v2__arrow {
      position: absolute;
      color: var(--el-color-white);
      width: var(--el-tooltip-v2-arrow-width);
      height: var(--el-tooltip-v2-arrow-height);
      pointer-events: none;
      left: var(--el-tooltip-v2-arrow-x);
      top: var(--el-tooltip-v2-arrow-y)
    }

    .el-tooltip-v2__arrow::before {
      content: """";
      width: 0;
      height: 0;
      border: var(--el-tooltip-v2-arrow-border-width) solid transparent;
      position: absolute
    }

    .el-tooltip-v2__arrow::after {
      content: """";
      width: 0;
      height: 0;
      border: var(--el-tooltip-v2-arrow-border-width) solid transparent;
      position: absolute
    }

    .el-tooltip-v2__content[data-side^=top] .el-tooltip-v2__arrow {
      bottom: 0
    }

    .el-tooltip-v2__content[data-side^=top] .el-tooltip-v2__arrow::before {
      border-top-color: var(--el-color-white);
      border-top-width: var(--el-tooltip-v2-arrow-border-width);
      border-bottom: 0;
      top: calc(100% - 1px)
    }

    .el-tooltip-v2__content[data-side^=top] .el-tooltip-v2__arrow::after {
      border-top-color: var(--el-border-color);
      border-top-width: var(--el-tooltip-v2-arrow-border-width);
      border-bottom: 0;
      top: 100%;
      z-index: -1
    }

    .el-tooltip-v2__content[data-side^=bottom] .el-tooltip-v2__arrow {
      top: 0
    }

    .el-tooltip-v2__content[data-side^=bottom] .el-tooltip-v2__arrow::before {
      border-bottom-color: var(--el-color-white);
      border-bottom-width: var(--el-tooltip-v2-arrow-border-width);
      border-top: 0;
      bottom: calc(100% - 1px)
    }

    .el-tooltip-v2__content[data-side^=bottom] .el-tooltip-v2__arrow::after {
      border-bottom-color: var(--el-border-color);
      border-bottom-width: var(--el-tooltip-v2-arrow-border-width);
      border-top: 0;
      bottom: 100%;
      z-index: -1
    }

    .el-tooltip-v2__content[data-side^=left] .el-tooltip-v2__arrow {
      right: 0
    }

    .el-tooltip-v2__content[data-side^=left] .el-tooltip-v2__arrow::before {
      border-left-color: var(--el-color-white);
      border-left-width: var(--el-tooltip-v2-arrow-border-width);
      border-right: 0;
      left: calc(100% - 1px)
    }

    .el-tooltip-v2__content[data-side^=left] .el-tooltip-v2__arrow::after {
      border-left-color: var(--el-border-color);
      border-left-width: var(--el-tooltip-v2-arrow-border-width);
      border-right: 0;
      left: 100%;
      z-index: -1
    }

    .el-tooltip-v2__content[data-side^=right] .el-tooltip-v2__arrow {
      left: 0
    }

    .el-tooltip-v2__content[data-side^=right] .el-tooltip-v2__arrow::before {
      border-right-color: var(--el-color-white);
      border-right-width: var(--el-tooltip-v2-arrow-border-width);
      border-left: 0;
      right: calc(100% - 1px)
    }

    .el-tooltip-v2__content[data-side^=right] .el-tooltip-v2__arrow::after {
      border-right-color: var(--el-border-color);
      border-right-width: var(--el-tooltip-v2-arrow-border-width);
      border-left: 0;
      right: 100%;
      z-index: -1
    }

    .el-tooltip-v2__content.is-dark {
      --el-tooltip-v2-border-color: transparent;
      background-color: var(--el-color-black);
      color: var(--el-color-white);
      border-color: transparent
    }

    .el-tooltip-v2__content.is-dark .el-tooltip-v2__arrow {
      background-color: var(--el-color-black);
      border-color: transparent
    }

    .el-transfer {
      --el-transfer-border-color: var(--el-border-color-lighter);
      --el-transfer-border-radius: var(--el-border-radius-base);
      --el-transfer-panel-width: 200px;
      --el-transfer-panel-header-height: 40px;
      --el-transfer-panel-header-bg-color: var(--el-fill-color-light);
      --el-transfer-panel-footer-height: 40px;
      --el-transfer-panel-body-height: 278px;
      --el-transfer-item-height: 30px;
      --el-transfer-filter-height: 32px
    }

    .el-transfer {
      font-size: var(--el-font-size-base)
    }

    .el-transfer__buttons {
      display: inline-block;
      vertical-align: middle;
      padding: 0 30px
    }

    .el-transfer__button {
      vertical-align: top
    }

    .el-transfer__button:nth-child(2) {
      margin: 0 0 0 10px
    }

    .el-transfer__button i,
    .el-transfer__button span {
      font-size: 14px
    }

    .el-transfer__button .el-icon+span {
      margin-left: 0
    }

    .el-transfer-panel {
      overflow: hidden;
      background: var(--el-bg-color-overlay);
      display: inline-block;
      text-align: left;
      vertical-align: middle;
      width: var(--el-transfer-panel-width);
      max-height: 100%;
      box-sizing: border-box;
      position: relative
    }

    .el-transfer-panel__body {
      height: var(--el-transfer-panel-body-height);
      border-left: 1px solid var(--el-transfer-border-color);
      border-right: 1px solid var(--el-transfer-border-color);
      border-bottom: 1px solid var(--el-transfer-border-color);
      border-bottom-left-radius: var(--el-transfer-border-radius);
      border-bottom-right-radius: var(--el-transfer-border-radius);
      overflow: hidden
    }

    .el-transfer-panel__body.is-with-footer {
      border-bottom: none;
      border-bottom-left-radius: 0;
      border-bottom-right-radius: 0
    }

    .el-transfer-panel__list {
      margin: 0;
      padding: 6px 0;
      list-style: none;
      height: var(--el-transfer-panel-body-height);
      overflow: auto;
      box-sizing: border-box
    }

    .el-transfer-panel__list.is-filterable {
      height: calc(100% - var(--el-transfer-filter-height) - 30px);
      padding-top: 0
    }

    .el-transfer-panel__item {
      height: var(--el-transfer-item-height);
      line-height: var(--el-transfer-item-height);
      padding-left: 15px;
      display: block !important
    }

    .el-transfer-panel__item+.el-transfer-panel__item {
      margin-left: 0
    }

    .el-transfer-panel__item.el-checkbox {
      color: var(--el-text-color-regular)
    }

    .el-transfer-panel__item:hover {
      color: var(--el-color-primary)
    }

    .el-transfer-panel__item.el-checkbox .el-checkbox__label {
      width: 100%;
      overflow: hidden;
      text-overflow: ellipsis;
      white-space: nowrap;
      display: block;
      box-sizing: border-box;
      padding-left: 22px;
      line-height: var(--el-transfer-item-height)
    }

    .el-transfer-panel__item .el-checkbox__input {
      position: absolute;
      top: 8px
    }

    .el-transfer-panel__filter {
      text-align: center;
      padding: 15px;
      box-sizing: border-box
    }

    .el-transfer-panel__filter .el-input__inner {
      height: var(--el-transfer-filter-height);
      width: 100%;
      font-size: 12px;
      display: inline-block;
      box-sizing: border-box;
      border-radius: calc(var(--el-transfer-filter-height)/ 2)
    }

    .el-transfer-panel__filter .el-icon-circle-close {
      cursor: pointer
    }

    .el-transfer-panel .el-transfer-panel__header {
      display: flex;
      align-items: center;
      height: var(--el-transfer-panel-header-height);
      background: var(--el-transfer-panel-header-bg-color);
      margin: 0;
      padding-left: 15px;
      border: 1px solid var(--el-transfer-border-color);
      border-top-left-radius: var(--el-transfer-border-radius);
      border-top-right-radius: var(--el-transfer-border-radius);
      box-sizing: border-box;
      color: var(--el-color-black)
    }

    .el-transfer-panel .el-transfer-panel__header .el-checkbox {
      position: relative;
      display: flex;
      width: 100%;
      align-items: center
    }

    .el-transfer-panel .el-transfer-panel__header .el-checkbox .el-checkbox__label {
      font-size: 16px;
      color: var(--el-text-color-primary);
      font-weight: 400
    }

    .el-transfer-panel .el-transfer-panel__header .el-checkbox .el-checkbox__label span {
      position: absolute;
      right: 15px;
      top: 50%;
      transform: translate3d(0, -50%, 0);
      color: var(--el-text-color-secondary);
      font-size: 12px;
      font-weight: 400
    }

    .el-transfer-panel .el-transfer-panel__footer {
      height: var(--el-transfer-panel-footer-height);
      background: var(--el-bg-color-overlay);
      margin: 0;
      padding: 0;
      border: 1px solid var(--el-transfer-border-color);
      border-bottom-left-radius: var(--el-transfer-border-radius);
      border-bottom-right-radius: var(--el-transfer-border-radius)
    }

    .el-transfer-panel .el-transfer-panel__footer::after {
      display: inline-block;
      content: """";
      height: 100%;
      vertical-align: middle
    }

    .el-transfer-panel .el-transfer-panel__footer .el-checkbox {
      padding-left: 20px;
      color: var(--el-text-color-regular)
    }

    .el-transfer-panel .el-transfer-panel__empty {
      margin: 0;
      height: var(--el-transfer-item-height);
      line-height: var(--el-transfer-item-height);
      padding: 6px 15px 0;
      color: var(--el-text-color-secondary);
      text-align: center
    }

    .el-transfer-panel .el-checkbox__label {
      padding-left: 8px
    }

    .el-transfer-panel .el-checkbox__inner {
      height: 14px;
      width: 14px;
      border-radius: 3px
    }

    .el-transfer-panel .el-checkbox__inner::after {
      height: 6px;
      width: 3px;
      left: 4px
    }

    .el-tree {
      --el-tree-node-content-height: 26px;
      --el-tree-node-hover-bg-color: var(--el-fill-color-light);
      --el-tree-text-color: var(--el-text-color-regular);
      --el-tree-expand-icon-color: var(--el-text-color-placeholder)
    }

    .el-tree {
      position: relative;
      cursor: default;
      background: var(--el-fill-color-blank);
      color: var(--el-tree-text-color);
      font-size: var(--el-font-size-base)
    }

    .el-tree__empty-block {
      position: relative;
      min-height: 60px;
      text-align: center;
      width: 100%;
      height: 100%
    }

    .el-tree__empty-text {
      position: absolute;
      left: 50%;
      top: 50%;
      transform: translate(-50%, -50%);
      color: var(--el-text-color-secondary);
      font-size: var(--el-font-size-base)
    }

    .el-tree__drop-indicator {
      position: absolute;
      left: 0;
      right: 0;
      height: 1px;
      background-color: var(--el-color-primary)
    }

    .el-tree-node {
      white-space: nowrap;
      outline: 0
    }

    .el-tree-node:focus>.el-tree-node__content {
      background-color: var(--el-tree-node-hover-bg-color)
    }

    .el-tree-node.is-drop-inner>.el-tree-node__content .el-tree-node__label {
      background-color: var(--el-color-primary);
      color: #fff
    }

    .el-tree-node__content {
      --el-checkbox-height: var(--el-tree-node-content-height);
      display: flex;
      align-items: center;
      height: var(--el-tree-node-content-height);
      cursor: pointer
    }

    .el-tree-node__content>.el-tree-node__expand-icon {
      padding: 6px;
      box-sizing: content-box
    }

    .el-tree-node__content>label.el-checkbox {
      margin-right: 8px
    }

    .el-tree-node__content:hover {
      background-color: var(--el-tree-node-hover-bg-color)
    }

    .el-tree.is-dragging .el-tree-node__content {
      cursor: move
    }

    .el-tree.is-dragging .el-tree-node__content * {
      pointer-events: none
    }

    .el-tree.is-dragging.is-drop-not-allow .el-tree-node__content {
      cursor: not-allowed
    }

    .el-tree-node__expand-icon {
      cursor: pointer;
      color: var(--el-tree-expand-icon-color);
      font-size: 12px;
      transform: rotate(0);
      transition: transform var(--el-transition-duration) ease-in-out
    }

    .el-tree-node__expand-icon.expanded {
      transform: rotate(90deg)
    }

    .el-tree-node__expand-icon.is-leaf {
      color: transparent;
      cursor: default;
      visibility: hidden
    }

    .el-tree-node__expand-icon.is-hidden {
      visibility: hidden
    }

    .el-tree-node__loading-icon {
      margin-right: 8px;
      font-size: var(--el-font-size-base);
      color: var(--el-tree-expand-icon-color)
    }

    .el-tree-node>.el-tree-node__children {
      overflow: hidden;
      background-color: transparent
    }

    .el-tree-node.is-expanded>.el-tree-node__children {
      display: block
    }

    .el-tree--highlight-current .el-tree-node.is-current>.el-tree-node__content {
      background-color: var(--el-color-primary-light-9)
    }

    .el-tree-select {
      --el-tree-node-content-height: 26px;
      --el-tree-node-hover-bg-color: var(--el-fill-color-light);
      --el-tree-text-color: var(--el-text-color-regular);
      --el-tree-expand-icon-color: var(--el-text-color-placeholder)
    }

    .el-tree-select__popper .el-tree-node__expand-icon {
      margin-left: 8px
    }

    .el-tree-select__popper .el-tree-node.is-checked>.el-tree-node__content .el-select-dropdown__item.selected::after {
      content: none
    }

    .el-tree-select__popper .el-select-dropdown__item {
      flex: 1;
      background: 0 0 !important;
      padding-left: 0;
      height: 20px;
      line-height: 20px
    }

    .el-upload {
      --el-upload-dragger-padding-horizontal: 40px;
      --el-upload-dragger-padding-vertical: 10px
    }

    .el-upload {
      display: inline-flex;
      justify-content: center;
      align-items: center;
      cursor: pointer;
      outline: 0
    }

    .el-upload__input {
      display: none
    }

    .el-upload__tip {
      font-size: 12px;
      color: var(--el-text-color-regular);
      margin-top: 7px
    }

    .el-upload iframe {
      position: absolute;
      z-index: -1;
      top: 0;
      left: 0;
      opacity: 0
    }

    .el-upload--picture-card {
      --el-upload-picture-card-size: 148px;
      background-color: var(--el-fill-color-lighter);
      border: 1px dashed var(--el-border-color-darker);
      border-radius: 6px;
      box-sizing: border-box;
      width: var(--el-upload-picture-card-size);
      height: var(--el-upload-picture-card-size);
      cursor: pointer;
      vertical-align: top;
      display: inline-flex;
      justify-content: center;
      align-items: center
    }

    .el-upload--picture-card>i {
      font-size: 28px;
      color: var(--el-text-color-secondary)
    }

    .el-upload--picture-card:hover {
      border-color: var(--el-color-primary);
      color: var(--el-color-primary)
    }

    .el-upload.is-drag {
      display: block
    }

    .el-upload:focus {
      border-color: var(--el-color-primary);
      color: var(--el-color-primary)
    }

    .el-upload:focus .el-upload-dragger {
      border-color: var(--el-color-primary)
    }

    .el-upload-dragger {
      padding: var(--el-upload-dragger-padding-horizontal) var(--el-upload-dragger-padding-vertical);
      background-color: var(--el-fill-color-blank);
      border: 1px dashed var(--el-border-color);
      border-radius: 6px;
      box-sizing: border-box;
      text-align: center;
      cursor: pointer;
      position: relative;
      overflow: hidden
    }

    .el-upload-dragger .el-icon--upload {
      font-size: 67px;
      color: var(--el-text-color-placeholder);
      margin-bottom: 16px;
      line-height: 50px
    }

    .el-upload-dragger+.el-upload__tip {
      text-align: center
    }

    .el-upload-dragger~.el-upload__files {
      border-top: var(--el-border);
      margin-top: 7px;
      padding-top: 5px
    }

    .el-upload-dragger .el-upload__text {
      color: var(--el-text-color-regular);
      font-size: 14px;
      text-align: center
    }

    .el-upload-dragger .el-upload__text em {
      color: var(--el-color-primary);
      font-style: normal
    }

    .el-upload-dragger:hover {
      border-color: var(--el-color-primary)
    }

    .el-upload-dragger.is-dragover {
      padding: calc(var(--el-upload-dragger-padding-horizontal) - 1px) calc(var(--el-upload-dragger-padding-vertical) - 1px);
      background-color: var(--el-color-primary-light-9);
      border: 2px dashed var(--el-color-primary)
    }

    .el-upload-list {
      margin: 10px 0 0;
      padding: 0;
      list-style: none;
      position: relative
    }

    .el-upload-list__item {
      transition: all .5s cubic-bezier(.55, 0, .1, 1);
      font-size: 14px;
      color: var(--el-text-color-regular);
      margin-bottom: 5px;
      position: relative;
      box-sizing: border-box;
      border-radius: 4px;
      width: 100%
    }

    .el-upload-list__item .el-progress {
      position: absolute;
      top: 20px;
      width: 100%
    }

    .el-upload-list__item .el-progress__text {
      position: absolute;
      right: 0;
      top: -13px
    }

    .el-upload-list__item .el-progress-bar {
      margin-right: 0;
      padding-right: 0
    }

    .el-upload-list__item .el-icon--upload-success {
      color: var(--el-color-success)
    }

    .el-upload-list__item .el-icon--close {
      display: none;
      position: absolute;
      right: 5px;
      top: 50%;
      cursor: pointer;
      opacity: .75;
      color: var(--el-text-color-regular);
      transition: opacity var(--el-transition-duration);
      transform: translateY(-50%)
    }

    .el-upload-list__item .el-icon--close:hover {
      opacity: 1;
      color: var(--el-color-primary)
    }

    .el-upload-list__item .el-icon--close-tip {
      display: none;
      position: absolute;
      top: 1px;
      right: 5px;
      font-size: 12px;
      cursor: pointer;
      opacity: 1;
      color: var(--el-color-primary);
      font-style: normal
    }

    .el-upload-list__item:hover {
      background-color: var(--el-fill-color-light)
    }

    .el-upload-list__item:hover .el-icon--close {
      display: inline-flex
    }

    .el-upload-list__item:hover .el-progress__text {
      display: none
    }

    .el-upload-list__item .el-upload-list__item-info {
      display: inline-flex;
      justify-content: center;
      flex-direction: column;
      width: calc(100% - 30px);
      margin-left: 4px
    }

    .el-upload-list__item.is-success .el-upload-list__item-status-label {
      display: inline-flex
    }

    .el-upload-list__item.is-success .el-upload-list__item-name:focus,
    .el-upload-list__item.is-success .el-upload-list__item-name:hover {
      color: var(--el-color-primary);
      cursor: pointer
    }

    .el-upload-list__item.is-success:focus:not(:hover) .el-icon--close-tip {
      display: inline-block
    }

    .el-upload-list__item.is-success:active,
    .el-upload-list__item.is-success:not(.focusing):focus {
      outline-width: 0
    }

    .el-upload-list__item.is-success:active .el-icon--close-tip,
    .el-upload-list__item.is-success:not(.focusing):focus .el-icon--close-tip {
      display: none
    }

    .el-upload-list__item.is-success:focus .el-upload-list__item-status-label,
    .el-upload-list__item.is-success:hover .el-upload-list__item-status-label {
      display: none;
      opacity: 0
    }

    .el-upload-list__item-name {
      color: var(--el-text-color-regular);
      display: inline-flex;
      text-align: center;
      align-items: center;
      padding: 0 4px;
      transition: color var(--el-transition-duration);
      font-size: var(--el-font-size-base)
    }

    .el-upload-list__item-name .el-icon {
      margin-right: 6px;
      color: var(--el-text-color-secondary)
    }

    .el-upload-list__item-file-name {
      overflow: hidden;
      text-overflow: ellipsis;
      white-space: nowrap
    }

    .el-upload-list__item-status-label {
      position: absolute;
      right: 5px;
      top: 0;
      line-height: inherit;
      display: none;
      height: 100%;
      justify-content: center;
      align-items: center;
      transition: opacity var(--el-transition-duration)
    }

    .el-upload-list__item-delete {
      position: absolute;
      right: 10px;
      top: 0;
      font-size: 12px;
      color: var(--el-text-color-regular);
      display: none
    }

    .el-upload-list__item-delete:hover {
      color: var(--el-color-primary)
    }

    .el-upload-list--picture-card {
      --el-upload-list-picture-card-size: 148px;
      display: inline-flex;
      flex-wrap: wrap;
      margin: 0
    }

    .el-upload-list--picture-card .el-upload-list__item {
      overflow: hidden;
      background-color: var(--el-fill-color-blank);
      border: 1px solid var(--el-border-color);
      border-radius: 6px;
      box-sizing: border-box;
      width: var(--el-upload-list-picture-card-size);
      height: var(--el-upload-list-picture-card-size);
      margin: 0 8px 8px 0;
      padding: 0;
      display: inline-flex
    }

    .el-upload-list--picture-card .el-upload-list__item .el-icon--check,
    .el-upload-list--picture-card .el-upload-list__item .el-icon--circle-check {
      color: #fff
    }

    .el-upload-list--picture-card .el-upload-list__item .el-icon--close {
      display: none
    }

    .el-upload-list--picture-card .el-upload-list__item:hover .el-upload-list__item-status-label {
      opacity: 0;
      display: block
    }

    .el-upload-list--picture-card .el-upload-list__item:hover .el-progress__text {
      display: block
    }

    .el-upload-list--picture-card .el-upload-list__item .el-upload-list__item-name {
      display: none
    }

    .el-upload-list--picture-card .el-upload-list__item-thumbnail {
      width: 100%;
      height: 100%;
      -o-object-fit: contain;
      object-fit: contain
    }

    .el-upload-list--picture-card .el-upload-list__item-status-label {
      right: -15px;
      top: -6px;
      width: 40px;
      height: 24px;
      background: var(--el-color-success);
      text-align: center;
      transform: rotate(45deg)
    }

    .el-upload-list--picture-card .el-upload-list__item-status-label i {
      font-size: 12px;
      margin-top: 11px;
      transform: rotate(-45deg)
    }

    .el-upload-list--picture-card .el-upload-list__item-actions {
      position: absolute;
      width: 100%;
      height: 100%;
      left: 0;
      top: 0;
      cursor: default;
      display: inline-flex;
      justify-content: center;
      align-items: center;
      color: #fff;
      opacity: 0;
      font-size: 20px;
      background-color: var(--el-overlay-color-lighter);
      transition: opacity var(--el-transition-duration)
    }

    .el-upload-list--picture-card .el-upload-list__item-actions span {
      display: none;
      cursor: pointer
    }

    .el-upload-list--picture-card .el-upload-list__item-actions span+span {
      margin-left: 1rem
    }

    .el-upload-list--picture-card .el-upload-list__item-actions .el-upload-list__item-delete {
      position: static;
      font-size: inherit;
      color: inherit
    }

    .el-upload-list--picture-card .el-upload-list__item-actions:hover {
      opacity: 1
    }

    .el-upload-list--picture-card .el-upload-list__item-actions:hover span {
      display: inline-flex
    }

    .el-upload-list--picture-card .el-progress {
      top: 50%;
      left: 50%;
      transform: translate(-50%, -50%);
      bottom: auto;
      width: 126px
    }

    .el-upload-list--picture-card .el-progress .el-progress__text {
      top: 50%
    }

    .el-upload-list--picture .el-upload-list__item {
      overflow: hidden;
      z-index: 0;
      background-color: var(--el-fill-color-blank);
      border: 1px solid var(--el-border-color);
      border-radius: 6px;
      box-sizing: border-box;
      margin-top: 10px;
      padding: 10px;
      display: flex;
      align-items: center
    }

    .el-upload-list--picture .el-upload-list__item .el-icon--check,
    .el-upload-list--picture .el-upload-list__item .el-icon--circle-check {
      color: #fff
    }

    .el-upload-list--picture .el-upload-list__item:hover .el-upload-list__item-status-label {
      opacity: 0;
      display: inline-flex
    }

    .el-upload-list--picture .el-upload-list__item:hover .el-progress__text {
      display: block
    }

    .el-upload-list--picture .el-upload-list__item.is-success .el-upload-list__item-name i {
      display: none
    }

    .el-upload-list--picture .el-upload-list__item .el-icon--close {
      top: 5px;
      transform: translateY(0)
    }

    .el-upload-list--picture .el-upload-list__item-thumbnail {
      display: inline-flex;
      justify-content: center;
      align-items: center;
      width: 70px;
      height: 70px;
      -o-object-fit: contain;
      object-fit: contain;
      position: relative;
      z-index: 1;
      background-color: var(--el-color-white)
    }

    .el-upload-list--picture .el-upload-list__item-status-label {
      position: absolute;
      right: -17px;
      top: -7px;
      width: 46px;
      height: 26px;
      background: var(--el-color-success);
      text-align: center;
      transform: rotate(45deg)
    }

    .el-upload-list--picture .el-upload-list__item-status-label i {
      font-size: 12px;
      margin-top: 12px;
      transform: rotate(-45deg)
    }

    .el-upload-list--picture .el-progress {
      position: relative;
      top: -7px
    }

    .el-upload-cover {
      position: absolute;
      left: 0;
      top: 0;
      width: 100%;
      height: 100%;
      overflow: hidden;
      z-index: 10;
      cursor: default
    }

    .el-upload-cover::after {
      display: inline-block;
      content: """";
      height: 100%;
      vertical-align: middle
    }

    .el-upload-cover img {
      display: block;
      width: 100%;
      height: 100%
    }

    .el-upload-cover__label {
      right: -15px;
      top: -6px;
      width: 40px;
      height: 24px;
      background: var(--el-color-success);
      text-align: center;
      transform: rotate(45deg)
    }

    .el-upload-cover__label i {
      font-size: 12px;
      margin-top: 11px;
      transform: rotate(-45deg);
      color: #fff
    }

    .el-upload-cover__progress {
      display: inline-block;
      vertical-align: middle;
      position: static;
      width: 243px
    }

    .el-upload-cover__progress+.el-upload__inner {
      opacity: 0
    }

    .el-upload-cover__content {
      position: absolute;
      top: 0;
      left: 0;
      width: 100%;
      height: 100%
    }

    .el-upload-cover__interact {
      position: absolute;
      bottom: 0;
      left: 0;
      width: 100%;
      height: 100%;
      background-color: var(--el-overlay-color-light);
      text-align: center
    }

    .el-upload-cover__interact .btn {
      display: inline-block;
      color: #fff;
      font-size: 14px;
      cursor: pointer;
      vertical-align: middle;
      transition: var(--el-transition-md-fade);
      margin-top: 60px
    }

    .el-upload-cover__interact .btn i {
      margin-top: 0
    }

    .el-upload-cover__interact .btn span {
      opacity: 0;
      transition: opacity .15s linear
    }

    .el-upload-cover__interact .btn:not(:first-child) {
      margin-left: 35px
    }

    .el-upload-cover__interact .btn:hover {
      transform: translateY(-13px)
    }

    .el-upload-cover__interact .btn:hover span {
      opacity: 1
    }

    .el-upload-cover__interact .btn i {
      color: #fff;
      display: block;
      font-size: 24px;
      line-height: inherit;
      margin: 0 auto 5px
    }

    .el-upload-cover__title {
      position: absolute;
      bottom: 0;
      left: 0;
      background-color: #fff;
      height: 36px;
      width: 100%;
      overflow: hidden;
      text-overflow: ellipsis;
      white-space: nowrap;
      font-weight: 400;
      text-align: left;
      padding: 0 10px;
      margin: 0;
      line-height: 36px;
      font-size: 14px;
      color: var(--el-text-color-primary)
    }

    .el-upload-cover+.el-upload__inner {
      opacity: 0;
      position: relative;
      z-index: 1
    }

    .el-vl__wrapper {
      position: relative
    }

    .el-vl__wrapper:hover .el-virtual-scrollbar {
      opacity: 1
    }

    .el-vl__wrapper.always-on .el-virtual-scrollbar {
      opacity: 1
    }

    .el-vl__window {
      scrollbar-width: none
    }

    .el-vl__window::-webkit-scrollbar {
      display: none
    }

    .el-virtual-scrollbar {
      opacity: 0;
      transition: opacity 340ms ease-out
    }

    .el-virtual-scrollbar.always-on {
      opacity: 1
    }

    .el-vg__wrapper {
      position: relative
    }

    .el-popper {
      --el-popper-border-radius: var(--el-popover-border-radius, 4px)
    }

    .el-popper {
      position: absolute;
      border-radius: var(--el-popper-border-radius);
      padding: 5px 11px;
      z-index: 2000;
      font-size: 12px;
      line-height: 20px;
      min-width: 10px;
      overflow-wrap: break-word;
      visibility: visible
    }

    .el-popper.is-dark {
      color: var(--el-bg-color);
      background: var(--el-text-color-primary);
      border: 1px solid var(--el-text-color-primary)
    }

    .el-popper.is-dark .el-popper__arrow::before {
      border: 1px solid var(--el-text-color-primary);
      background: var(--el-text-color-primary);
      right: 0
    }

    .el-popper.is-light {
      background: var(--el-bg-color-overlay);
      border: 1px solid var(--el-border-color-light)
    }

    .el-popper.is-light .el-popper__arrow::before {
      border: 1px solid var(--el-border-color-light);
      background: var(--el-bg-color-overlay);
      right: 0
    }

    .el-popper.is-pure {
      padding: 0
    }

    .el-popper__arrow {
      position: absolute;
      width: 10px;
      height: 10px;
      z-index: -1
    }

    .el-popper__arrow::before {
      position: absolute;
      width: 10px;
      height: 10px;
      z-index: -1;
      content: "" "";
      transform: rotate(45deg);
      background: var(--el-text-color-primary);
      box-sizing: border-box
    }

    .el-popper[data-popper-placement^=top]>.el-popper__arrow {
      bottom: -5px
    }

    .el-popper[data-popper-placement^=top]>.el-popper__arrow::before {
      border-bottom-right-radius: 2px
    }

    .el-popper[data-popper-placement^=bottom]>.el-popper__arrow {
      top: -5px
    }

    .el-popper[data-popper-placement^=bottom]>.el-popper__arrow::before {
      border-top-left-radius: 2px
    }

    .el-popper[data-popper-placement^=left]>.el-popper__arrow {
      right: -5px
    }

    .el-popper[data-popper-placement^=left]>.el-popper__arrow::before {
      border-top-right-radius: 2px
    }

    .el-popper[data-popper-placement^=right]>.el-popper__arrow {
      left: -5px
    }

    .el-popper[data-popper-placement^=right]>.el-popper__arrow::before {
      border-bottom-left-radius: 2px
    }

    .el-popper[data-popper-placement^=top] .el-popper__arrow::before {
      border-top-color: transparent !important;
      border-left-color: transparent !important
    }

    .el-popper[data-popper-placement^=bottom] .el-popper__arrow::before {
      border-bottom-color: transparent !important;
      border-right-color: transparent !important
    }

    .el-popper[data-popper-placement^=left] .el-popper__arrow::before {
      border-left-color: transparent !important;
      border-bottom-color: transparent !important
    }

    .el-popper[data-popper-placement^=right] .el-popper__arrow::before {
      border-right-color: transparent !important;
      border-top-color: transparent !important
    }

    .el-statistic {
      --el-statistic-title-font-weight: 400;
      --el-statistic-title-font-size: var(--el-font-size-extra-small);
      --el-statistic-title-color: var(--el-text-color-regular);
      --el-statistic-content-font-weight: 400;
      --el-statistic-content-font-size: var(--el-font-size-extra-large);
      --el-statistic-content-color: var(--el-text-color-primary)
    }

    .el-statistic__head {
      font-weight: var(--el-statistic-title-font-weight);
      font-size: var(--el-statistic-title-font-size);
      color: var(--el-statistic-title-color);
      line-height: 20px;
      margin-bottom: 4px
    }

    .el-statistic__content {
      font-weight: var(--el-statistic-content-font-weight);
      font-size: var(--el-statistic-content-font-size);
      color: var(--el-statistic-content-color)
    }

    .el-statistic__value {
      display: inline-block
    }

    .el-statistic__prefix {
      margin-right: 4px;
      display: inline-block
    }

    .el-statistic__suffix {
      margin-left: 4px;
      display: inline-block
    }

    .el-tour {
      --el-tour-width: 520px;
      --el-tour-padding-primary: 12px;
      --el-tour-font-line-height: var(--el-font-line-height-primary);
      --el-tour-title-font-size: 16px;
      --el-tour-title-text-color: var(--el-text-color-primary);
      --el-tour-title-font-weight: 400;
      --el-tour-close-color: var(--el-color-info);
      --el-tour-font-size: 14px;
      --el-tour-color: var(--el-text-color-primary);
      --el-tour-bg-color: var(--el-bg-color);
      --el-tour-border-radius: 4px
    }

    .el-tour__hollow {
      transition: all var(--el-transition-duration) ease
    }

    .el-tour__content {
      border-radius: var(--el-tour-border-radius);
      width: var(--el-tour-width);
      padding: var(--el-tour-padding-primary);
      background: var(--el-tour-bg-color);
      box-shadow: var(--el-box-shadow-light);
      box-sizing: border-box;
      overflow-wrap: break-word
    }

    .el-tour__arrow {
      position: absolute;
      background: var(--el-tour-bg-color);
      width: 10px;
      height: 10px;
      pointer-events: none;
      transform: rotate(45deg);
      box-sizing: border-box
    }

    .el-tour__content[data-side^=top] .el-tour__arrow {
      border-top-color: transparent;
      border-left-color: transparent
    }

    .el-tour__content[data-side^=bottom] .el-tour__arrow {
      border-bottom-color: transparent;
      border-right-color: transparent
    }

    .el-tour__content[data-side^=left] .el-tour__arrow {
      border-left-color: transparent;
      border-bottom-color: transparent
    }

    .el-tour__content[data-side^=right] .el-tour__arrow {
      border-right-color: transparent;
      border-top-color: transparent
    }

    .el-tour__content[data-side^=top] .el-tour__arrow {
      bottom: -5px
    }

    .el-tour__content[data-side^=bottom] .el-tour__arrow {
      top: -5px
    }

    .el-tour__content[data-side^=left] .el-tour__arrow {
      right: -5px
    }

    .el-tour__content[data-side^=right] .el-tour__arrow {
      left: -5px
    }

    .el-tour__closebtn {
      position: absolute;
      top: 0;
      right: 0;
      padding: 0;
      width: 40px;
      height: 40px;
      background: 0 0;
      border: none;
      outline: 0;
      cursor: pointer;
      font-size: var(--el-message-close-size, 16px)
    }

    .el-tour__closebtn .el-tour__close {
      color: var(--el-tour-close-color);
      font-size: inherit
    }

    .el-tour__closebtn:focus .el-tour__close,
    .el-tour__closebtn:hover .el-tour__close {
      color: var(--el-color-primary)
    }

    .el-tour__header {
      padding-bottom: var(--el-tour-padding-primary)
    }

    .el-tour__header.show-close {
      padding-right: calc(var(--el-tour-padding-primary) + var(--el-message-close-size, 16px))
    }

    .el-tour__title {
      line-height: var(--el-tour-font-line-height);
      font-size: var(--el-tour-title-font-size);
      color: var(--el-tour-title-text-color);
      font-weight: var(--el-tour-title-font-weight)
    }

    .el-tour__body {
      color: var(--el-tour-text-color);
      font-size: var(--el-tour-font-size)
    }

    .el-tour__body img,
    .el-tour__body video {
      max-width: 100%
    }

    .el-tour__footer {
      padding-top: var(--el-tour-padding-primary);
      box-sizing: border-box;
      display: flex;
      justify-content: space-between
    }

    .el-tour__content .el-tour-indicators {
      display: inline-block;
      flex: 1
    }

    .el-tour__content .el-tour-indicator {
      width: 6px;
      height: 6px;
      display: inline-block;
      border-radius: 50%;
      background: var(--el-color-info-light-9);
      margin-right: 6px
    }

    .el-tour__content .el-tour-indicator.is-active {
      background: var(--el-color-primary)
    }

    .el-tour.el-tour--primary {
      --el-tour-title-text-color: #fff;
      --el-tour-text-color: #fff;
      --el-tour-bg-color: var(--el-color-primary);
      --el-tour-close-color: #fff
    }

    .el-tour.el-tour--primary .el-tour__closebtn:focus .el-tour__close,
    .el-tour.el-tour--primary .el-tour__closebtn:hover .el-tour__close {
      color: var(--el-tour-title-text-color)
    }

    .el-tour.el-tour--primary .el-button--default {
      color: var(--el-color-primary);
      border-color: var(--el-color-primary);
      background: #fff
    }

    .el-tour.el-tour--primary .el-button--primary {
      border-color: #fff
    }

    .el-tour.el-tour--primary .el-tour-indicator {
      background: rgba(255, 255, 255, .15)
    }

    .el-tour.el-tour--primary .el-tour-indicator.is-active {
      background: #fff
    }

    .el-tour-parent--hidden {
      overflow: hidden
    }
  </style>
  <style type=""text/css""
    data-vite-dev-id=""E:/code/test/ui/panda.net.web/node_modules/element-plus/theme-chalk/base.css"">
    @charset ""UTF-8"";

    :root {
      --el-color-white: #ffffff;
      --el-color-black: #000000;
      --el-color-primary-rgb: 64, 158, 255;
      --el-color-success-rgb: 103, 194, 58;
      --el-color-warning-rgb: 230, 162, 60;
      --el-color-danger-rgb: 245, 108, 108;
      --el-color-error-rgb: 245, 108, 108;
      --el-color-info-rgb: 144, 147, 153;
      --el-font-size-extra-large: 20px;
      --el-font-size-large: 18px;
      --el-font-size-medium: 16px;
      --el-font-size-base: 14px;
      --el-font-size-small: 13px;
      --el-font-size-extra-small: 12px;
      --el-font-family: 'Helvetica Neue', Helvetica, 'PingFang SC', 'Hiragino Sans GB', 'Microsoft YaHei', '微软雅黑', Arial, sans-serif;
      --el-font-weight-primary: 500;
      --el-font-line-height-primary: 24px;
      --el-index-normal: 1;
      --el-index-top: 1000;
      --el-index-popper: 2000;
      --el-border-radius-base: 4px;
      --el-border-radius-small: 2px;
      --el-border-radius-round: 20px;
      --el-border-radius-circle: 100%;
      --el-transition-duration: 0.3s;
      --el-transition-duration-fast: 0.2s;
      --el-transition-function-ease-in-out-bezier: cubic-bezier(0.645, 0.045, 0.355, 1);
      --el-transition-function-fast-bezier: cubic-bezier(0.23, 1, 0.32, 1);
      --el-transition-all: all var(--el-transition-duration) var(--el-transition-function-ease-in-out-bezier);
      --el-transition-fade: opacity var(--el-transition-duration) var(--el-transition-function-fast-bezier);
      --el-transition-md-fade: transform var(--el-transition-duration) var(--el-transition-function-fast-bezier), opacity var(--el-transition-duration) var(--el-transition-function-fast-bezier);
      --el-transition-fade-linear: opacity var(--el-transition-duration-fast) linear;
      --el-transition-border: border-color var(--el-transition-duration-fast) var(--el-transition-function-ease-in-out-bezier);
      --el-transition-box-shadow: box-shadow var(--el-transition-duration-fast) var(--el-transition-function-ease-in-out-bezier);
      --el-transition-color: color var(--el-transition-duration-fast) var(--el-transition-function-ease-in-out-bezier);
      --el-component-size-large: 40px;
      --el-component-size: 32px;
      --el-component-size-small: 24px
    }

    :root {
      color-scheme: light;
      --el-color-white: #ffffff;
      --el-color-black: #000000;
      --el-color-primary: #409eff;
      --el-color-primary-light-3: #79bbff;
      --el-color-primary-light-5: #a0cfff;
      --el-color-primary-light-7: #c6e2ff;
      --el-color-primary-light-8: #d9ecff;
      --el-color-primary-light-9: #ecf5ff;
      --el-color-primary-dark-2: #337ecc;
      --el-color-success: #67c23a;
      --el-color-success-light-3: #95d475;
      --el-color-success-light-5: #b3e19d;
      --el-color-success-light-7: #d1edc4;
      --el-color-success-light-8: #e1f3d8;
      --el-color-success-light-9: #f0f9eb;
      --el-color-success-dark-2: #529b2e;
      --el-color-warning: #e6a23c;
      --el-color-warning-light-3: #eebe77;
      --el-color-warning-light-5: #f3d19e;
      --el-color-warning-light-7: #f8e3c5;
      --el-color-warning-light-8: #faecd8;
      --el-color-warning-light-9: #fdf6ec;
      --el-color-warning-dark-2: #b88230;
      --el-color-danger: #f56c6c;
      --el-color-danger-light-3: #f89898;
      --el-color-danger-light-5: #fab6b6;
      --el-color-danger-light-7: #fcd3d3;
      --el-color-danger-light-8: #fde2e2;
      --el-color-danger-light-9: #fef0f0;
      --el-color-danger-dark-2: #c45656;
      --el-color-error: #f56c6c;
      --el-color-error-light-3: #f89898;
      --el-color-error-light-5: #fab6b6;
      --el-color-error-light-7: #fcd3d3;
      --el-color-error-light-8: #fde2e2;
      --el-color-error-light-9: #fef0f0;
      --el-color-error-dark-2: #c45656;
      --el-color-info: #909399;
      --el-color-info-light-3: #b1b3b8;
      --el-color-info-light-5: #c8c9cc;
      --el-color-info-light-7: #dedfe0;
      --el-color-info-light-8: #e9e9eb;
      --el-color-info-light-9: #f4f4f5;
      --el-color-info-dark-2: #73767a;
      --el-bg-color: #ffffff;
      --el-bg-color-page: #f2f3f5;
      --el-bg-color-overlay: #ffffff;
      --el-text-color-primary: #303133;
      --el-text-color-regular: #606266;
      --el-text-color-secondary: #909399;
      --el-text-color-placeholder: #a8abb2;
      --el-text-color-disabled: #c0c4cc;
      --el-border-color: #dcdfe6;
      --el-border-color-light: #e4e7ed;
      --el-border-color-lighter: #ebeef5;
      --el-border-color-extra-light: #f2f6fc;
      --el-border-color-dark: #d4d7de;
      --el-border-color-darker: #cdd0d6;
      --el-fill-color: #f0f2f5;
      --el-fill-color-light: #f5f7fa;
      --el-fill-color-lighter: #fafafa;
      --el-fill-color-extra-light: #fafcff;
      --el-fill-color-dark: #ebedf0;
      --el-fill-color-darker: #e6e8eb;
      --el-fill-color-blank: #ffffff;
      --el-box-shadow: 0px 12px 32px 4px rgba(0, 0, 0, 0.04), 0px 8px 20px rgba(0, 0, 0, 0.08);
      --el-box-shadow-light: 0px 0px 12px rgba(0, 0, 0, 0.12);
      --el-box-shadow-lighter: 0px 0px 6px rgba(0, 0, 0, 0.12);
      --el-box-shadow-dark: 0px 16px 48px 16px rgba(0, 0, 0, 0.08), 0px 12px 32px rgba(0, 0, 0, 0.12), 0px 8px 16px -8px rgba(0, 0, 0, 0.16);
      --el-disabled-bg-color: var(--el-fill-color-light);
      --el-disabled-text-color: var(--el-text-color-placeholder);
      --el-disabled-border-color: var(--el-border-color-light);
      --el-overlay-color: rgba(0, 0, 0, 0.8);
      --el-overlay-color-light: rgba(0, 0, 0, 0.7);
      --el-overlay-color-lighter: rgba(0, 0, 0, 0.5);
      --el-mask-color: rgba(255, 255, 255, 0.9);
      --el-mask-color-extra-light: rgba(255, 255, 255, 0.3);
      --el-border-width: 1px;
      --el-border-style: solid;
      --el-border-color-hover: var(--el-text-color-disabled);
      --el-border: var(--el-border-width) var(--el-border-style) var(--el-border-color);
      --el-svg-monochrome-grey: var(--el-border-color)
    }

    .fade-in-linear-enter-active,
    .fade-in-linear-leave-active {
      transition: var(--el-transition-fade-linear)
    }

    .fade-in-linear-enter-from,
    .fade-in-linear-leave-to {
      opacity: 0
    }

    .el-fade-in-linear-enter-active,
    .el-fade-in-linear-leave-active {
      transition: var(--el-transition-fade-linear)
    }

    .el-fade-in-linear-enter-from,
    .el-fade-in-linear-leave-to {
      opacity: 0
    }

    .el-fade-in-enter-active,
    .el-fade-in-leave-active {
      transition: all var(--el-transition-duration) cubic-bezier(.55, 0, .1, 1)
    }

    .el-fade-in-enter-from,
    .el-fade-in-leave-active {
      opacity: 0
    }

    .el-zoom-in-center-enter-active,
    .el-zoom-in-center-leave-active {
      transition: all var(--el-transition-duration) cubic-bezier(.55, 0, .1, 1)
    }

    .el-zoom-in-center-enter-from,
    .el-zoom-in-center-leave-active {
      opacity: 0;
      transform: scaleX(0)
    }

    .el-zoom-in-top-enter-active,
    .el-zoom-in-top-leave-active {
      opacity: 1;
      transform: scaleY(1);
      transition: var(--el-transition-md-fade);
      transform-origin: center top
    }

    .el-zoom-in-top-enter-active[data-popper-placement^=top],
    .el-zoom-in-top-leave-active[data-popper-placement^=top] {
      transform-origin: center bottom
    }

    .el-zoom-in-top-enter-from,
    .el-zoom-in-top-leave-active {
      opacity: 0;
      transform: scaleY(0)
    }

    .el-zoom-in-bottom-enter-active,
    .el-zoom-in-bottom-leave-active {
      opacity: 1;
      transform: scaleY(1);
      transition: var(--el-transition-md-fade);
      transform-origin: center bottom
    }

    .el-zoom-in-bottom-enter-from,
    .el-zoom-in-bottom-leave-active {
      opacity: 0;
      transform: scaleY(0)
    }

    .el-zoom-in-left-enter-active,
    .el-zoom-in-left-leave-active {
      opacity: 1;
      transform: scale(1, 1);
      transition: var(--el-transition-md-fade);
      transform-origin: top left
    }

    .el-zoom-in-left-enter-from,
    .el-zoom-in-left-leave-active {
      opacity: 0;
      transform: scale(.45, .45)
    }

    .collapse-transition {
      transition: var(--el-transition-duration) height ease-in-out, var(--el-transition-duration) padding-top ease-in-out, var(--el-transition-duration) padding-bottom ease-in-out
    }

    .el-collapse-transition-enter-active,
    .el-collapse-transition-leave-active {
      transition: var(--el-transition-duration) max-height ease-in-out, var(--el-transition-duration) padding-top ease-in-out, var(--el-transition-duration) padding-bottom ease-in-out
    }

    .horizontal-collapse-transition {
      transition: var(--el-transition-duration) width ease-in-out, var(--el-transition-duration) padding-left ease-in-out, var(--el-transition-duration) padding-right ease-in-out
    }

    .el-list-enter-active,
    .el-list-leave-active {
      transition: all 1s
    }

    .el-list-enter-from,
    .el-list-leave-to {
      opacity: 0;
      transform: translateY(-30px)
    }

    .el-list-leave-active {
      position: absolute !important
    }

    .el-opacity-transition {
      transition: opacity var(--el-transition-duration) cubic-bezier(.55, 0, .1, 1)
    }

    .el-icon-loading {
      -webkit-animation: rotating 2s linear infinite;
      animation: rotating 2s linear infinite
    }

    .el-icon--right {
      margin-left: 5px
    }

    .el-icon--left {
      margin-right: 5px
    }

    @-webkit-keyframes rotating {
      0% {
        transform: rotateZ(0)
      }

      100% {
        transform: rotateZ(360deg)
      }
    }

    @keyframes rotating {
      0% {
        transform: rotateZ(0)
      }

      100% {
        transform: rotateZ(360deg)
      }
    }

    .el-icon {
      --color: inherit;
      height: 1em;
      width: 1em;
      line-height: 1em;
      display: inline-flex;
      justify-content: center;
      align-items: center;
      position: relative;
      fill: currentColor;
      color: var(--color);
      font-size: inherit
    }

    .el-icon.is-loading {
      -webkit-animation: rotating 2s linear infinite;
      animation: rotating 2s linear infinite
    }

    .el-icon svg {
      height: 1em;
      width: 1em
    }
  </style>
  <style type=""text/css""
    data-vite-dev-id=""E:/code/test/ui/panda.net.web/node_modules/element-plus/theme-chalk/el-row.css"">
    .el-row {
      display: flex;
      flex-wrap: wrap;
      position: relative;
      box-sizing: border-box
    }

    .el-row.is-justify-center {
      justify-content: center
    }

    .el-row.is-justify-end {
      justify-content: flex-end
    }

    .el-row.is-justify-space-between {
      justify-content: space-between
    }

    .el-row.is-justify-space-around {
      justify-content: space-around
    }

    .el-row.is-justify-space-evenly {
      justify-content: space-evenly
    }

    .el-row.is-align-top {
      align-items: flex-start
    }

    .el-row.is-align-middle {
      align-items: center
    }

    .el-row.is-align-bottom {
      align-items: flex-end
    }
  </style>
  <style type=""text/css""
    data-vite-dev-id=""E:/code/test/ui/panda.net.web/node_modules/element-plus/theme-chalk/el-form.css"">
    .el-form {
      --el-form-label-font-size: var(--el-font-size-base);
      --el-form-inline-content-width: 220px
    }

    .el-form--label-left .el-form-item__label {
      justify-content: flex-start
    }

    .el-form--label-top .el-form-item {
      display: block
    }

    .el-form--label-top .el-form-item .el-form-item__label {
      display: block;
      height: auto;
      text-align: left;
      margin-bottom: 8px;
      line-height: 22px
    }

    .el-form--inline .el-form-item {
      display: inline-flex;
      vertical-align: middle;
      margin-right: 32px
    }

    .el-form--inline.el-form--label-top {
      display: flex;
      flex-wrap: wrap
    }

    .el-form--inline.el-form--label-top .el-form-item {
      display: block
    }

    .el-form--large.el-form--label-top .el-form-item .el-form-item__label {
      margin-bottom: 12px;
      line-height: 22px
    }

    .el-form--default.el-form--label-top .el-form-item .el-form-item__label {
      margin-bottom: 8px;
      line-height: 22px
    }

    .el-form--small.el-form--label-top .el-form-item .el-form-item__label {
      margin-bottom: 4px;
      line-height: 20px
    }

    .el-form-item {
      display: flex;
      --font-size: 14px;
      margin-bottom: 18px
    }

    .el-form-item .el-form-item {
      margin-bottom: 0
    }

    .el-form-item .el-input__validateIcon {
      display: none
    }

    .el-form-item--large {
      --font-size: 14px;
      --el-form-label-font-size: var(--font-size);
      margin-bottom: 22px
    }

    .el-form-item--large .el-form-item__label {
      height: 40px;
      line-height: 40px
    }

    .el-form-item--large .el-form-item__content {
      line-height: 40px
    }

    .el-form-item--large .el-form-item__error {
      padding-top: 4px
    }

    .el-form-item--default {
      --font-size: 14px;
      --el-form-label-font-size: var(--font-size);
      margin-bottom: 18px
    }

    .el-form-item--default .el-form-item__label {
      height: 32px;
      line-height: 32px
    }

    .el-form-item--default .el-form-item__content {
      line-height: 32px
    }

    .el-form-item--default .el-form-item__error {
      padding-top: 2px
    }

    .el-form-item--small {
      --font-size: 12px;
      --el-form-label-font-size: var(--font-size);
      margin-bottom: 18px
    }

    .el-form-item--small .el-form-item__label {
      height: 24px;
      line-height: 24px
    }

    .el-form-item--small .el-form-item__content {
      line-height: 24px
    }

    .el-form-item--small .el-form-item__error {
      padding-top: 2px
    }

    .el-form-item__label-wrap {
      display: flex
    }

    .el-form-item__label {
      display: inline-flex;
      justify-content: flex-end;
      align-items: flex-start;
      flex: 0 0 auto;
      font-size: var(--el-form-label-font-size);
      color: var(--el-text-color-regular);
      height: 32px;
      line-height: 32px;
      padding: 0 12px 0 0;
      box-sizing: border-box
    }

    .el-form-item__content {
      display: flex;
      flex-wrap: wrap;
      align-items: center;
      flex: 1;
      line-height: 32px;
      position: relative;
      font-size: var(--font-size);
      min-width: 0
    }

    .el-form-item__content .el-input-group {
      vertical-align: top
    }

    .el-form-item__error {
      color: var(--el-color-danger);
      font-size: 12px;
      line-height: 1;
      padding-top: 2px;
      position: absolute;
      top: 100%;
      left: 0
    }

    .el-form-item__error--inline {
      position: relative;
      top: auto;
      left: auto;
      display: inline-block;
      margin-left: 10px
    }

    .el-form-item.is-required:not(.is-no-asterisk).asterisk-left>.el-form-item__label-wrap>.el-form-item__label:before,
    .el-form-item.is-required:not(.is-no-asterisk).asterisk-left>.el-form-item__label:before {
      content: ""*"";
      color: var(--el-color-danger);
      margin-right: 4px
    }

    .el-form-item.is-required:not(.is-no-asterisk).asterisk-right>.el-form-item__label-wrap>.el-form-item__label:after,
    .el-form-item.is-required:not(.is-no-asterisk).asterisk-right>.el-form-item__label:after {
      content: ""*"";
      color: var(--el-color-danger);
      margin-left: 4px
    }

    .el-form-item.is-error .el-input__wrapper,
    .el-form-item.is-error .el-input__wrapper.is-focus,
    .el-form-item.is-error .el-input__wrapper:focus,
    .el-form-item.is-error .el-input__wrapper:hover,
    .el-form-item.is-error .el-select__wrapper,
    .el-form-item.is-error .el-select__wrapper.is-focus,
    .el-form-item.is-error .el-select__wrapper:focus,
    .el-form-item.is-error .el-select__wrapper:hover,
    .el-form-item.is-error .el-textarea__inner,
    .el-form-item.is-error .el-textarea__inner.is-focus,
    .el-form-item.is-error .el-textarea__inner:focus,
    .el-form-item.is-error .el-textarea__inner:hover {
      box-shadow: 0 0 0 1px var(--el-color-danger) inset
    }

    .el-form-item.is-error .el-input-group__append .el-input__wrapper,
    .el-form-item.is-error .el-input-group__prepend .el-input__wrapper {
      box-shadow: 0 0 0 1px transparent inset
    }

    .el-form-item.is-error .el-input__validateIcon {
      color: var(--el-color-danger)
    }

    .el-form-item--feedback .el-input__validateIcon {
      display: inline-flex
    }
  </style>
  <style type=""text/css""
    data-vite-dev-id=""E:/code/test/ui/panda.net.web/node_modules/element-plus/theme-chalk/el-button.css"">
    .el-button {
      --el-button-font-weight: var(--el-font-weight-primary);
      --el-button-border-color: var(--el-border-color);
      --el-button-bg-color: var(--el-fill-color-blank);
      --el-button-text-color: var(--el-text-color-regular);
      --el-button-disabled-text-color: var(--el-disabled-text-color);
      --el-button-disabled-bg-color: var(--el-fill-color-blank);
      --el-button-disabled-border-color: var(--el-border-color-light);
      --el-button-divide-border-color: rgba(255, 255, 255, 0.5);
      --el-button-hover-text-color: var(--el-color-primary);
      --el-button-hover-bg-color: var(--el-color-primary-light-9);
      --el-button-hover-border-color: var(--el-color-primary-light-7);
      --el-button-active-text-color: var(--el-button-hover-text-color);
      --el-button-active-border-color: var(--el-color-primary);
      --el-button-active-bg-color: var(--el-button-hover-bg-color);
      --el-button-outline-color: var(--el-color-primary-light-5);
      --el-button-hover-link-text-color: var(--el-color-info);
      --el-button-active-color: var(--el-text-color-primary)
    }

    .el-button {
      display: inline-flex;
      justify-content: center;
      align-items: center;
      line-height: 1;
      height: 32px;
      white-space: nowrap;
      cursor: pointer;
      color: var(--el-button-text-color);
      text-align: center;
      box-sizing: border-box;
      outline: 0;
      transition: .1s;
      font-weight: var(--el-button-font-weight);
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
      vertical-align: middle;
      -webkit-appearance: none;
      background-color: var(--el-button-bg-color);
      border: var(--el-border);
      border-color: var(--el-button-border-color);
      padding: 8px 15px;
      font-size: var(--el-font-size-base);
      border-radius: var(--el-border-radius-base)
    }

    .el-button:focus,
    .el-button:hover {
      color: var(--el-button-hover-text-color);
      border-color: var(--el-button-hover-border-color);
      background-color: var(--el-button-hover-bg-color);
      outline: 0
    }

    .el-button:active {
      color: var(--el-button-active-text-color);
      border-color: var(--el-button-active-border-color);
      background-color: var(--el-button-active-bg-color);
      outline: 0
    }

    .el-button:focus-visible {
      outline: 2px solid var(--el-button-outline-color);
      outline-offset: 1px
    }

    .el-button>span {
      display: inline-flex;
      align-items: center
    }

    .el-button+.el-button {
      margin-left: 12px
    }

    .el-button.is-round {
      padding: 8px 15px
    }

    .el-button::-moz-focus-inner {
      border: 0
    }

    .el-button [class*=el-icon]+span {
      margin-left: 6px
    }

    .el-button [class*=el-icon] svg {
      vertical-align: bottom
    }

    .el-button.is-plain {
      --el-button-hover-text-color: var(--el-color-primary);
      --el-button-hover-bg-color: var(--el-fill-color-blank);
      --el-button-hover-border-color: var(--el-color-primary)
    }

    .el-button.is-active {
      color: var(--el-button-active-text-color);
      border-color: var(--el-button-active-border-color);
      background-color: var(--el-button-active-bg-color);
      outline: 0
    }

    .el-button.is-disabled,
    .el-button.is-disabled:focus,
    .el-button.is-disabled:hover {
      color: var(--el-button-disabled-text-color);
      cursor: not-allowed;
      background-image: none;
      background-color: var(--el-button-disabled-bg-color);
      border-color: var(--el-button-disabled-border-color)
    }

    .el-button.is-loading {
      position: relative;
      pointer-events: none
    }

    .el-button.is-loading:before {
      z-index: 1;
      pointer-events: none;
      content: """";
      position: absolute;
      left: -1px;
      top: -1px;
      right: -1px;
      bottom: -1px;
      border-radius: inherit;
      background-color: var(--el-mask-color-extra-light)
    }

    .el-button.is-round {
      border-radius: var(--el-border-radius-round)
    }

    .el-button.is-circle {
      width: 32px;
      border-radius: 50%;
      padding: 8px
    }

    .el-button.is-text {
      color: var(--el-button-text-color);
      border: 0 solid transparent;
      background-color: transparent
    }

    .el-button.is-text.is-disabled {
      color: var(--el-button-disabled-text-color);
      background-color: transparent !important
    }

    .el-button.is-text:not(.is-disabled):focus,
    .el-button.is-text:not(.is-disabled):hover {
      background-color: var(--el-fill-color-light)
    }

    .el-button.is-text:not(.is-disabled):focus-visible {
      outline: 2px solid var(--el-button-outline-color);
      outline-offset: 1px
    }

    .el-button.is-text:not(.is-disabled):active {
      background-color: var(--el-fill-color)
    }

    .el-button.is-text:not(.is-disabled).is-has-bg {
      background-color: var(--el-fill-color-light)
    }

    .el-button.is-text:not(.is-disabled).is-has-bg:focus,
    .el-button.is-text:not(.is-disabled).is-has-bg:hover {
      background-color: var(--el-fill-color)
    }

    .el-button.is-text:not(.is-disabled).is-has-bg:active {
      background-color: var(--el-fill-color-dark)
    }

    .el-button__text--expand {
      letter-spacing: .3em;
      margin-right: -.3em
    }

    .el-button.is-link {
      border-color: transparent;
      color: var(--el-button-text-color);
      background: 0 0;
      padding: 2px;
      height: auto
    }

    .el-button.is-link:focus,
    .el-button.is-link:hover {
      color: var(--el-button-hover-link-text-color)
    }

    .el-button.is-link.is-disabled {
      color: var(--el-button-disabled-text-color);
      background-color: transparent !important;
      border-color: transparent !important
    }

    .el-button.is-link:not(.is-disabled):focus,
    .el-button.is-link:not(.is-disabled):hover {
      border-color: transparent;
      background-color: transparent
    }

    .el-button.is-link:not(.is-disabled):active {
      color: var(--el-button-active-color);
      border-color: transparent;
      background-color: transparent
    }

    .el-button--text {
      border-color: transparent;
      background: 0 0;
      color: var(--el-color-primary);
      padding-left: 0;
      padding-right: 0
    }

    .el-button--text.is-disabled {
      color: var(--el-button-disabled-text-color);
      background-color: transparent !important;
      border-color: transparent !important
    }

    .el-button--text:not(.is-disabled):focus,
    .el-button--text:not(.is-disabled):hover {
      color: var(--el-color-primary-light-3);
      border-color: transparent;
      background-color: transparent
    }

    .el-button--text:not(.is-disabled):active {
      color: var(--el-color-primary-dark-2);
      border-color: transparent;
      background-color: transparent
    }

    .el-button__link--expand {
      letter-spacing: .3em;
      margin-right: -.3em
    }

    .el-button--primary {
      --el-button-text-color: var(--el-color-white);
      --el-button-bg-color: var(--el-color-primary);
      --el-button-border-color: var(--el-color-primary);
      --el-button-outline-color: var(--el-color-primary-light-5);
      --el-button-active-color: var(--el-color-primary-dark-2);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-link-text-color: var(--el-color-primary-light-5);
      --el-button-hover-bg-color: var(--el-color-primary-light-3);
      --el-button-hover-border-color: var(--el-color-primary-light-3);
      --el-button-active-bg-color: var(--el-color-primary-dark-2);
      --el-button-active-border-color: var(--el-color-primary-dark-2);
      --el-button-disabled-text-color: var(--el-color-white);
      --el-button-disabled-bg-color: var(--el-color-primary-light-5);
      --el-button-disabled-border-color: var(--el-color-primary-light-5)
    }

    .el-button--primary.is-link,
    .el-button--primary.is-plain,
    .el-button--primary.is-text {
      --el-button-text-color: var(--el-color-primary);
      --el-button-bg-color: var(--el-color-primary-light-9);
      --el-button-border-color: var(--el-color-primary-light-5);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-bg-color: var(--el-color-primary);
      --el-button-hover-border-color: var(--el-color-primary);
      --el-button-active-text-color: var(--el-color-white)
    }

    .el-button--primary.is-link.is-disabled,
    .el-button--primary.is-link.is-disabled:active,
    .el-button--primary.is-link.is-disabled:focus,
    .el-button--primary.is-link.is-disabled:hover,
    .el-button--primary.is-plain.is-disabled,
    .el-button--primary.is-plain.is-disabled:active,
    .el-button--primary.is-plain.is-disabled:focus,
    .el-button--primary.is-plain.is-disabled:hover,
    .el-button--primary.is-text.is-disabled,
    .el-button--primary.is-text.is-disabled:active,
    .el-button--primary.is-text.is-disabled:focus,
    .el-button--primary.is-text.is-disabled:hover {
      color: var(--el-color-primary-light-5);
      background-color: var(--el-color-primary-light-9);
      border-color: var(--el-color-primary-light-8)
    }

    .el-button--success {
      --el-button-text-color: var(--el-color-white);
      --el-button-bg-color: var(--el-color-success);
      --el-button-border-color: var(--el-color-success);
      --el-button-outline-color: var(--el-color-success-light-5);
      --el-button-active-color: var(--el-color-success-dark-2);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-link-text-color: var(--el-color-success-light-5);
      --el-button-hover-bg-color: var(--el-color-success-light-3);
      --el-button-hover-border-color: var(--el-color-success-light-3);
      --el-button-active-bg-color: var(--el-color-success-dark-2);
      --el-button-active-border-color: var(--el-color-success-dark-2);
      --el-button-disabled-text-color: var(--el-color-white);
      --el-button-disabled-bg-color: var(--el-color-success-light-5);
      --el-button-disabled-border-color: var(--el-color-success-light-5)
    }

    .el-button--success.is-link,
    .el-button--success.is-plain,
    .el-button--success.is-text {
      --el-button-text-color: var(--el-color-success);
      --el-button-bg-color: var(--el-color-success-light-9);
      --el-button-border-color: var(--el-color-success-light-5);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-bg-color: var(--el-color-success);
      --el-button-hover-border-color: var(--el-color-success);
      --el-button-active-text-color: var(--el-color-white)
    }

    .el-button--success.is-link.is-disabled,
    .el-button--success.is-link.is-disabled:active,
    .el-button--success.is-link.is-disabled:focus,
    .el-button--success.is-link.is-disabled:hover,
    .el-button--success.is-plain.is-disabled,
    .el-button--success.is-plain.is-disabled:active,
    .el-button--success.is-plain.is-disabled:focus,
    .el-button--success.is-plain.is-disabled:hover,
    .el-button--success.is-text.is-disabled,
    .el-button--success.is-text.is-disabled:active,
    .el-button--success.is-text.is-disabled:focus,
    .el-button--success.is-text.is-disabled:hover {
      color: var(--el-color-success-light-5);
      background-color: var(--el-color-success-light-9);
      border-color: var(--el-color-success-light-8)
    }

    .el-button--warning {
      --el-button-text-color: var(--el-color-white);
      --el-button-bg-color: var(--el-color-warning);
      --el-button-border-color: var(--el-color-warning);
      --el-button-outline-color: var(--el-color-warning-light-5);
      --el-button-active-color: var(--el-color-warning-dark-2);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-link-text-color: var(--el-color-warning-light-5);
      --el-button-hover-bg-color: var(--el-color-warning-light-3);
      --el-button-hover-border-color: var(--el-color-warning-light-3);
      --el-button-active-bg-color: var(--el-color-warning-dark-2);
      --el-button-active-border-color: var(--el-color-warning-dark-2);
      --el-button-disabled-text-color: var(--el-color-white);
      --el-button-disabled-bg-color: var(--el-color-warning-light-5);
      --el-button-disabled-border-color: var(--el-color-warning-light-5)
    }

    .el-button--warning.is-link,
    .el-button--warning.is-plain,
    .el-button--warning.is-text {
      --el-button-text-color: var(--el-color-warning);
      --el-button-bg-color: var(--el-color-warning-light-9);
      --el-button-border-color: var(--el-color-warning-light-5);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-bg-color: var(--el-color-warning);
      --el-button-hover-border-color: var(--el-color-warning);
      --el-button-active-text-color: var(--el-color-white)
    }

    .el-button--warning.is-link.is-disabled,
    .el-button--warning.is-link.is-disabled:active,
    .el-button--warning.is-link.is-disabled:focus,
    .el-button--warning.is-link.is-disabled:hover,
    .el-button--warning.is-plain.is-disabled,
    .el-button--warning.is-plain.is-disabled:active,
    .el-button--warning.is-plain.is-disabled:focus,
    .el-button--warning.is-plain.is-disabled:hover,
    .el-button--warning.is-text.is-disabled,
    .el-button--warning.is-text.is-disabled:active,
    .el-button--warning.is-text.is-disabled:focus,
    .el-button--warning.is-text.is-disabled:hover {
      color: var(--el-color-warning-light-5);
      background-color: var(--el-color-warning-light-9);
      border-color: var(--el-color-warning-light-8)
    }

    .el-button--danger {
      --el-button-text-color: var(--el-color-white);
      --el-button-bg-color: var(--el-color-danger);
      --el-button-border-color: var(--el-color-danger);
      --el-button-outline-color: var(--el-color-danger-light-5);
      --el-button-active-color: var(--el-color-danger-dark-2);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-link-text-color: var(--el-color-danger-light-5);
      --el-button-hover-bg-color: var(--el-color-danger-light-3);
      --el-button-hover-border-color: var(--el-color-danger-light-3);
      --el-button-active-bg-color: var(--el-color-danger-dark-2);
      --el-button-active-border-color: var(--el-color-danger-dark-2);
      --el-button-disabled-text-color: var(--el-color-white);
      --el-button-disabled-bg-color: var(--el-color-danger-light-5);
      --el-button-disabled-border-color: var(--el-color-danger-light-5)
    }

    .el-button--danger.is-link,
    .el-button--danger.is-plain,
    .el-button--danger.is-text {
      --el-button-text-color: var(--el-color-danger);
      --el-button-bg-color: var(--el-color-danger-light-9);
      --el-button-border-color: var(--el-color-danger-light-5);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-bg-color: var(--el-color-danger);
      --el-button-hover-border-color: var(--el-color-danger);
      --el-button-active-text-color: var(--el-color-white)
    }

    .el-button--danger.is-link.is-disabled,
    .el-button--danger.is-link.is-disabled:active,
    .el-button--danger.is-link.is-disabled:focus,
    .el-button--danger.is-link.is-disabled:hover,
    .el-button--danger.is-plain.is-disabled,
    .el-button--danger.is-plain.is-disabled:active,
    .el-button--danger.is-plain.is-disabled:focus,
    .el-button--danger.is-plain.is-disabled:hover,
    .el-button--danger.is-text.is-disabled,
    .el-button--danger.is-text.is-disabled:active,
    .el-button--danger.is-text.is-disabled:focus,
    .el-button--danger.is-text.is-disabled:hover {
      color: var(--el-color-danger-light-5);
      background-color: var(--el-color-danger-light-9);
      border-color: var(--el-color-danger-light-8)
    }

    .el-button--info {
      --el-button-text-color: var(--el-color-white);
      --el-button-bg-color: var(--el-color-info);
      --el-button-border-color: var(--el-color-info);
      --el-button-outline-color: var(--el-color-info-light-5);
      --el-button-active-color: var(--el-color-info-dark-2);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-link-text-color: var(--el-color-info-light-5);
      --el-button-hover-bg-color: var(--el-color-info-light-3);
      --el-button-hover-border-color: var(--el-color-info-light-3);
      --el-button-active-bg-color: var(--el-color-info-dark-2);
      --el-button-active-border-color: var(--el-color-info-dark-2);
      --el-button-disabled-text-color: var(--el-color-white);
      --el-button-disabled-bg-color: var(--el-color-info-light-5);
      --el-button-disabled-border-color: var(--el-color-info-light-5)
    }

    .el-button--info.is-link,
    .el-button--info.is-plain,
    .el-button--info.is-text {
      --el-button-text-color: var(--el-color-info);
      --el-button-bg-color: var(--el-color-info-light-9);
      --el-button-border-color: var(--el-color-info-light-5);
      --el-button-hover-text-color: var(--el-color-white);
      --el-button-hover-bg-color: var(--el-color-info);
      --el-button-hover-border-color: var(--el-color-info);
      --el-button-active-text-color: var(--el-color-white)
    }

    .el-button--info.is-link.is-disabled,
    .el-button--info.is-link.is-disabled:active,
    .el-button--info.is-link.is-disabled:focus,
    .el-button--info.is-link.is-disabled:hover,
    .el-button--info.is-plain.is-disabled,
    .el-button--info.is-plain.is-disabled:active,
    .el-button--info.is-plain.is-disabled:focus,
    .el-button--info.is-plain.is-disabled:hover,
    .el-button--info.is-text.is-disabled,
    .el-button--info.is-text.is-disabled:active,
    .el-button--info.is-text.is-disabled:focus,
    .el-button--info.is-text.is-disabled:hover {
      color: var(--el-color-info-light-5);
      background-color: var(--el-color-info-light-9);
      border-color: var(--el-color-info-light-8)
    }

    .el-button--large {
      --el-button-size: 40px;
      height: var(--el-button-size);
      padding: 12px 19px;
      font-size: var(--el-font-size-base);
      border-radius: var(--el-border-radius-base)
    }

    .el-button--large [class*=el-icon]+span {
      margin-left: 8px
    }

    .el-button--large.is-round {
      padding: 12px 19px
    }

    .el-button--large.is-circle {
      width: var(--el-button-size);
      padding: 12px
    }

    .el-button--small {
      --el-button-size: 24px;
      height: var(--el-button-size);
      padding: 5px 11px;
      font-size: 12px;
      border-radius: calc(var(--el-border-radius-base) - 1px)
    }

    .el-button--small [class*=el-icon]+span {
      margin-left: 4px
    }

    .el-button--small.is-round {
      padding: 5px 11px
    }

    .el-button--small.is-circle {
      width: var(--el-button-size);
      padding: 5px
    }
  </style>
  <style type=""text/css""
    data-vite-dev-id=""E:/code/test/ui/panda.net.web/node_modules/element-plus/theme-chalk/el-form-item.css""></style>
  <style type=""text/css""
    data-vite-dev-id=""E:/code/test/ui/panda.net.web/node_modules/element-plus/theme-chalk/el-input.css"">
    .el-textarea {
      --el-input-text-color: var(--el-text-color-regular);
      --el-input-border: var(--el-border);
      --el-input-hover-border: var(--el-border-color-hover);
      --el-input-focus-border: var(--el-color-primary);
      --el-input-transparent-border: 0 0 0 1px transparent inset;
      --el-input-border-color: var(--el-border-color);
      --el-input-border-radius: var(--el-border-radius-base);
      --el-input-bg-color: var(--el-fill-color-blank);
      --el-input-icon-color: var(--el-text-color-placeholder);
      --el-input-placeholder-color: var(--el-text-color-placeholder);
      --el-input-hover-border-color: var(--el-border-color-hover);
      --el-input-clear-hover-color: var(--el-text-color-secondary);
      --el-input-focus-border-color: var(--el-color-primary);
      --el-input-width: 100%
    }

    .el-textarea {
      position: relative;
      display: inline-block;
      width: 100%;
      vertical-align: bottom;
      font-size: var(--el-font-size-base)
    }

    .el-textarea__inner {
      position: relative;
      display: block;
      resize: vertical;
      padding: 5px 11px;
      line-height: 1.5;
      box-sizing: border-box;
      width: 100%;
      font-size: inherit;
      font-family: inherit;
      color: var(--el-input-text-color, var(--el-text-color-regular));
      background-color: var(--el-input-bg-color, var(--el-fill-color-blank));
      background-image: none;
      -webkit-appearance: none;
      box-shadow: 0 0 0 1px var(--el-input-border-color, var(--el-border-color)) inset;
      border-radius: var(--el-input-border-radius, var(--el-border-radius-base));
      transition: var(--el-transition-box-shadow);
      border: none
    }

    .el-textarea__inner::-moz-placeholder {
      color: var(--el-input-placeholder-color, var(--el-text-color-placeholder))
    }

    .el-textarea__inner:-ms-input-placeholder {
      color: var(--el-input-placeholder-color, var(--el-text-color-placeholder))
    }

    .el-textarea__inner::placeholder {
      color: var(--el-input-placeholder-color, var(--el-text-color-placeholder))
    }

    .el-textarea__inner:hover {
      box-shadow: 0 0 0 1px var(--el-input-hover-border-color) inset
    }

    .el-textarea__inner:focus {
      outline: 0;
      box-shadow: 0 0 0 1px var(--el-input-focus-border-color) inset
    }

    .el-textarea .el-input__count {
      color: var(--el-color-info);
      background: var(--el-fill-color-blank);
      position: absolute;
      font-size: 12px;
      line-height: 14px;
      bottom: 5px;
      right: 10px
    }

    .el-textarea.is-disabled .el-textarea__inner {
      box-shadow: 0 0 0 1px var(--el-disabled-border-color) inset;
      background-color: var(--el-disabled-bg-color);
      color: var(--el-disabled-text-color);
      cursor: not-allowed
    }

    .el-textarea.is-disabled .el-textarea__inner::-moz-placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-textarea.is-disabled .el-textarea__inner:-ms-input-placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-textarea.is-disabled .el-textarea__inner::placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-textarea.is-exceed .el-textarea__inner {
      box-shadow: 0 0 0 1px var(--el-color-danger) inset
    }

    .el-textarea.is-exceed .el-input__count {
      color: var(--el-color-danger)
    }

    .el-input {
      --el-input-text-color: var(--el-text-color-regular);
      --el-input-border: var(--el-border);
      --el-input-hover-border: var(--el-border-color-hover);
      --el-input-focus-border: var(--el-color-primary);
      --el-input-transparent-border: 0 0 0 1px transparent inset;
      --el-input-border-color: var(--el-border-color);
      --el-input-border-radius: var(--el-border-radius-base);
      --el-input-bg-color: var(--el-fill-color-blank);
      --el-input-icon-color: var(--el-text-color-placeholder);
      --el-input-placeholder-color: var(--el-text-color-placeholder);
      --el-input-hover-border-color: var(--el-border-color-hover);
      --el-input-clear-hover-color: var(--el-text-color-secondary);
      --el-input-focus-border-color: var(--el-color-primary);
      --el-input-width: 100%
    }

    .el-input {
      --el-input-height: var(--el-component-size);
      position: relative;
      font-size: var(--el-font-size-base);
      display: inline-flex;
      width: var(--el-input-width);
      line-height: var(--el-input-height);
      box-sizing: border-box;
      vertical-align: middle
    }

    .el-input::-webkit-scrollbar {
      z-index: 11;
      width: 6px
    }

    .el-input::-webkit-scrollbar:horizontal {
      height: 6px
    }

    .el-input::-webkit-scrollbar-thumb {
      border-radius: 5px;
      width: 6px;
      background: var(--el-text-color-disabled)
    }

    .el-input::-webkit-scrollbar-corner {
      background: var(--el-fill-color-blank)
    }

    .el-input::-webkit-scrollbar-track {
      background: var(--el-fill-color-blank)
    }

    .el-input::-webkit-scrollbar-track-piece {
      background: var(--el-fill-color-blank);
      width: 6px
    }

    .el-input .el-input__clear,
    .el-input .el-input__password {
      color: var(--el-input-icon-color);
      font-size: 14px;
      cursor: pointer
    }

    .el-input .el-input__clear:hover,
    .el-input .el-input__password:hover {
      color: var(--el-input-clear-hover-color)
    }

    .el-input .el-input__count {
      height: 100%;
      display: inline-flex;
      align-items: center;
      color: var(--el-color-info);
      font-size: 12px
    }

    .el-input .el-input__count .el-input__count-inner {
      background: var(--el-fill-color-blank);
      line-height: initial;
      display: inline-block;
      padding-left: 8px
    }

    .el-input__wrapper {
      display: inline-flex;
      flex-grow: 1;
      align-items: center;
      justify-content: center;
      padding: 1px 11px;
      background-color: var(--el-input-bg-color, var(--el-fill-color-blank));
      background-image: none;
      border-radius: var(--el-input-border-radius, var(--el-border-radius-base));
      cursor: text;
      transition: var(--el-transition-box-shadow);
      transform: translate3d(0, 0, 0);
      box-shadow: 0 0 0 1px var(--el-input-border-color, var(--el-border-color)) inset
    }

    .el-input__wrapper:hover {
      box-shadow: 0 0 0 1px var(--el-input-hover-border-color) inset
    }

    .el-input__wrapper.is-focus {
      box-shadow: 0 0 0 1px var(--el-input-focus-border-color) inset
    }

    .el-input__inner {
      --el-input-inner-height: calc(var(--el-input-height, 32px) - 2px);
      width: 100%;
      flex-grow: 1;
      -webkit-appearance: none;
      color: var(--el-input-text-color, var(--el-text-color-regular));
      font-size: inherit;
      height: var(--el-input-inner-height);
      line-height: var(--el-input-inner-height);
      padding: 0;
      outline: 0;
      border: none;
      background: 0 0;
      box-sizing: border-box
    }

    .el-input__inner:focus {
      outline: 0
    }

    .el-input__inner::-moz-placeholder {
      color: var(--el-input-placeholder-color, var(--el-text-color-placeholder))
    }

    .el-input__inner:-ms-input-placeholder {
      color: var(--el-input-placeholder-color, var(--el-text-color-placeholder))
    }

    .el-input__inner::placeholder {
      color: var(--el-input-placeholder-color, var(--el-text-color-placeholder))
    }

    .el-input__inner[type=password]::-ms-reveal {
      display: none
    }

    .el-input__inner[type=number] {
      line-height: 1
    }

    .el-input__prefix {
      display: inline-flex;
      white-space: nowrap;
      flex-shrink: 0;
      flex-wrap: nowrap;
      height: 100%;
      text-align: center;
      color: var(--el-input-icon-color, var(--el-text-color-placeholder));
      transition: all var(--el-transition-duration);
      pointer-events: none
    }

    .el-input__prefix-inner {
      pointer-events: all;
      display: inline-flex;
      align-items: center;
      justify-content: center
    }

    .el-input__prefix-inner>:last-child {
      margin-right: 8px
    }

    .el-input__prefix-inner>:first-child,
    .el-input__prefix-inner>:first-child.el-input__icon {
      margin-left: 0
    }

    .el-input__suffix {
      display: inline-flex;
      white-space: nowrap;
      flex-shrink: 0;
      flex-wrap: nowrap;
      height: 100%;
      text-align: center;
      color: var(--el-input-icon-color, var(--el-text-color-placeholder));
      transition: all var(--el-transition-duration);
      pointer-events: none
    }

    .el-input__suffix-inner {
      pointer-events: all;
      display: inline-flex;
      align-items: center;
      justify-content: center
    }

    .el-input__suffix-inner>:first-child {
      margin-left: 8px
    }

    .el-input .el-input__icon {
      height: inherit;
      line-height: inherit;
      display: flex;
      justify-content: center;
      align-items: center;
      transition: all var(--el-transition-duration);
      margin-left: 8px
    }

    .el-input__validateIcon {
      pointer-events: none
    }

    .el-input.is-active .el-input__wrapper {
      box-shadow: 0 0 0 1px var(--el-input-focus-color, ) inset
    }

    .el-input.is-disabled {
      cursor: not-allowed
    }

    .el-input.is-disabled .el-input__wrapper {
      background-color: var(--el-disabled-bg-color);
      box-shadow: 0 0 0 1px var(--el-disabled-border-color) inset
    }

    .el-input.is-disabled .el-input__inner {
      color: var(--el-disabled-text-color);
      -webkit-text-fill-color: var(--el-disabled-text-color);
      cursor: not-allowed
    }

    .el-input.is-disabled .el-input__inner::-moz-placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-input.is-disabled .el-input__inner:-ms-input-placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-input.is-disabled .el-input__inner::placeholder {
      color: var(--el-text-color-placeholder)
    }

    .el-input.is-disabled .el-input__icon {
      cursor: not-allowed
    }

    .el-input.is-exceed .el-input__wrapper {
      box-shadow: 0 0 0 1px var(--el-color-danger) inset
    }

    .el-input.is-exceed .el-input__suffix .el-input__count {
      color: var(--el-color-danger)
    }

    .el-input--large {
      --el-input-height: var(--el-component-size-large);
      font-size: 14px
    }

    .el-input--large .el-input__wrapper {
      padding: 1px 15px
    }

    .el-input--large .el-input__inner {
      --el-input-inner-height: calc(var(--el-input-height, 40px) - 2px)
    }

    .el-input--small {
      --el-input-height: var(--el-component-size-small);
      font-size: 12px
    }

    .el-input--small .el-input__wrapper {
      padding: 1px 7px
    }

    .el-input--small .el-input__inner {
      --el-input-inner-height: calc(var(--el-input-height, 24px) - 2px)
    }

    .el-input-group {
      display: inline-flex;
      width: 100%;
      align-items: stretch
    }

    .el-input-group__append,
    .el-input-group__prepend {
      background-color: var(--el-fill-color-light);
      color: var(--el-color-info);
      position: relative;
      display: inline-flex;
      align-items: center;
      justify-content: center;
      min-height: 100%;
      border-radius: var(--el-input-border-radius);
      padding: 0 20px;
      white-space: nowrap
    }

    .el-input-group__append:focus,
    .el-input-group__prepend:focus {
      outline: 0
    }

    .el-input-group__append .el-button,
    .el-input-group__append .el-select,
    .el-input-group__prepend .el-button,
    .el-input-group__prepend .el-select {
      display: inline-block;
      margin: 0 -20px
    }

    .el-input-group__append button.el-button,
    .el-input-group__append button.el-button:hover,
    .el-input-group__append div.el-select .el-select__wrapper,
    .el-input-group__append div.el-select:hover .el-select__wrapper,
    .el-input-group__prepend button.el-button,
    .el-input-group__prepend button.el-button:hover,
    .el-input-group__prepend div.el-select .el-select__wrapper,
    .el-input-group__prepend div.el-select:hover .el-select__wrapper {
      border-color: transparent;
      background-color: transparent;
      color: inherit
    }

    .el-input-group__append .el-button,
    .el-input-group__append .el-input,
    .el-input-group__prepend .el-button,
    .el-input-group__prepend .el-input {
      font-size: inherit
    }

    .el-input-group__prepend {
      border-right: 0;
      border-top-right-radius: 0;
      border-bottom-right-radius: 0;
      box-shadow: 1px 0 0 0 var(--el-input-border-color) inset, 0 1px 0 0 var(--el-input-border-color) inset, 0 -1px 0 0 var(--el-input-border-color) inset
    }

    .el-input-group__append {
      border-left: 0;
      border-top-left-radius: 0;
      border-bottom-left-radius: 0;
      box-shadow: 0 1px 0 0 var(--el-input-border-color) inset, 0 -1px 0 0 var(--el-input-border-color) inset, -1px 0 0 0 var(--el-input-border-color) inset
    }

    .el-input-group--prepend>.el-input__wrapper {
      border-top-left-radius: 0;
      border-bottom-left-radius: 0
    }

    .el-input-group--prepend .el-input-group__prepend .el-select .el-select__wrapper {
      border-top-right-radius: 0;
      border-bottom-right-radius: 0;
      box-shadow: 1px 0 0 0 var(--el-input-border-color) inset, 0 1px 0 0 var(--el-input-border-color) inset, 0 -1px 0 0 var(--el-input-border-color) inset
    }

    .el-input-group--append>.el-input__wrapper {
      border-top-right-radius: 0;
      border-bottom-right-radius: 0
    }

    .el-input-group--append .el-input-group__append .el-select .el-select__wrapper {
      border-top-left-radius: 0;
      border-bottom-left-radius: 0;
      box-shadow: 0 1px 0 0 var(--el-input-border-color) inset, 0 -1px 0 0 var(--el-input-border-color) inset, -1px 0 0 0 var(--el-input-border-color) inset
    }
  </style>
  <style type=""text/css""
    data-vite-dev-id=""E:/code/test/ui/panda.net.web/node_modules/element-plus/theme-chalk/el-col.css"">
    [class*=el-col-] {
      box-sizing: border-box
    }

    [class*=el-col-].is-guttered {
      display: block;
      min-height: 1px
    }

    .el-col-0 {
      display: none
    }

    .el-col-0.is-guttered {
      display: none
    }

    .el-col-0 {
      max-width: 0%;
      flex: 0 0 0%
    }

    .el-col-offset-0 {
      margin-left: 0
    }

    .el-col-pull-0 {
      position: relative;
      right: 0
    }

    .el-col-push-0 {
      position: relative;
      left: 0
    }

    .el-col-1 {
      max-width: 4.1666666667%;
      flex: 0 0 4.1666666667%
    }

    .el-col-offset-1 {
      margin-left: 4.1666666667%
    }

    .el-col-pull-1 {
      position: relative;
      right: 4.1666666667%
    }

    .el-col-push-1 {
      position: relative;
      left: 4.1666666667%
    }

    .el-col-2 {
      max-width: 8.3333333333%;
      flex: 0 0 8.3333333333%
    }

    .el-col-offset-2 {
      margin-left: 8.3333333333%
    }

    .el-col-pull-2 {
      position: relative;
      right: 8.3333333333%
    }

    .el-col-push-2 {
      position: relative;
      left: 8.3333333333%
    }

    .el-col-3 {
      max-width: 12.5%;
      flex: 0 0 12.5%
    }

    .el-col-offset-3 {
      margin-left: 12.5%
    }

    .el-col-pull-3 {
      position: relative;
      right: 12.5%
    }

    .el-col-push-3 {
      position: relative;
      left: 12.5%
    }

    .el-col-4 {
      max-width: 16.6666666667%;
      flex: 0 0 16.6666666667%
    }

    .el-col-offset-4 {
      margin-left: 16.6666666667%
    }

    .el-col-pull-4 {
      position: relative;
      right: 16.6666666667%
    }

    .el-col-push-4 {
      position: relative;
      left: 16.6666666667%
    }

    .el-col-5 {
      max-width: 20.8333333333%;
      flex: 0 0 20.8333333333%
    }

    .el-col-offset-5 {
      margin-left: 20.8333333333%
    }

    .el-col-pull-5 {
      position: relative;
      right: 20.8333333333%
    }

    .el-col-push-5 {
      position: relative;
      left: 20.8333333333%
    }

    .el-col-6 {
      max-width: 25%;
      flex: 0 0 25%
    }

    .el-col-offset-6 {
      margin-left: 25%
    }

    .el-col-pull-6 {
      position: relative;
      right: 25%
    }

    .el-col-push-6 {
      position: relative;
      left: 25%
    }

    .el-col-7 {
      max-width: 29.1666666667%;
      flex: 0 0 29.1666666667%
    }

    .el-col-offset-7 {
      margin-left: 29.1666666667%
    }

    .el-col-pull-7 {
      position: relative;
      right: 29.1666666667%
    }

    .el-col-push-7 {
      position: relative;
      left: 29.1666666667%
    }

    .el-col-8 {
      max-width: 33.3333333333%;
      flex: 0 0 33.3333333333%
    }

    .el-col-offset-8 {
      margin-left: 33.3333333333%
    }

    .el-col-pull-8 {
      position: relative;
      right: 33.3333333333%
    }

    .el-col-push-8 {
      position: relative;
      left: 33.3333333333%
    }

    .el-col-9 {
      max-width: 37.5%;
      flex: 0 0 37.5%
    }

    .el-col-offset-9 {
      margin-left: 37.5%
    }

    .el-col-pull-9 {
      position: relative;
      right: 37.5%
    }

    .el-col-push-9 {
      position: relative;
      left: 37.5%
    }

    .el-col-10 {
      max-width: 41.6666666667%;
      flex: 0 0 41.6666666667%
    }

    .el-col-offset-10 {
      margin-left: 41.6666666667%
    }

    .el-col-pull-10 {
      position: relative;
      right: 41.6666666667%
    }

    .el-col-push-10 {
      position: relative;
      left: 41.6666666667%
    }

    .el-col-11 {
      max-width: 45.8333333333%;
      flex: 0 0 45.8333333333%
    }

    .el-col-offset-11 {
      margin-left: 45.8333333333%
    }

    .el-col-pull-11 {
      position: relative;
      right: 45.8333333333%
    }

    .el-col-push-11 {
      position: relative;
      left: 45.8333333333%
    }

    .el-col-12 {
      max-width: 50%;
      flex: 0 0 50%
    }

    .el-col-offset-12 {
      margin-left: 50%
    }

    .el-col-pull-12 {
      position: relative;
      right: 50%
    }

    .el-col-push-12 {
      position: relative;
      left: 50%
    }

    .el-col-13 {
      max-width: 54.1666666667%;
      flex: 0 0 54.1666666667%
    }

    .el-col-offset-13 {
      margin-left: 54.1666666667%
    }

    .el-col-pull-13 {
      position: relative;
      right: 54.1666666667%
    }

    .el-col-push-13 {
      position: relative;
      left: 54.1666666667%
    }

    .el-col-14 {
      max-width: 58.3333333333%;
      flex: 0 0 58.3333333333%
    }

    .el-col-offset-14 {
      margin-left: 58.3333333333%
    }

    .el-col-pull-14 {
      position: relative;
      right: 58.3333333333%
    }

    .el-col-push-14 {
      position: relative;
      left: 58.3333333333%
    }

    .el-col-15 {
      max-width: 62.5%;
      flex: 0 0 62.5%
    }

    .el-col-offset-15 {
      margin-left: 62.5%
    }

    .el-col-pull-15 {
      position: relative;
      right: 62.5%
    }

    .el-col-push-15 {
      position: relative;
      left: 62.5%
    }

    .el-col-16 {
      max-width: 66.6666666667%;
      flex: 0 0 66.6666666667%
    }

    .el-col-offset-16 {
      margin-left: 66.6666666667%
    }

    .el-col-pull-16 {
      position: relative;
      right: 66.6666666667%
    }

    .el-col-push-16 {
      position: relative;
      left: 66.6666666667%
    }

    .el-col-17 {
      max-width: 70.8333333333%;
      flex: 0 0 70.8333333333%
    }

    .el-col-offset-17 {
      margin-left: 70.8333333333%
    }

    .el-col-pull-17 {
      position: relative;
      right: 70.8333333333%
    }

    .el-col-push-17 {
      position: relative;
      left: 70.8333333333%
    }

    .el-col-18 {
      max-width: 75%;
      flex: 0 0 75%
    }

    .el-col-offset-18 {
      margin-left: 75%
    }

    .el-col-pull-18 {
      position: relative;
      right: 75%
    }

    .el-col-push-18 {
      position: relative;
      left: 75%
    }

    .el-col-19 {
      max-width: 79.1666666667%;
      flex: 0 0 79.1666666667%
    }

    .el-col-offset-19 {
      margin-left: 79.1666666667%
    }

    .el-col-pull-19 {
      position: relative;
      right: 79.1666666667%
    }

    .el-col-push-19 {
      position: relative;
      left: 79.1666666667%
    }

    .el-col-20 {
      max-width: 83.3333333333%;
      flex: 0 0 83.3333333333%
    }

    .el-col-offset-20 {
      margin-left: 83.3333333333%
    }

    .el-col-pull-20 {
      position: relative;
      right: 83.3333333333%
    }

    .el-col-push-20 {
      position: relative;
      left: 83.3333333333%
    }

    .el-col-21 {
      max-width: 87.5%;
      flex: 0 0 87.5%
    }

    .el-col-offset-21 {
      margin-left: 87.5%
    }

    .el-col-pull-21 {
      position: relative;
      right: 87.5%
    }

    .el-col-push-21 {
      position: relative;
      left: 87.5%
    }

    .el-col-22 {
      max-width: 91.6666666667%;
      flex: 0 0 91.6666666667%
    }

    .el-col-offset-22 {
      margin-left: 91.6666666667%
    }

    .el-col-pull-22 {
      position: relative;
      right: 91.6666666667%
    }

    .el-col-push-22 {
      position: relative;
      left: 91.6666666667%
    }

    .el-col-23 {
      max-width: 95.8333333333%;
      flex: 0 0 95.8333333333%
    }

    .el-col-offset-23 {
      margin-left: 95.8333333333%
    }

    .el-col-pull-23 {
      position: relative;
      right: 95.8333333333%
    }

    .el-col-push-23 {
      position: relative;
      left: 95.8333333333%
    }

    .el-col-24 {
      max-width: 100%;
      flex: 0 0 100%
    }

    .el-col-offset-24 {
      margin-left: 100%
    }

    .el-col-pull-24 {
      position: relative;
      right: 100%
    }

    .el-col-push-24 {
      position: relative;
      left: 100%
    }

    @media only screen and (max-width:767px) {
      .el-col-xs-0 {
        display: none
      }

      .el-col-xs-0.is-guttered {
        display: none
      }

      .el-col-xs-0 {
        max-width: 0%;
        flex: 0 0 0%
      }

      .el-col-xs-offset-0 {
        margin-left: 0
      }

      .el-col-xs-pull-0 {
        position: relative;
        right: 0
      }

      .el-col-xs-push-0 {
        position: relative;
        left: 0
      }

      .el-col-xs-1 {
        display: block;
        max-width: 4.1666666667%;
        flex: 0 0 4.1666666667%
      }

      .el-col-xs-offset-1 {
        margin-left: 4.1666666667%
      }

      .el-col-xs-pull-1 {
        position: relative;
        right: 4.1666666667%
      }

      .el-col-xs-push-1 {
        position: relative;
        left: 4.1666666667%
      }

      .el-col-xs-2 {
        display: block;
        max-width: 8.3333333333%;
        flex: 0 0 8.3333333333%
      }

      .el-col-xs-offset-2 {
        margin-left: 8.3333333333%
      }

      .el-col-xs-pull-2 {
        position: relative;
        right: 8.3333333333%
      }

      .el-col-xs-push-2 {
        position: relative;
        left: 8.3333333333%
      }

      .el-col-xs-3 {
        display: block;
        max-width: 12.5%;
        flex: 0 0 12.5%
      }

      .el-col-xs-offset-3 {
        margin-left: 12.5%
      }

      .el-col-xs-pull-3 {
        position: relative;
        right: 12.5%
      }

      .el-col-xs-push-3 {
        position: relative;
        left: 12.5%
      }

      .el-col-xs-4 {
        display: block;
        max-width: 16.6666666667%;
        flex: 0 0 16.6666666667%
      }

      .el-col-xs-offset-4 {
        margin-left: 16.6666666667%
      }

      .el-col-xs-pull-4 {
        position: relative;
        right: 16.6666666667%
      }

      .el-col-xs-push-4 {
        position: relative;
        left: 16.6666666667%
      }

      .el-col-xs-5 {
        display: block;
        max-width: 20.8333333333%;
        flex: 0 0 20.8333333333%
      }

      .el-col-xs-offset-5 {
        margin-left: 20.8333333333%
      }

      .el-col-xs-pull-5 {
        position: relative;
        right: 20.8333333333%
      }

      .el-col-xs-push-5 {
        position: relative;
        left: 20.8333333333%
      }

      .el-col-xs-6 {
        display: block;
        max-width: 25%;
        flex: 0 0 25%
      }

      .el-col-xs-offset-6 {
        margin-left: 25%
      }

      .el-col-xs-pull-6 {
        position: relative;
        right: 25%
      }

      .el-col-xs-push-6 {
        position: relative;
        left: 25%
      }

      .el-col-xs-7 {
        display: block;
        max-width: 29.1666666667%;
        flex: 0 0 29.1666666667%
      }

      .el-col-xs-offset-7 {
        margin-left: 29.1666666667%
      }

      .el-col-xs-pull-7 {
        position: relative;
        right: 29.1666666667%
      }

      .el-col-xs-push-7 {
        position: relative;
        left: 29.1666666667%
      }

      .el-col-xs-8 {
        display: block;
        max-width: 33.3333333333%;
        flex: 0 0 33.3333333333%
      }

      .el-col-xs-offset-8 {
        margin-left: 33.3333333333%
      }

      .el-col-xs-pull-8 {
        position: relative;
        right: 33.3333333333%
      }

      .el-col-xs-push-8 {
        position: relative;
        left: 33.3333333333%
      }

      .el-col-xs-9 {
        display: block;
        max-width: 37.5%;
        flex: 0 0 37.5%
      }

      .el-col-xs-offset-9 {
        margin-left: 37.5%
      }

      .el-col-xs-pull-9 {
        position: relative;
        right: 37.5%
      }

      .el-col-xs-push-9 {
        position: relative;
        left: 37.5%
      }

      .el-col-xs-10 {
        display: block;
        max-width: 41.6666666667%;
        flex: 0 0 41.6666666667%
      }

      .el-col-xs-offset-10 {
        margin-left: 41.6666666667%
      }

      .el-col-xs-pull-10 {
        position: relative;
        right: 41.6666666667%
      }

      .el-col-xs-push-10 {
        position: relative;
        left: 41.6666666667%
      }

      .el-col-xs-11 {
        display: block;
        max-width: 45.8333333333%;
        flex: 0 0 45.8333333333%
      }

      .el-col-xs-offset-11 {
        margin-left: 45.8333333333%
      }

      .el-col-xs-pull-11 {
        position: relative;
        right: 45.8333333333%
      }

      .el-col-xs-push-11 {
        position: relative;
        left: 45.8333333333%
      }

      .el-col-xs-12 {
        display: block;
        max-width: 50%;
        flex: 0 0 50%
      }

      .el-col-xs-offset-12 {
        margin-left: 50%
      }

      .el-col-xs-pull-12 {
        position: relative;
        right: 50%
      }

      .el-col-xs-push-12 {
        position: relative;
        left: 50%
      }

      .el-col-xs-13 {
        display: block;
        max-width: 54.1666666667%;
        flex: 0 0 54.1666666667%
      }

      .el-col-xs-offset-13 {
        margin-left: 54.1666666667%
      }

      .el-col-xs-pull-13 {
        position: relative;
        right: 54.1666666667%
      }

      .el-col-xs-push-13 {
        position: relative;
        left: 54.1666666667%
      }

      .el-col-xs-14 {
        display: block;
        max-width: 58.3333333333%;
        flex: 0 0 58.3333333333%
      }

      .el-col-xs-offset-14 {
        margin-left: 58.3333333333%
      }

      .el-col-xs-pull-14 {
        position: relative;
        right: 58.3333333333%
      }

      .el-col-xs-push-14 {
        position: relative;
        left: 58.3333333333%
      }

      .el-col-xs-15 {
        display: block;
        max-width: 62.5%;
        flex: 0 0 62.5%
      }

      .el-col-xs-offset-15 {
        margin-left: 62.5%
      }

      .el-col-xs-pull-15 {
        position: relative;
        right: 62.5%
      }

      .el-col-xs-push-15 {
        position: relative;
        left: 62.5%
      }

      .el-col-xs-16 {
        display: block;
        max-width: 66.6666666667%;
        flex: 0 0 66.6666666667%
      }

      .el-col-xs-offset-16 {
        margin-left: 66.6666666667%
      }

      .el-col-xs-pull-16 {
        position: relative;
        right: 66.6666666667%
      }

      .el-col-xs-push-16 {
        position: relative;
        left: 66.6666666667%
      }

      .el-col-xs-17 {
        display: block;
        max-width: 70.8333333333%;
        flex: 0 0 70.8333333333%
      }

      .el-col-xs-offset-17 {
        margin-left: 70.8333333333%
      }

      .el-col-xs-pull-17 {
        position: relative;
        right: 70.8333333333%
      }

      .el-col-xs-push-17 {
        position: relative;
        left: 70.8333333333%
      }

      .el-col-xs-18 {
        display: block;
        max-width: 75%;
        flex: 0 0 75%
      }

      .el-col-xs-offset-18 {
        margin-left: 75%
      }

      .el-col-xs-pull-18 {
        position: relative;
        right: 75%
      }

      .el-col-xs-push-18 {
        position: relative;
        left: 75%
      }

      .el-col-xs-19 {
        display: block;
        max-width: 79.1666666667%;
        flex: 0 0 79.1666666667%
      }

      .el-col-xs-offset-19 {
        margin-left: 79.1666666667%
      }

      .el-col-xs-pull-19 {
        position: relative;
        right: 79.1666666667%
      }

      .el-col-xs-push-19 {
        position: relative;
        left: 79.1666666667%
      }

      .el-col-xs-20 {
        display: block;
        max-width: 83.3333333333%;
        flex: 0 0 83.3333333333%
      }

      .el-col-xs-offset-20 {
        margin-left: 83.3333333333%
      }

      .el-col-xs-pull-20 {
        position: relative;
        right: 83.3333333333%
      }

      .el-col-xs-push-20 {
        position: relative;
        left: 83.3333333333%
      }

      .el-col-xs-21 {
        display: block;
        max-width: 87.5%;
        flex: 0 0 87.5%
      }

      .el-col-xs-offset-21 {
        margin-left: 87.5%
      }

      .el-col-xs-pull-21 {
        position: relative;
        right: 87.5%
      }

      .el-col-xs-push-21 {
        position: relative;
        left: 87.5%
      }

      .el-col-xs-22 {
        display: block;
        max-width: 91.6666666667%;
        flex: 0 0 91.6666666667%
      }

      .el-col-xs-offset-22 {
        margin-left: 91.6666666667%
      }

      .el-col-xs-pull-22 {
        position: relative;
        right: 91.6666666667%
      }

      .el-col-xs-push-22 {
        position: relative;
        left: 91.6666666667%
      }

      .el-col-xs-23 {
        display: block;
        max-width: 95.8333333333%;
        flex: 0 0 95.8333333333%
      }

      .el-col-xs-offset-23 {
        margin-left: 95.8333333333%
      }

      .el-col-xs-pull-23 {
        position: relative;
        right: 95.8333333333%
      }

      .el-col-xs-push-23 {
        position: relative;
        left: 95.8333333333%
      }

      .el-col-xs-24 {
        display: block;
        max-width: 100%;
        flex: 0 0 100%
      }

      .el-col-xs-offset-24 {
        margin-left: 100%
      }

      .el-col-xs-pull-24 {
        position: relative;
        right: 100%
      }

      .el-col-xs-push-24 {
        position: relative;
        left: 100%
      }
    }

    @media only screen and (min-width:768px) {
      .el-col-sm-0 {
        display: none
      }

      .el-col-sm-0.is-guttered {
        display: none
      }

      .el-col-sm-0 {
        max-width: 0%;
        flex: 0 0 0%
      }

      .el-col-sm-offset-0 {
        margin-left: 0
      }

      .el-col-sm-pull-0 {
        position: relative;
        right: 0
      }

      .el-col-sm-push-0 {
        position: relative;
        left: 0
      }

      .el-col-sm-1 {
        display: block;
        max-width: 4.1666666667%;
        flex: 0 0 4.1666666667%
      }

      .el-col-sm-offset-1 {
        margin-left: 4.1666666667%
      }

      .el-col-sm-pull-1 {
        position: relative;
        right: 4.1666666667%
      }

      .el-col-sm-push-1 {
        position: relative;
        left: 4.1666666667%
      }

      .el-col-sm-2 {
        display: block;
        max-width: 8.3333333333%;
        flex: 0 0 8.3333333333%
      }

      .el-col-sm-offset-2 {
        margin-left: 8.3333333333%
      }

      .el-col-sm-pull-2 {
        position: relative;
        right: 8.3333333333%
      }

      .el-col-sm-push-2 {
        position: relative;
        left: 8.3333333333%
      }

      .el-col-sm-3 {
        display: block;
        max-width: 12.5%;
        flex: 0 0 12.5%
      }

      .el-col-sm-offset-3 {
        margin-left: 12.5%
      }

      .el-col-sm-pull-3 {
        position: relative;
        right: 12.5%
      }

      .el-col-sm-push-3 {
        position: relative;
        left: 12.5%
      }

      .el-col-sm-4 {
        display: block;
        max-width: 16.6666666667%;
        flex: 0 0 16.6666666667%
      }

      .el-col-sm-offset-4 {
        margin-left: 16.6666666667%
      }

      .el-col-sm-pull-4 {
        position: relative;
        right: 16.6666666667%
      }

      .el-col-sm-push-4 {
        position: relative;
        left: 16.6666666667%
      }

      .el-col-sm-5 {
        display: block;
        max-width: 20.8333333333%;
        flex: 0 0 20.8333333333%
      }

      .el-col-sm-offset-5 {
        margin-left: 20.8333333333%
      }

      .el-col-sm-pull-5 {
        position: relative;
        right: 20.8333333333%
      }

      .el-col-sm-push-5 {
        position: relative;
        left: 20.8333333333%
      }

      .el-col-sm-6 {
        display: block;
        max-width: 25%;
        flex: 0 0 25%
      }

      .el-col-sm-offset-6 {
        margin-left: 25%
      }

      .el-col-sm-pull-6 {
        position: relative;
        right: 25%
      }

      .el-col-sm-push-6 {
        position: relative;
        left: 25%
      }

      .el-col-sm-7 {
        display: block;
        max-width: 29.1666666667%;
        flex: 0 0 29.1666666667%
      }

      .el-col-sm-offset-7 {
        margin-left: 29.1666666667%
      }

      .el-col-sm-pull-7 {
        position: relative;
        right: 29.1666666667%
      }

      .el-col-sm-push-7 {
        position: relative;
        left: 29.1666666667%
      }

      .el-col-sm-8 {
        display: block;
        max-width: 33.3333333333%;
        flex: 0 0 33.3333333333%
      }

      .el-col-sm-offset-8 {
        margin-left: 33.3333333333%
      }

      .el-col-sm-pull-8 {
        position: relative;
        right: 33.3333333333%
      }

      .el-col-sm-push-8 {
        position: relative;
        left: 33.3333333333%
      }

      .el-col-sm-9 {
        display: block;
        max-width: 37.5%;
        flex: 0 0 37.5%
      }

      .el-col-sm-offset-9 {
        margin-left: 37.5%
      }

      .el-col-sm-pull-9 {
        position: relative;
        right: 37.5%
      }

      .el-col-sm-push-9 {
        position: relative;
        left: 37.5%
      }

      .el-col-sm-10 {
        display: block;
        max-width: 41.6666666667%;
        flex: 0 0 41.6666666667%
      }

      .el-col-sm-offset-10 {
        margin-left: 41.6666666667%
      }

      .el-col-sm-pull-10 {
        position: relative;
        right: 41.6666666667%
      }

      .el-col-sm-push-10 {
        position: relative;
        left: 41.6666666667%
      }

      .el-col-sm-11 {
        display: block;
        max-width: 45.8333333333%;
        flex: 0 0 45.8333333333%
      }

      .el-col-sm-offset-11 {
        margin-left: 45.8333333333%
      }

      .el-col-sm-pull-11 {
        position: relative;
        right: 45.8333333333%
      }

      .el-col-sm-push-11 {
        position: relative;
        left: 45.8333333333%
      }

      .el-col-sm-12 {
        display: block;
        max-width: 50%;
        flex: 0 0 50%
      }

      .el-col-sm-offset-12 {
        margin-left: 50%
      }

      .el-col-sm-pull-12 {
        position: relative;
        right: 50%
      }

      .el-col-sm-push-12 {
        position: relative;
        left: 50%
      }

      .el-col-sm-13 {
        display: block;
        max-width: 54.1666666667%;
        flex: 0 0 54.1666666667%
      }

      .el-col-sm-offset-13 {
        margin-left: 54.1666666667%
      }

      .el-col-sm-pull-13 {
        position: relative;
        right: 54.1666666667%
      }

      .el-col-sm-push-13 {
        position: relative;
        left: 54.1666666667%
      }

      .el-col-sm-14 {
        display: block;
        max-width: 58.3333333333%;
        flex: 0 0 58.3333333333%
      }

      .el-col-sm-offset-14 {
        margin-left: 58.3333333333%
      }

      .el-col-sm-pull-14 {
        position: relative;
        right: 58.3333333333%
      }

      .el-col-sm-push-14 {
        position: relative;
        left: 58.3333333333%
      }

      .el-col-sm-15 {
        display: block;
        max-width: 62.5%;
        flex: 0 0 62.5%
      }

      .el-col-sm-offset-15 {
        margin-left: 62.5%
      }

      .el-col-sm-pull-15 {
        position: relative;
        right: 62.5%
      }

      .el-col-sm-push-15 {
        position: relative;
        left: 62.5%
      }

      .el-col-sm-16 {
        display: block;
        max-width: 66.6666666667%;
        flex: 0 0 66.6666666667%
      }

      .el-col-sm-offset-16 {
        margin-left: 66.6666666667%
      }

      .el-col-sm-pull-16 {
        position: relative;
        right: 66.6666666667%
      }

      .el-col-sm-push-16 {
        position: relative;
        left: 66.6666666667%
      }

      .el-col-sm-17 {
        display: block;
        max-width: 70.8333333333%;
        flex: 0 0 70.8333333333%
      }

      .el-col-sm-offset-17 {
        margin-left: 70.8333333333%
      }

      .el-col-sm-pull-17 {
        position: relative;
        right: 70.8333333333%
      }

      .el-col-sm-push-17 {
        position: relative;
        left: 70.8333333333%
      }

      .el-col-sm-18 {
        display: block;
        max-width: 75%;
        flex: 0 0 75%
      }

      .el-col-sm-offset-18 {
        margin-left: 75%
      }

      .el-col-sm-pull-18 {
        position: relative;
        right: 75%
      }

      .el-col-sm-push-18 {
        position: relative;
        left: 75%
      }

      .el-col-sm-19 {
        display: block;
        max-width: 79.1666666667%;
        flex: 0 0 79.1666666667%
      }

      .el-col-sm-offset-19 {
        margin-left: 79.1666666667%
      }

      .el-col-sm-pull-19 {
        position: relative;
        right: 79.1666666667%
      }

      .el-col-sm-push-19 {
        position: relative;
        left: 79.1666666667%
      }

      .el-col-sm-20 {
        display: block;
        max-width: 83.3333333333%;
        flex: 0 0 83.3333333333%
      }

      .el-col-sm-offset-20 {
        margin-left: 83.3333333333%
      }

      .el-col-sm-pull-20 {
        position: relative;
        right: 83.3333333333%
      }

      .el-col-sm-push-20 {
        position: relative;
        left: 83.3333333333%
      }

      .el-col-sm-21 {
        display: block;
        max-width: 87.5%;
        flex: 0 0 87.5%
      }

      .el-col-sm-offset-21 {
        margin-left: 87.5%
      }

      .el-col-sm-pull-21 {
        position: relative;
        right: 87.5%
      }

      .el-col-sm-push-21 {
        position: relative;
        left: 87.5%
      }

      .el-col-sm-22 {
        display: block;
        max-width: 91.6666666667%;
        flex: 0 0 91.6666666667%
      }

      .el-col-sm-offset-22 {
        margin-left: 91.6666666667%
      }

      .el-col-sm-pull-22 {
        position: relative;
        right: 91.6666666667%
      }

      .el-col-sm-push-22 {
        position: relative;
        left: 91.6666666667%
      }

      .el-col-sm-23 {
        display: block;
        max-width: 95.8333333333%;
        flex: 0 0 95.8333333333%
      }

      .el-col-sm-offset-23 {
        margin-left: 95.8333333333%
      }

      .el-col-sm-pull-23 {
        position: relative;
        right: 95.8333333333%
      }

      .el-col-sm-push-23 {
        position: relative;
        left: 95.8333333333%
      }

      .el-col-sm-24 {
        display: block;
        max-width: 100%;
        flex: 0 0 100%
      }

      .el-col-sm-offset-24 {
        margin-left: 100%
      }

      .el-col-sm-pull-24 {
        position: relative;
        right: 100%
      }

      .el-col-sm-push-24 {
        position: relative;
        left: 100%
      }
    }

    @media only screen and (min-width:992px) {
      .el-col-md-0 {
        display: none
      }

      .el-col-md-0.is-guttered {
        display: none
      }

      .el-col-md-0 {
        max-width: 0%;
        flex: 0 0 0%
      }

      .el-col-md-offset-0 {
        margin-left: 0
      }

      .el-col-md-pull-0 {
        position: relative;
        right: 0
      }

      .el-col-md-push-0 {
        position: relative;
        left: 0
      }

      .el-col-md-1 {
        display: block;
        max-width: 4.1666666667%;
        flex: 0 0 4.1666666667%
      }

      .el-col-md-offset-1 {
        margin-left: 4.1666666667%
      }

      .el-col-md-pull-1 {
        position: relative;
        right: 4.1666666667%
      }

      .el-col-md-push-1 {
        position: relative;
        left: 4.1666666667%
      }

      .el-col-md-2 {
        display: block;
        max-width: 8.3333333333%;
        flex: 0 0 8.3333333333%
      }

      .el-col-md-offset-2 {
        margin-left: 8.3333333333%
      }

      .el-col-md-pull-2 {
        position: relative;
        right: 8.3333333333%
      }

      .el-col-md-push-2 {
        position: relative;
        left: 8.3333333333%
      }

      .el-col-md-3 {
        display: block;
        max-width: 12.5%;
        flex: 0 0 12.5%
      }

      .el-col-md-offset-3 {
        margin-left: 12.5%
      }

      .el-col-md-pull-3 {
        position: relative;
        right: 12.5%
      }

      .el-col-md-push-3 {
        position: relative;
        left: 12.5%
      }

      .el-col-md-4 {
        display: block;
        max-width: 16.6666666667%;
        flex: 0 0 16.6666666667%
      }

      .el-col-md-offset-4 {
        margin-left: 16.6666666667%
      }

      .el-col-md-pull-4 {
        position: relative;
        right: 16.6666666667%
      }

      .el-col-md-push-4 {
        position: relative;
        left: 16.6666666667%
      }

      .el-col-md-5 {
        display: block;
        max-width: 20.8333333333%;
        flex: 0 0 20.8333333333%
      }

      .el-col-md-offset-5 {
        margin-left: 20.8333333333%
      }

      .el-col-md-pull-5 {
        position: relative;
        right: 20.8333333333%
      }

      .el-col-md-push-5 {
        position: relative;
        left: 20.8333333333%
      }

      .el-col-md-6 {
        display: block;
        max-width: 25%;
        flex: 0 0 25%
      }

      .el-col-md-offset-6 {
        margin-left: 25%
      }

      .el-col-md-pull-6 {
        position: relative;
        right: 25%
      }

      .el-col-md-push-6 {
        position: relative;
        left: 25%
      }

      .el-col-md-7 {
        display: block;
        max-width: 29.1666666667%;
        flex: 0 0 29.1666666667%
      }

      .el-col-md-offset-7 {
        margin-left: 29.1666666667%
      }

      .el-col-md-pull-7 {
        position: relative;
        right: 29.1666666667%
      }

      .el-col-md-push-7 {
        position: relative;
        left: 29.1666666667%
      }

      .el-col-md-8 {
        display: block;
        max-width: 33.3333333333%;
        flex: 0 0 33.3333333333%
      }

      .el-col-md-offset-8 {
        margin-left: 33.3333333333%
      }

      .el-col-md-pull-8 {
        position: relative;
        right: 33.3333333333%
      }

      .el-col-md-push-8 {
        position: relative;
        left: 33.3333333333%
      }

      .el-col-md-9 {
        display: block;
        max-width: 37.5%;
        flex: 0 0 37.5%
      }

      .el-col-md-offset-9 {
        margin-left: 37.5%
      }

      .el-col-md-pull-9 {
        position: relative;
        right: 37.5%
      }

      .el-col-md-push-9 {
        position: relative;
        left: 37.5%
      }

      .el-col-md-10 {
        display: block;
        max-width: 41.6666666667%;
        flex: 0 0 41.6666666667%
      }

      .el-col-md-offset-10 {
        margin-left: 41.6666666667%
      }

      .el-col-md-pull-10 {
        position: relative;
        right: 41.6666666667%
      }

      .el-col-md-push-10 {
        position: relative;
        left: 41.6666666667%
      }

      .el-col-md-11 {
        display: block;
        max-width: 45.8333333333%;
        flex: 0 0 45.8333333333%
      }

      .el-col-md-offset-11 {
        margin-left: 45.8333333333%
      }

      .el-col-md-pull-11 {
        position: relative;
        right: 45.8333333333%
      }

      .el-col-md-push-11 {
        position: relative;
        left: 45.8333333333%
      }

      .el-col-md-12 {
        display: block;
        max-width: 50%;
        flex: 0 0 50%
      }

      .el-col-md-offset-12 {
        margin-left: 50%
      }

      .el-col-md-pull-12 {
        position: relative;
        right: 50%
      }

      .el-col-md-push-12 {
        position: relative;
        left: 50%
      }

      .el-col-md-13 {
        display: block;
        max-width: 54.1666666667%;
        flex: 0 0 54.1666666667%
      }

      .el-col-md-offset-13 {
        margin-left: 54.1666666667%
      }

      .el-col-md-pull-13 {
        position: relative;
        right: 54.1666666667%
      }

      .el-col-md-push-13 {
        position: relative;
        left: 54.1666666667%
      }

      .el-col-md-14 {
        display: block;
        max-width: 58.3333333333%;
        flex: 0 0 58.3333333333%
      }

      .el-col-md-offset-14 {
        margin-left: 58.3333333333%
      }

      .el-col-md-pull-14 {
        position: relative;
        right: 58.3333333333%
      }

      .el-col-md-push-14 {
        position: relative;
        left: 58.3333333333%
      }

      .el-col-md-15 {
        display: block;
        max-width: 62.5%;
        flex: 0 0 62.5%
      }

      .el-col-md-offset-15 {
        margin-left: 62.5%
      }

      .el-col-md-pull-15 {
        position: relative;
        right: 62.5%
      }

      .el-col-md-push-15 {
        position: relative;
        left: 62.5%
      }

      .el-col-md-16 {
        display: block;
        max-width: 66.6666666667%;
        flex: 0 0 66.6666666667%
      }

      .el-col-md-offset-16 {
        margin-left: 66.6666666667%
      }

      .el-col-md-pull-16 {
        position: relative;
        right: 66.6666666667%
      }

      .el-col-md-push-16 {
        position: relative;
        left: 66.6666666667%
      }

      .el-col-md-17 {
        display: block;
        max-width: 70.8333333333%;
        flex: 0 0 70.8333333333%
      }

      .el-col-md-offset-17 {
        margin-left: 70.8333333333%
      }

      .el-col-md-pull-17 {
        position: relative;
        right: 70.8333333333%
      }

      .el-col-md-push-17 {
        position: relative;
        left: 70.8333333333%
      }

      .el-col-md-18 {
        display: block;
        max-width: 75%;
        flex: 0 0 75%
      }

      .el-col-md-offset-18 {
        margin-left: 75%
      }

      .el-col-md-pull-18 {
        position: relative;
        right: 75%
      }

      .el-col-md-push-18 {
        position: relative;
        left: 75%
      }

      .el-col-md-19 {
        display: block;
        max-width: 79.1666666667%;
        flex: 0 0 79.1666666667%
      }

      .el-col-md-offset-19 {
        margin-left: 79.1666666667%
      }

      .el-col-md-pull-19 {
        position: relative;
        right: 79.1666666667%
      }

      .el-col-md-push-19 {
        position: relative;
        left: 79.1666666667%
      }

      .el-col-md-20 {
        display: block;
        max-width: 83.3333333333%;
        flex: 0 0 83.3333333333%
      }

      .el-col-md-offset-20 {
        margin-left: 83.3333333333%
      }

      .el-col-md-pull-20 {
        position: relative;
        right: 83.3333333333%
      }

      .el-col-md-push-20 {
        position: relative;
        left: 83.3333333333%
      }

      .el-col-md-21 {
        display: block;
        max-width: 87.5%;
        flex: 0 0 87.5%
      }

      .el-col-md-offset-21 {
        margin-left: 87.5%
      }

      .el-col-md-pull-21 {
        position: relative;
        right: 87.5%
      }

      .el-col-md-push-21 {
        position: relative;
        left: 87.5%
      }

      .el-col-md-22 {
        display: block;
        max-width: 91.6666666667%;
        flex: 0 0 91.6666666667%
      }

      .el-col-md-offset-22 {
        margin-left: 91.6666666667%
      }

      .el-col-md-pull-22 {
        position: relative;
        right: 91.6666666667%
      }

      .el-col-md-push-22 {
        position: relative;
        left: 91.6666666667%
      }

      .el-col-md-23 {
        display: block;
        max-width: 95.8333333333%;
        flex: 0 0 95.8333333333%
      }

      .el-col-md-offset-23 {
        margin-left: 95.8333333333%
      }

      .el-col-md-pull-23 {
        position: relative;
        right: 95.8333333333%
      }

      .el-col-md-push-23 {
        position: relative;
        left: 95.8333333333%
      }

      .el-col-md-24 {
        display: block;
        max-width: 100%;
        flex: 0 0 100%
      }

      .el-col-md-offset-24 {
        margin-left: 100%
      }

      .el-col-md-pull-24 {
        position: relative;
        right: 100%
      }

      .el-col-md-push-24 {
        position: relative;
        left: 100%
      }
    }

    @media only screen and (min-width:1200px) {
      .el-col-lg-0 {
        display: none
      }

      .el-col-lg-0.is-guttered {
        display: none
      }

      .el-col-lg-0 {
        max-width: 0%;
        flex: 0 0 0%
      }

      .el-col-lg-offset-0 {
        margin-left: 0
      }

      .el-col-lg-pull-0 {
        position: relative;
        right: 0
      }

      .el-col-lg-push-0 {
        position: relative;
        left: 0
      }

      .el-col-lg-1 {
        display: block;
        max-width: 4.1666666667%;
        flex: 0 0 4.1666666667%
      }

      .el-col-lg-offset-1 {
        margin-left: 4.1666666667%
      }

      .el-col-lg-pull-1 {
        position: relative;
        right: 4.1666666667%
      }

      .el-col-lg-push-1 {
        position: relative;
        left: 4.1666666667%
      }

      .el-col-lg-2 {
        display: block;
        max-width: 8.3333333333%;
        flex: 0 0 8.3333333333%
      }

      .el-col-lg-offset-2 {
        margin-left: 8.3333333333%
      }

      .el-col-lg-pull-2 {
        position: relative;
        right: 8.3333333333%
      }

      .el-col-lg-push-2 {
        position: relative;
        left: 8.3333333333%
      }

      .el-col-lg-3 {
        display: block;
        max-width: 12.5%;
        flex: 0 0 12.5%
      }

      .el-col-lg-offset-3 {
        margin-left: 12.5%
      }

      .el-col-lg-pull-3 {
        position: relative;
        right: 12.5%
      }

      .el-col-lg-push-3 {
        position: relative;
        left: 12.5%
      }

      .el-col-lg-4 {
        display: block;
        max-width: 16.6666666667%;
        flex: 0 0 16.6666666667%
      }

      .el-col-lg-offset-4 {
        margin-left: 16.6666666667%
      }

      .el-col-lg-pull-4 {
        position: relative;
        right: 16.6666666667%
      }

      .el-col-lg-push-4 {
        position: relative;
        left: 16.6666666667%
      }

      .el-col-lg-5 {
        display: block;
        max-width: 20.8333333333%;
        flex: 0 0 20.8333333333%
      }

      .el-col-lg-offset-5 {
        margin-left: 20.8333333333%
      }

      .el-col-lg-pull-5 {
        position: relative;
        right: 20.8333333333%
      }

      .el-col-lg-push-5 {
        position: relative;
        left: 20.8333333333%
      }

      .el-col-lg-6 {
        display: block;
        max-width: 25%;
        flex: 0 0 25%
      }

      .el-col-lg-offset-6 {
        margin-left: 25%
      }

      .el-col-lg-pull-6 {
        position: relative;
        right: 25%
      }

      .el-col-lg-push-6 {
        position: relative;
        left: 25%
      }

      .el-col-lg-7 {
        display: block;
        max-width: 29.1666666667%;
        flex: 0 0 29.1666666667%
      }

      .el-col-lg-offset-7 {
        margin-left: 29.1666666667%
      }

      .el-col-lg-pull-7 {
        position: relative;
        right: 29.1666666667%
      }

      .el-col-lg-push-7 {
        position: relative;
        left: 29.1666666667%
      }

      .el-col-lg-8 {
        display: block;
        max-width: 33.3333333333%;
        flex: 0 0 33.3333333333%
      }

      .el-col-lg-offset-8 {
        margin-left: 33.3333333333%
      }

      .el-col-lg-pull-8 {
        position: relative;
        right: 33.3333333333%
      }

      .el-col-lg-push-8 {
        position: relative;
        left: 33.3333333333%
      }

      .el-col-lg-9 {
        display: block;
        max-width: 37.5%;
        flex: 0 0 37.5%
      }

      .el-col-lg-offset-9 {
        margin-left: 37.5%
      }

      .el-col-lg-pull-9 {
        position: relative;
        right: 37.5%
      }

      .el-col-lg-push-9 {
        position: relative;
        left: 37.5%
      }

      .el-col-lg-10 {
        display: block;
        max-width: 41.6666666667%;
        flex: 0 0 41.6666666667%
      }

      .el-col-lg-offset-10 {
        margin-left: 41.6666666667%
      }

      .el-col-lg-pull-10 {
        position: relative;
        right: 41.6666666667%
      }

      .el-col-lg-push-10 {
        position: relative;
        left: 41.6666666667%
      }

      .el-col-lg-11 {
        display: block;
        max-width: 45.8333333333%;
        flex: 0 0 45.8333333333%
      }

      .el-col-lg-offset-11 {
        margin-left: 45.8333333333%
      }

      .el-col-lg-pull-11 {
        position: relative;
        right: 45.8333333333%
      }

      .el-col-lg-push-11 {
        position: relative;
        left: 45.8333333333%
      }

      .el-col-lg-12 {
        display: block;
        max-width: 50%;
        flex: 0 0 50%
      }

      .el-col-lg-offset-12 {
        margin-left: 50%
      }

      .el-col-lg-pull-12 {
        position: relative;
        right: 50%
      }

      .el-col-lg-push-12 {
        position: relative;
        left: 50%
      }

      .el-col-lg-13 {
        display: block;
        max-width: 54.1666666667%;
        flex: 0 0 54.1666666667%
      }

      .el-col-lg-offset-13 {
        margin-left: 54.1666666667%
      }

      .el-col-lg-pull-13 {
        position: relative;
        right: 54.1666666667%
      }

      .el-col-lg-push-13 {
        position: relative;
        left: 54.1666666667%
      }

      .el-col-lg-14 {
        display: block;
        max-width: 58.3333333333%;
        flex: 0 0 58.3333333333%
      }

      .el-col-lg-offset-14 {
        margin-left: 58.3333333333%
      }

      .el-col-lg-pull-14 {
        position: relative;
        right: 58.3333333333%
      }

      .el-col-lg-push-14 {
        position: relative;
        left: 58.3333333333%
      }

      .el-col-lg-15 {
        display: block;
        max-width: 62.5%;
        flex: 0 0 62.5%
      }

      .el-col-lg-offset-15 {
        margin-left: 62.5%
      }

      .el-col-lg-pull-15 {
        position: relative;
        right: 62.5%
      }

      .el-col-lg-push-15 {
        position: relative;
        left: 62.5%
      }

      .el-col-lg-16 {
        display: block;
        max-width: 66.6666666667%;
        flex: 0 0 66.6666666667%
      }

      .el-col-lg-offset-16 {
        margin-left: 66.6666666667%
      }

      .el-col-lg-pull-16 {
        position: relative;
        right: 66.6666666667%
      }

      .el-col-lg-push-16 {
        position: relative;
        left: 66.6666666667%
      }

      .el-col-lg-17 {
        display: block;
        max-width: 70.8333333333%;
        flex: 0 0 70.8333333333%
      }

      .el-col-lg-offset-17 {
        margin-left: 70.8333333333%
      }

      .el-col-lg-pull-17 {
        position: relative;
        right: 70.8333333333%
      }

      .el-col-lg-push-17 {
        position: relative;
        left: 70.8333333333%
      }

      .el-col-lg-18 {
        display: block;
        max-width: 75%;
        flex: 0 0 75%
      }

      .el-col-lg-offset-18 {
        margin-left: 75%
      }

      .el-col-lg-pull-18 {
        position: relative;
        right: 75%
      }

      .el-col-lg-push-18 {
        position: relative;
        left: 75%
      }

      .el-col-lg-19 {
        display: block;
        max-width: 79.1666666667%;
        flex: 0 0 79.1666666667%
      }

      .el-col-lg-offset-19 {
        margin-left: 79.1666666667%
      }

      .el-col-lg-pull-19 {
        position: relative;
        right: 79.1666666667%
      }

      .el-col-lg-push-19 {
        position: relative;
        left: 79.1666666667%
      }

      .el-col-lg-20 {
        display: block;
        max-width: 83.3333333333%;
        flex: 0 0 83.3333333333%
      }

      .el-col-lg-offset-20 {
        margin-left: 83.3333333333%
      }

      .el-col-lg-pull-20 {
        position: relative;
        right: 83.3333333333%
      }

      .el-col-lg-push-20 {
        position: relative;
        left: 83.3333333333%
      }

      .el-col-lg-21 {
        display: block;
        max-width: 87.5%;
        flex: 0 0 87.5%
      }

      .el-col-lg-offset-21 {
        margin-left: 87.5%
      }

      .el-col-lg-pull-21 {
        position: relative;
        right: 87.5%
      }

      .el-col-lg-push-21 {
        position: relative;
        left: 87.5%
      }

      .el-col-lg-22 {
        display: block;
        max-width: 91.6666666667%;
        flex: 0 0 91.6666666667%
      }

      .el-col-lg-offset-22 {
        margin-left: 91.6666666667%
      }

      .el-col-lg-pull-22 {
        position: relative;
        right: 91.6666666667%
      }

      .el-col-lg-push-22 {
        position: relative;
        left: 91.6666666667%
      }

      .el-col-lg-23 {
        display: block;
        max-width: 95.8333333333%;
        flex: 0 0 95.8333333333%
      }

      .el-col-lg-offset-23 {
        margin-left: 95.8333333333%
      }

      .el-col-lg-pull-23 {
        position: relative;
        right: 95.8333333333%
      }

      .el-col-lg-push-23 {
        position: relative;
        left: 95.8333333333%
      }

      .el-col-lg-24 {
        display: block;
        max-width: 100%;
        flex: 0 0 100%
      }

      .el-col-lg-offset-24 {
        margin-left: 100%
      }

      .el-col-lg-pull-24 {
        position: relative;
        right: 100%
      }

      .el-col-lg-push-24 {
        position: relative;
        left: 100%
      }
    }

    @media only screen and (min-width:1920px) {
      .el-col-xl-0 {
        display: none
      }

      .el-col-xl-0.is-guttered {
        display: none
      }

      .el-col-xl-0 {
        max-width: 0%;
        flex: 0 0 0%
      }

      .el-col-xl-offset-0 {
        margin-left: 0
      }

      .el-col-xl-pull-0 {
        position: relative;
        right: 0
      }

      .el-col-xl-push-0 {
        position: relative;
        left: 0
      }

      .el-col-xl-1 {
        display: block;
        max-width: 4.1666666667%;
        flex: 0 0 4.1666666667%
      }

      .el-col-xl-offset-1 {
        margin-left: 4.1666666667%
      }

      .el-col-xl-pull-1 {
        position: relative;
        right: 4.1666666667%
      }

      .el-col-xl-push-1 {
        position: relative;
        left: 4.1666666667%
      }

      .el-col-xl-2 {
        display: block;
        max-width: 8.3333333333%;
        flex: 0 0 8.3333333333%
      }

      .el-col-xl-offset-2 {
        margin-left: 8.3333333333%
      }

      .el-col-xl-pull-2 {
        position: relative;
        right: 8.3333333333%
      }

      .el-col-xl-push-2 {
        position: relative;
        left: 8.3333333333%
      }

      .el-col-xl-3 {
        display: block;
        max-width: 12.5%;
        flex: 0 0 12.5%
      }

      .el-col-xl-offset-3 {
        margin-left: 12.5%
      }

      .el-col-xl-pull-3 {
        position: relative;
        right: 12.5%
      }

      .el-col-xl-push-3 {
        position: relative;
        left: 12.5%
      }

      .el-col-xl-4 {
        display: block;
        max-width: 16.6666666667%;
        flex: 0 0 16.6666666667%
      }

      .el-col-xl-offset-4 {
        margin-left: 16.6666666667%
      }

      .el-col-xl-pull-4 {
        position: relative;
        right: 16.6666666667%
      }

      .el-col-xl-push-4 {
        position: relative;
        left: 16.6666666667%
      }

      .el-col-xl-5 {
        display: block;
        max-width: 20.8333333333%;
        flex: 0 0 20.8333333333%
      }

      .el-col-xl-offset-5 {
        margin-left: 20.8333333333%
      }

      .el-col-xl-pull-5 {
        position: relative;
        right: 20.8333333333%
      }

      .el-col-xl-push-5 {
        position: relative;
        left: 20.8333333333%
      }

      .el-col-xl-6 {
        display: block;
        max-width: 25%;
        flex: 0 0 25%
      }

      .el-col-xl-offset-6 {
        margin-left: 25%
      }

      .el-col-xl-pull-6 {
        position: relative;
        right: 25%
      }

      .el-col-xl-push-6 {
        position: relative;
        left: 25%
      }

      .el-col-xl-7 {
        display: block;
        max-width: 29.1666666667%;
        flex: 0 0 29.1666666667%
      }

      .el-col-xl-offset-7 {
        margin-left: 29.1666666667%
      }

      .el-col-xl-pull-7 {
        position: relative;
        right: 29.1666666667%
      }

      .el-col-xl-push-7 {
        position: relative;
        left: 29.1666666667%
      }

      .el-col-xl-8 {
        display: block;
        max-width: 33.3333333333%;
        flex: 0 0 33.3333333333%
      }

      .el-col-xl-offset-8 {
        margin-left: 33.3333333333%
      }

      .el-col-xl-pull-8 {
        position: relative;
        right: 33.3333333333%
      }

      .el-col-xl-push-8 {
        position: relative;
        left: 33.3333333333%
      }

      .el-col-xl-9 {
        display: block;
        max-width: 37.5%;
        flex: 0 0 37.5%
      }

      .el-col-xl-offset-9 {
        margin-left: 37.5%
      }

      .el-col-xl-pull-9 {
        position: relative;
        right: 37.5%
      }

      .el-col-xl-push-9 {
        position: relative;
        left: 37.5%
      }

      .el-col-xl-10 {
        display: block;
        max-width: 41.6666666667%;
        flex: 0 0 41.6666666667%
      }

      .el-col-xl-offset-10 {
        margin-left: 41.6666666667%
      }

      .el-col-xl-pull-10 {
        position: relative;
        right: 41.6666666667%
      }

      .el-col-xl-push-10 {
        position: relative;
        left: 41.6666666667%
      }

      .el-col-xl-11 {
        display: block;
        max-width: 45.8333333333%;
        flex: 0 0 45.8333333333%
      }

      .el-col-xl-offset-11 {
        margin-left: 45.8333333333%
      }

      .el-col-xl-pull-11 {
        position: relative;
        right: 45.8333333333%
      }

      .el-col-xl-push-11 {
        position: relative;
        left: 45.8333333333%
      }

      .el-col-xl-12 {
        display: block;
        max-width: 50%;
        flex: 0 0 50%
      }

      .el-col-xl-offset-12 {
        margin-left: 50%
      }

      .el-col-xl-pull-12 {
        position: relative;
        right: 50%
      }

      .el-col-xl-push-12 {
        position: relative;
        left: 50%
      }

      .el-col-xl-13 {
        display: block;
        max-width: 54.1666666667%;
        flex: 0 0 54.1666666667%
      }

      .el-col-xl-offset-13 {
        margin-left: 54.1666666667%
      }

      .el-col-xl-pull-13 {
        position: relative;
        right: 54.1666666667%
      }

      .el-col-xl-push-13 {
        position: relative;
        left: 54.1666666667%
      }

      .el-col-xl-14 {
        display: block;
        max-width: 58.3333333333%;
        flex: 0 0 58.3333333333%
      }

      .el-col-xl-offset-14 {
        margin-left: 58.3333333333%
      }

      .el-col-xl-pull-14 {
        position: relative;
        right: 58.3333333333%
      }

      .el-col-xl-push-14 {
        position: relative;
        left: 58.3333333333%
      }

      .el-col-xl-15 {
        display: block;
        max-width: 62.5%;
        flex: 0 0 62.5%
      }

      .el-col-xl-offset-15 {
        margin-left: 62.5%
      }

      .el-col-xl-pull-15 {
        position: relative;
        right: 62.5%
      }

      .el-col-xl-push-15 {
        position: relative;
        left: 62.5%
      }

      .el-col-xl-16 {
        display: block;
        max-width: 66.6666666667%;
        flex: 0 0 66.6666666667%
      }

      .el-col-xl-offset-16 {
        margin-left: 66.6666666667%
      }

      .el-col-xl-pull-16 {
        position: relative;
        right: 66.6666666667%
      }

      .el-col-xl-push-16 {
        position: relative;
        left: 66.6666666667%
      }

      .el-col-xl-17 {
        display: block;
        max-width: 70.8333333333%;
        flex: 0 0 70.8333333333%
      }

      .el-col-xl-offset-17 {
        margin-left: 70.8333333333%
      }

      .el-col-xl-pull-17 {
        position: relative;
        right: 70.8333333333%
      }

      .el-col-xl-push-17 {
        position: relative;
        left: 70.8333333333%
      }

      .el-col-xl-18 {
        display: block;
        max-width: 75%;
        flex: 0 0 75%
      }

      .el-col-xl-offset-18 {
        margin-left: 75%
      }

      .el-col-xl-pull-18 {
        position: relative;
        right: 75%
      }

      .el-col-xl-push-18 {
        position: relative;
        left: 75%
      }

      .el-col-xl-19 {
        display: block;
        max-width: 79.1666666667%;
        flex: 0 0 79.1666666667%
      }

      .el-col-xl-offset-19 {
        margin-left: 79.1666666667%
      }

      .el-col-xl-pull-19 {
        position: relative;
        right: 79.1666666667%
      }

      .el-col-xl-push-19 {
        position: relative;
        left: 79.1666666667%
      }

      .el-col-xl-20 {
        display: block;
        max-width: 83.3333333333%;
        flex: 0 0 83.3333333333%
      }

      .el-col-xl-offset-20 {
        margin-left: 83.3333333333%
      }

      .el-col-xl-pull-20 {
        position: relative;
        right: 83.3333333333%
      }

      .el-col-xl-push-20 {
        position: relative;
        left: 83.3333333333%
      }

      .el-col-xl-21 {
        display: block;
        max-width: 87.5%;
        flex: 0 0 87.5%
      }

      .el-col-xl-offset-21 {
        margin-left: 87.5%
      }

      .el-col-xl-pull-21 {
        position: relative;
        right: 87.5%
      }

      .el-col-xl-push-21 {
        position: relative;
        left: 87.5%
      }

      .el-col-xl-22 {
        display: block;
        max-width: 91.6666666667%;
        flex: 0 0 91.6666666667%
      }

      .el-col-xl-offset-22 {
        margin-left: 91.6666666667%
      }

      .el-col-xl-pull-22 {
        position: relative;
        right: 91.6666666667%
      }

      .el-col-xl-push-22 {
        position: relative;
        left: 91.6666666667%
      }

      .el-col-xl-23 {
        display: block;
        max-width: 95.8333333333%;
        flex: 0 0 95.8333333333%
      }

      .el-col-xl-offset-23 {
        margin-left: 95.8333333333%
      }

      .el-col-xl-pull-23 {
        position: relative;
        right: 95.8333333333%
      }

      .el-col-xl-push-23 {
        position: relative;
        left: 95.8333333333%
      }

      .el-col-xl-24 {
        display: block;
        max-width: 100%;
        flex: 0 0 100%
      }

      .el-col-xl-offset-24 {
        margin-left: 100%
      }

      .el-col-xl-pull-24 {
        position: relative;
        right: 100%
      }

      .el-col-xl-push-24 {
        position: relative;
        left: 100%
      }
    }
  </style>
  <style type=""text/css""
    data-vite-dev-id=""E:/code/test/ui/panda.net.web/src/views/login/index.vue?vue&amp;type=style&amp;index=0&amp;scoped=2bf2fc29&amp;lang.scss"">
    .login-container[data-v-2bf2fc29] {
      width: 100%;
      height: 100vh;
      background-color: rgb(69,108,203);
      background-size: cover;
    }

    .login-container .login-form[data-v-2bf2fc29] {
      position: relative;
      width: 60%;
      top: 30vh;
      background-color: rgb(64,80,196);
      background-size: cover;
      padding: 40px;
    }

    .login-container .login-form h1[data-v-2bf2fc29] {
      color: white;
      font-size: 40px;
    }

    .login-container .login-form h2[data-v-2bf2fc29] {
      font-size: 20px;
      color: white;
      margin: 20px 0px;
    }

    .login-container .login-form .login-btn[data-v-2bf2fc29] {
      width: 100%;
    }
  </style>
</head>

<body>
  <div class=""app"" id=""app"" data-v-app="""">
    <div data-v-2bf2fc29="""" class=""login-container"">
      <div data-v-2bf2fc29="""" class=""el-row"">
        <div data-v-2bf2fc29="""" class=""el-col el-col-12 el-col-xs-0""></div>
        <div data-v-2bf2fc29="""" class=""el-col el-col-12 el-col-xs-24"">
          <form form action=""{0}account/login"" method=""post"" data-v-2bf2fc29="""" class=""el-form el-form--default el-form--label-right login-form"">
            <h1 data-v-2bf2fc29="""">Hello</h1>
            <h2 data-v-2bf2fc29="""">欢迎来到Scheduler</h2>
            <div data-v-2bf2fc29="""" class=""el-form-item is-required asterisk-left"">
              <div class=""el-form-item__content"">
                <div data-v-2bf2fc29="""" class=""el-input el-input--prefix"">
                  <div class=""el-input__wrapper"" tabindex=""-1"">
                    <span class=""el-input__prefix"">
                      <span class=""el-input__prefix-inner"">
                        <i class=""el-icon el-input__icon"">
                          <svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 1024 1024"">
                            <path fill=""currentColor""
                              d=""M512 512a192 192 0 1 0 0-384 192 192 0 0 0 0 384m0 64a256 256 0 1 1 0-512 256 256 0 0 1 0 512m320 320v-96a96 96 0 0 0-96-96H288a96 96 0 0 0-96 96v96a32 32 0 1 1-64 0v-96a160 160 0 0 1 160-160h448a160 160 0 0 1 160 160v96a32 32 0 1 1-64 0"">
                            </path>
                          </svg></i></span></span><input name=""username"" class=""el-input__inner"" maxlength=""32"" type=""text""
                      autocomplete=""off"" tabindex=""0"" placeholder=""请输入账号""
                      id=""el-id-318-3""><!-- suffix slot --><!--v-if-->
                  </div><!-- append slot --><!--v-if-->
                </div>
              </div>
            </div>
            <div data-v-2bf2fc29="""" class=""el-form-item is-required asterisk-left""><!--v-if-->
              <div class=""el-form-item__content"">
                <div data-v-2bf2fc29="""" class=""el-input el-input--prefix""><!-- input --><!-- prepend slot --><!--v-if-->
                  <div class=""el-input__wrapper"" tabindex=""-1""><!-- prefix slot --><span class=""el-input__prefix""><span
                        class=""el-input__prefix-inner""><i class=""el-icon el-input__icon""><svg
                            xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 1024 1024"">
                            <path fill=""currentColor""
                              d=""M224 448a32 32 0 0 0-32 32v384a32 32 0 0 0 32 32h576a32 32 0 0 0 32-32V480a32 32 0 0 0-32-32zm0-64h576a96 96 0 0 1 96 96v384a96 96 0 0 1-96 96H224a96 96 0 0 1-96-96V480a96 96 0 0 1 96-96"">
                            </path>
                            <path fill=""currentColor""
                              d=""M512 544a32 32 0 0 1 32 32v192a32 32 0 1 1-64 0V576a32 32 0 0 1 32-32m192-160v-64a192 192 0 1 0-384 0v64zM512 64a256 256 0 0 1 256 256v128H256V320A256 256 0 0 1 512 64"">
                            </path>
                          </svg></i></span></span><input name=""pwd"" class=""el-input__inner"" maxlength=""32"" type=""password""
                      autocomplete=""off"" tabindex=""0"" placeholder=""请输入密码""
                      id=""el-id-318-4""><!-- suffix slot --><!--v-if--></div><!-- append slot --><!--v-if-->
                </div>
              </div>
            </div>
            <div data-v-2bf2fc29="""" class=""el-form-item asterisk-left""><!--v-if-->
              <div class=""el-form-item__content""><button data-v-2bf2fc29="""" aria-disabled=""false"" type=""submit""
                  class=""el-button el-button--primary el-button--default login-btn""><!--v-if--><span class=""""> 登录
                  </span></button></div>
            </div>
          </form>
        </div>
        <div data-v-2bf2fc29="""" class=""el-col el-col-24""></div>
      </div>
    </div>
  </div>
</body>
</html>";
    }
}
#endif
